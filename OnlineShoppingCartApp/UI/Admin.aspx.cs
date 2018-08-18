using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShoppingCartApp.UI
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignOutButton.Visible = false;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.SignoutButton.Click += new EventHandler(signOutButton_Click);
        }
        protected void signOutButton_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("Home.aspx");
        }

        
    }
}