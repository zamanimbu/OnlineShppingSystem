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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignOutButton.Visible = false;
            if (!IsPostBack)
            {
                FillData();
                subCategoryDropDownList.Enabled = false;
                genderDropDownList.Enabled = false;
            }
        }
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();
        private void FillData()
        {
            brandsDropDownList.DataSource = aProductBusinessLogic.GetAllBrands();
            brandsDropDownList.DataTextField = "BrandName";
            brandsDropDownList.DataValueField = "BrandId";
            brandsDropDownList.DataBind();
            brandsDropDownList.Items.Insert(0, new ListItem("-Select-", ""));

            categoryDropDownList.DataSource = aProductBusinessLogic.GetAllCategories();
            categoryDropDownList.DataTextField = "CategoryName";
            categoryDropDownList.DataValueField = "CategoryId";
            categoryDropDownList.DataBind();
            categoryDropDownList.Items.Insert(0, new ListItem("-Select-", ""));

            genderDropDownList.DataSource = aProductBusinessLogic.GetAllGenders();
            genderDropDownList.DataTextField = "GenderName";
            genderDropDownList.DataValueField = "GenderId";
            genderDropDownList.DataBind();
            genderDropDownList.Items.Insert(0, new ListItem("-Select-", ""));



        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Master.SignoutButton.Click += new EventHandler(signOutButton_Click);
        }
        protected void signOutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void categoryDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int mainCategoryId = Convert.ToInt32(categoryDropDownList.SelectedItem.Value);

            List<SubCategory> subCategories = aProductBusinessLogic.GetAllSubCategoriesByCategory(mainCategoryId);
            subCategoryDropDownList.DataSource = subCategories;
            subCategoryDropDownList.DataTextField = "SubCategoryName";
            subCategoryDropDownList.DataValueField = "SubCategoryId";
            subCategoryDropDownList.DataBind();
            subCategoryDropDownList.Items.Insert(0, new ListItem("-Select-", ""));
            subCategoryDropDownList.Enabled = true;
        }

        

        protected void genderDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int brandId = Convert.ToInt32(brandsDropDownList.SelectedItem.Value);
            int categoryId = Convert.ToInt32(categoryDropDownList.SelectedItem.Value);
            int subCategoryId = Convert.ToInt32(subCategoryDropDownList.SelectedItem.Value);
            int genderId = Convert.ToInt32(genderDropDownList.SelectedItem.Value);
            sizeCheackBoxList.DataSource = aProductBusinessLogic.GetAllSelectedSize(brandId, categoryId, subCategoryId, genderId);
            sizeCheackBoxList.DataTextField = "SizeName";
            sizeCheackBoxList.DataValueField = "SizeId";
            sizeCheackBoxList.DataBind();
        }

        protected void subCategoryDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (subCategoryDropDownList.SelectedIndex != 0)
            {
                genderDropDownList.Enabled = true;
            }
        }

        protected void addButton_OnClick(object sender, EventArgs e)
        {
            Product aProduct = new Product();
            aProduct.ProductName = nameTextBox.Text;
            aProduct.Price = Convert.ToDecimal(priceTextBox.Text);
            aProduct.SellingPrice = Convert.ToDecimal(sellingPriceTextBox.Text);
            aProduct.BrandId = Convert.ToInt32(brandsDropDownList.SelectedItem.Value);
            aProduct.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedItem.Value);
            aProduct.SubCategoryId = Convert.ToInt32(subCategoryDropDownList.SelectedItem.Value);
            aProduct.GenderId = Convert.ToInt32(genderDropDownList.SelectedItem.Value);
            aProduct.Description = descriptionTextBox.Text;
            aProduct.Details = productDetailsTextBox.Text;
            aProduct.MaterialCare = materiaAndCareTextBox.Text;
            if (freeDeliveryCheackBox.Checked == true)
            {
                aProduct.FreeDelivery = 1;
            }
            else
            {
                aProduct.FreeDelivery = 0;
            }
            if (daysReturnCheackBox.Checked == true)
            {
                aProduct.DaysReturn = 1;
            }
            else
            {
                aProduct.DaysReturn = 0;
            }
            if (codCheackBox.Checked == true)
            {
                aProduct.Cod = 1;
            }
            else
            {
                aProduct.Cod = 0;
            }

            messageLabel.ForeColor=Color.Green;
            messageLabel.Text = aProductBusinessLogic.AddProduct(aProduct,sizeCheackBoxList,quantityTextBox, fileUploadImage01, fileUploadImage02, fileUploadImage03,
                fileUploadImage04, fileUploadImage05);

        }
    }
}