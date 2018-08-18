using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShoppingCartApp.UI
{
    public partial class user : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
            if (Session["USERNAME"] == null)
            {
                signOutButtonMasterPage.Visible = false;
            }
            else
            {
                signOutButtonMasterPage.Visible = true;
                
            }

        }

        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;
                pCount.InnerText = ProductCount.ToString();
            }
            else
            {
                pCount.InnerText = 0.ToString();
            }
        }
        public Button SignOutButton
        {
            get { return signOutButtonMasterPage; }
            set { signOutButtonMasterPage = value; }

        }
    }
}