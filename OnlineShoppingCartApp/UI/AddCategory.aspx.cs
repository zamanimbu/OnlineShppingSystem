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
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignOutButton.Visible = false;
            if (!IsPostBack)
            {
                FillRepeater();
            }
            
        }
        ProductBusinessLogic aBusinessLogic = new ProductBusinessLogic();

        private void FillRepeater()
        {
            repeaterCategory.DataSource = aBusinessLogic.GetAllCategories();
            repeaterCategory.DataBind();
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
        protected void addCategoryButton_OnClick(object sender, EventArgs e)
        {
            Category aCategory = new Category();
            aCategory.CategoryName = categoryNameTextBox.Text;
            messageLabel.ForeColor = Color.Green;
            messageLabel.Text = aBusinessLogic.AddCategory(aCategory);
            ClearSection();
        }

        private void ClearSection()
        {
            categoryNameTextBox.Text = string.Empty;
            FillRepeater();
        }
    }
}