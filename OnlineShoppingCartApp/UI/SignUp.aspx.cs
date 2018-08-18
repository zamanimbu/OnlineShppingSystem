using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.Model;
using OnlineShoppingCartApp.BLL;

namespace OnlineShoppingCartApp.UI
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonSignup_Click(object sender, EventArgs e)
        {
            User aUser = new User();
            aUser.UserName = textBoxUserName.Text;
            aUser.Password = textBoxPassword.Text;
            aUser.Name = textBoxName.Text;
            aUser.Email = textBoxEmail.Text;
            UserBusinessLogic aUserBusinessLogic = new UserBusinessLogic();
            lblMsg.ForeColor = Color.Green;
            lblMsg.Text = aUserBusinessLogic.addUser(aUser);
            Response.Redirect("SignIn.aspx");
        }
    }
}