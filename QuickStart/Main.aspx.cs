using System;
using System.Web.UI.WebControls;
using QuickStart.Models;

namespace QuickStart
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Blog blog = new Blog();
            blog.Name = txtBlog.Text;
            MainBlog mb = new MainBlog();
            mb.CreateBlogItem(blog, txtTitle.Text.Trim(), txtBlogText.Text.Trim());
            GridView1.DataBind();

        }

        protected void gvBlogs_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int BlogItemId = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Value);
                LinkButton lnkBtnId = ((LinkButton)e.Row.FindControl("lnkBtnId"));
                lnkBtnId.PostBackUrl = string.Format("Edit.aspx?id={0}", BlogItemId.ToString());
            }
        }
    }
}