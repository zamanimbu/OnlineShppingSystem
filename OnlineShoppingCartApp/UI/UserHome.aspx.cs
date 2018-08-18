using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShoppingCartApp.UI
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                signOutButton.Visible = false;
                lblSuccess.Text = "<br/> <h2> Welcome " + Session["UserName"].ToString()+"</h2> ";
            }
            else
            {
                Response.Redirect("SignIn.aspx");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Master.SignOutButton.Click += new EventHandler(signOutButton_Click);
        }

        protected void signOutButton_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}