using System.Collections.Generic;
using System.Linq;
using NHibernate;
using QuickStart.Models;

namespace QuickStart.lib
{
    public class BlogOds
    {
        private static int _recordCount;
        public static int GetRecordCount()
        {
            return _recordCount;
        }

        public static IList<BlogItem> GetBlogRecords()
        {
            return GetBlogRecords(int.MaxValue, 0, "Id");
        }

        public static IList<BlogItem> GetBlogRecords(string sortExpression)
        {
            return GetBlogRecords(int.MaxValue, 0, sortExpression);
        }

        public static IList<BlogItem> GetBlogRecords(int maximumRows, int startIndex, string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = "Id";
            }

            IList<BlogItem> result = null;

            ISession session = Global.CurrentSession;
            ITransaction tx = session.BeginTransaction();

            //http://nhforge.org/blogs/nhibernate/archive/2009/01/30/futuret_2D00_queries_2D00_with_2D00_hql_2D00_and_2D00_criteria.aspx
            IFutureValue<int> count = session.CreateCriteria(typeof(BlogItem))
                                       .CreateCriteria("Blog")
                                       .SetProjection(NHibernate.Criterion.Projections.Count(NHibernate.Criterion.Projections.Id()))
                                       .FutureValue<int>();

            var blogItems = session.CreateCriteria(typeof(BlogItem))
                            .CreateCriteria("Blog")
                            .SetFirstResult((startIndex - 1)*maximumRows)
                            .SetMaxResults(maximumRows)
                            .AddOrder((!sortExpression.Contains("DESC"))? NHibernate.Criterion.Order.Asc(sortExpression): NHibernate.Criterion.Order.Desc(sortExpression.Substring(0,sortExpression.IndexOf(" ",System.StringComparison.Ordinal))))
                            .Future<BlogItem>();

            _recordCount = count.Value;
            result = blogItems.ToList();

            tx.Commit();

            return result;
        }
    }
}