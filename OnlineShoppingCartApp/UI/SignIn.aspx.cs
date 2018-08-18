using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.BLL;

namespace OnlineShoppingCartApp.UI
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Response.Cookies["UserName"] != null && Response.Cookies["Password"] != null)
                {
                    userNameTextBox.Text = Response.Cookies["UserName"].Value;
                    passwordTextBox.Attributes["value"] = Response.Cookies["Password"].Value;
                    rememberCheckBox.Checked = true;
                }
            }
        }
        UserBusinessLogic aUserBusinessLogic = new UserBusinessLogic();
        protected void logInButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            bool isUserNameExist = aUserBusinessLogic.IsUserExist(userName, password);
            string userType = aUserBusinessLogic.CheackRole(userName, password);
            if (isUserNameExist)
            {
                if (rememberCheckBox.Checked)
                {
                    Response.Cookies["UserName"].Value = userNameTextBox.Text;
                    Response.Cookies["Password"].Value = passwordTextBox.Text;

                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);

                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                }

                if (userType == "U")
                {
                    Session["UserName"] = userNameTextBox.Text;
                    Response.Redirect("UserHome.aspx");
                }
                if (userType == "A")
                {
                    Session["UserName"] = userNameTextBox.Text;
                    Response.Redirect("Admin.aspx");
                }
                

            }
            else
            {
                lblError.Text = "Invalid User Name or Password";
            }

        }

        
    }
}