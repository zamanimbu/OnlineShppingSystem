using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.BLL;

namespace OnlineShoppingCartApp.UI
{
    public partial class HomeProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllProduct();
                SignOutButton.Visible = false;
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
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();
        private void BindAllProduct()
        {
            rptrProducts.DataSource = aProductBusinessLogic.BindAllProduct();
            rptrProducts.DataBind();
        }
    }
}