using System;

namespace QuickStart
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateTables_Click(object sender, EventArgs e)
        {
            MainBlog mainBlog = new MainBlog();
            mainBlog.ExportTables();
            lblMsg.Text = "Tables created";
        }

        protected void btnDropTables_Click(object sender, EventArgs e)
        {
            MainBlog mainBlog = new MainBlog();
            mainBlog.DropTables();
            lblMsg.Text = "Tables dropped";
        }
    }
}