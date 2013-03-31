using System;
using QuickStart.Models;

namespace QuickStart
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                LoadForm(id);
            }
        }

        protected void LoadForm(int Id)
        {
            MainBlog mb = new MainBlog();
            Blog b = mb.GetBlogAndAllItems(Id);

            foreach (BlogItem bi in b.Items)
            {
                txtTitle.Text = bi.Title;
                txtText.Text = bi.Text;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MainBlog mb = new MainBlog();
            BlogItem bi = new BlogItem();

            bi.Id = Convert.ToInt32(Request.QueryString["Id"]);
            bi.Title = txtTitle.Text;
            bi.Text = txtText.Text;

            mb.UpdateBlogItem(bi, txtText.Text);
            Response.Redirect("Main.aspx");
        }
    }
}