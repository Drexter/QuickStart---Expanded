using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using QuickStart.Models;

namespace QuickStart
{
    public class MainBlog
    {
        public void ExportTables()
        {
            Configuration cfg = new Configuration();
            cfg.Configure(System.Configuration.ConfigurationManager.AppSettings["PATH_NHIBERNATE_CONFIG_FILE"]);
            new SchemaExport(cfg).Create(true, true);
        }

        public void DropTables()
        {
            Configuration cfg = new Configuration();
            cfg.Configure(System.Configuration.ConfigurationManager.AppSettings["PATH_NHIBERNATE_CONFIG_FILE"]);
            new SchemaExport(cfg).Drop(true, true);
        }

        public Blog CreateBlog(string name)
        {
            Blog blog = new Blog();
            blog.Name = name;
            blog.Items = new ArrayList();

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();
            
                session.Save(blog);
                tx.Commit();

            return blog;
        }

        public BlogItem CreateBlogItem(Blog blog, string title, string text)
        {
            BlogItem item = new BlogItem();
            item.Title = title;
            item.Text = text;
            item.Blog = blog;
            item.DateTime = DateTime.Now;
            blog.Items = new List<BlogItem>();
            blog.Items.Add(item);

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();
            
                session.SaveOrUpdate(blog);
                tx.Commit();
            
            return item;
        }

        public BlogItem CreateBlogItem(long blogId, string title, string text)
        {
            BlogItem item = new BlogItem();
            item.Title = title;
            item.Text = text;
            item.DateTime = DateTime.Now;

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();

                Blog blog = (Blog)session.Load(typeof(Blog), blogId);
                item.Blog = blog;
                blog.Items.Add(item);
                tx.Commit();
            
            return item;
        }

        public void UpdateBlogItem(BlogItem item, string text)
        {
            item.Text = text;

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();

                session.CreateQuery("UPDATE BlogItem "
                                    + "SET Title = :blogTitle, "
                                    + "Text = :blogText "
                                    + "WHERE Id = :Blog_Item_Id")
                                    .SetParameter("blogTitle", item.Title)
                                    .SetParameter("blogText", item.Text)
                                    .SetParameter("Blog_Item_Id", item.Id)
                                    .ExecuteUpdate();      
                tx.Commit();
            
        }

        public void UpdateBlogItem(long itemId, string text)
        {
            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();
           
                BlogItem item = (BlogItem)session.Load(typeof(BlogItem), itemId);
                item.Text = text;
                tx.Commit();
           
        }

        public IList ListAllBlogNamesAndItemCounts(int max)
        {
            IList result = null;

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();
                
            IQuery q = session.CreateQuery(
                    "select blog.id, blog.Name, count(blogItem) " +
                    "from Blog as blog " +
                    "left outer join blog.Items as blogItem " +
                    "group by blog.Name, blog.id " +
                    "order by max(blogItem.DateTime)"
                );
                q.SetMaxResults(max);
                result = q.List();
                tx.Commit();
            

            return result;
        }

        public Blog GetBlogAndAllItems(long blogId)
        {
            Blog blog = null;

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();

                IQuery q = session.CreateQuery(
                    "from Blog as blog " +
                    "left outer join fetch blog.Items " +
                    "where blog.id = :blogId"
                );
                q.SetParameter("blogId", blogId);
                blog = (Blog)q.List()[0];
                tx.Commit();
            
            return blog;
        }

        public IList ListBlogsAndRecentItems()
        {
            IList result = null;

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();
                IQuery q = session.CreateQuery(
                    "from Blog as blog " +
                    "inner join blog.Items as blogItem " +
                    "where blogItem.DateTime > :minDate"
                );

                DateTime date = DateTime.Now.AddMonths(-1);
                q.SetDateTime("minDate", date);

                result = q.List();
                tx.Commit();
            
            return result;
        }
    }
}