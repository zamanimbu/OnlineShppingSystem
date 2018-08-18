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
    public partial class AddSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignOutButton.Visible = false;
            if (!IsPostBack)
            {
                GetAllCategory();
                FillRepeater();
            }
        }
        ProductBusinessLogic aBusinessLogic = new ProductBusinessLogic();

        private void FillRepeater()
        {
            categoryRepeater.DataSource = aBusinessLogic.GetAllRepeaterCategory();
            categoryRepeater.DataBind();
        }

        private void GetAllCategory()
        {
            List<Category> categories = (List<Category>)aBusinessLogic.GetAllCategories();
            categoryDropDownList.DataSource = categories;
            categoryDropDownList.DataValueField = "CategoryId";
            categoryDropDownList.DataTextField = "CategoryName";
            categoryDropDownList.DataBind();
            categoryDropDownList.Items.Insert(0, new ListItem("-Select-", ""));


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
            SubCategory aSubCategory = new SubCategory();
            aSubCategory.SubCategoryName = subCategoryNameTextBox.Text;
            aSubCategory.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedItem.Value);
            messageLabel.ForeColor = Color.Green;
            messageLabel.Text = aBusinessLogic.AddSubCategory(aSubCategory);
            ClearSection();
        }

        private void ClearSection()
        {
            subCategoryNameTextBox.Text = string.Empty;
            FillRepeater();
        }

        
    }
}