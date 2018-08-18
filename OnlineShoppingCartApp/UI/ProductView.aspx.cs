using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.BLL;

namespace OnlineShoppingCartApp.UI
{
    public partial class ProductView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductId"] != null)
            {
                if (!IsPostBack)
                {
                    BindProductImages();
                    BindProductDetails();
                }
            }
            else
            {
                Response.Redirect("HomeProduct.aspx");
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.SignOutButton.Click += new EventHandler(signOutButton_Click);
        }
        protected void signOutButton_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("HomeProduct.aspx");
        }
        private void BindProductDetails()
        {
            int pId = Convert.ToInt32(Request.QueryString["ProductId"]);
            rptrProductDetails.DataSource = aProductBusinessLogic.BindRpeaterProductDetails(pId);
            rptrProductDetails.DataBind();

        }

        private void BindProductImages()
        {
            int pId = Convert.ToInt32(Request.QueryString["ProductId"]);
            rptrImages.DataSource = aProductBusinessLogic.BindRepeaterProductImages(pId);
            rptrImages.DataBind();
        }

        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();
        protected string GetActiveClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
                string GenderID = (e.Item.FindControl("hfGenderID") as HiddenField).Value;

                RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

                rblSize.DataSource = aProductBusinessLogic.GetRblSize(BrandID, CatID, SubCatID, GenderID);
                rblSize.DataTextField = "SizeName";
                rblSize.DataValueField = "SizeId";
                rblSize.DataBind();
            }
        }

        protected void btnAddToCart_OnClick(object sender, EventArgs e)
        {
            string SelectedSize = string.Empty;
            foreach (RepeaterItem item in rptrProductDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbList = item.FindControl("rblSize") as RadioButtonList;
                    SelectedSize = rbList.SelectedValue;

                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                }
            }

            if (SelectedSize != "")
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["ProductId"]);

                if (Request.Cookies["CartPID"] != null)
                {
                    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                    CookiePID = CookiePID + "," + PID + "-" + SelectedSize;

                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = CookiePID;
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);
                }
                else
                {
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);
                }
                Response.Redirect("ProductView.aspx?ProductId=" + PID);
            }
            else
            {
                foreach (RepeaterItem item in rptrProductDetails.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var lblError = item.FindControl("lblError") as Label;
                        lblError.Text = "Please select a size";
                    }
                }
            }
        }

    }
}