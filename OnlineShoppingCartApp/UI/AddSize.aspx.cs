using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.BLL;
using OnlineShoppingCartApp.Model;
using Size = OnlineShoppingCartApp.Model.Size;

namespace OnlineShoppingCartApp.UI
{
    public partial class AddSize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignOutButton.Visible = false;
            if (!IsPostBack)
            {
                FillData();
                FillRepeaterSIze();
            }

        }
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();

        private void FillRepeaterSIze()
        {
            repeaterSIze.DataSource = aProductBusinessLogic.GetAllRepeaterSIze();
            repeaterSIze.DataBind();
        }


        private void FillData()
        {
            List<Brand> brands = aProductBusinessLogic.GetAllBrands();
            brandDropDownList.DataSource = brands;
            brandDropDownList.DataTextField = "BrandName";
            brandDropDownList.DataValueField = "BrandId";
            brandDropDownList.DataBind();
            brandDropDownList.Items.Insert(0, new ListItem("-Select-", ""));

            List<Category> categories = aProductBusinessLogic.GetAllCategories();
            categoryDropDownList.DataSource = categories;
            categoryDropDownList.DataTextField = "CategoryName";
            categoryDropDownList.DataValueField = "CategoryId";
            categoryDropDownList.DataBind();
            categoryDropDownList.Items.Insert(0, new ListItem("-Select-", ""));

            List<SubCategory> subCategories = aProductBusinessLogic.GetAllSubCategories();
            subCategoryDropDownList.DataSource = subCategories;
            subCategoryDropDownList.DataTextField = "SubCategoryName";
            subCategoryDropDownList.DataValueField = "SubCategoryId";
            subCategoryDropDownList.DataBind();
            subCategoryDropDownList.Items.Insert(0, new ListItem("-Select-", ""));

            List<Gender> genders = aProductBusinessLogic.GetAllGenders();
            genderDropDOwnList.DataSource = genders;
            genderDropDOwnList.DataTextField = "GenderName";
            genderDropDOwnList.DataValueField = "GenderId";
            genderDropDOwnList.DataBind();
            genderDropDOwnList.Items.Insert(0, new ListItem("-Select-", ""));

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
            Size aSize = new Size();
            aSize.SizeName = sizeNameTextBox.Text;
            aSize.BrandId = Convert.ToInt32(brandDropDownList.SelectedItem.Value);
            aSize.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedItem.Value);
            aSize.SubCategoryId = Convert.ToInt32(subCategoryDropDownList.SelectedItem.Value);
            aSize.GenderId = Convert.ToInt32(genderDropDOwnList.SelectedItem.Value);
            messageLabel.ForeColor = Color.Green;
            messageLabel.Text = aProductBusinessLogic.AddSize(aSize);

            ClearSection();
        }

        private void ClearSection()
        {
            sizeNameTextBox.Text = string.Empty;
            brandDropDownList.ClearSelection();
            categoryDropDownList.ClearSelection();
            subCategoryDropDownList.ClearSelection();
            genderDropDOwnList.ClearSelection();
            FillRepeaterSIze();
        }

        protected void categoryDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int mainCategoryId = Convert.ToInt32(categoryDropDownList.SelectedItem.Value);

            List<SubCategory> subCategories = aProductBusinessLogic.GetAllSubCategoriesByCategory(mainCategoryId);
            subCategoryDropDownList.DataSource = subCategories;
            subCategoryDropDownList.DataTextField = "SubCategoryName";
            subCategoryDropDownList.DataValueField = "SubCategoryId";
            subCategoryDropDownList.DataBind();

        }
    }
}