using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.BLL;
using OnlineShoppingCartApp.Model;

namespace OnlineShoppingCartApp.UI
{
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignOutButton.Visible = false;
            if (!IsPostBack)
            {
                FillRepeater();
            }
        }
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();

        private void FillRepeater()
        {
            brandRepeater.DataSource = aProductBusinessLogic.GetAllBrands();
            brandRepeater.DataBind();
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
        protected void addButton_OnClick(object sender, EventArgs e)
        {
            Brand aBrand = new Brand();
            aBrand.BrandName = brandNameTextBox.Text;
            messageLabel.ForeColor = Color.Green;
            messageLabel.Text = aProductBusinessLogic.AddBrand(aBrand);
            ClearSection();
        }

        private void ClearSection()
        {
            brandNameTextBox.Text = string.Empty;
            FillRepeater();
        }
    }
}