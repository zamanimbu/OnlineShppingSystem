using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.BLL;

namespace OnlineShoppingCartApp.UI
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SignOutButton.Visible = false;
                BindCartProducts();

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

        private void BindCartProducts()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                if (CookieDataArray.Length > 0)
                {
                    h5NoItems.InnerText = "MY CART (" + CookieDataArray.Length + " Items)";
                    DataTable dtBrands = new DataTable();
                    Int64 CartTotal = 0;
                    Int64 Total = 0;
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string PID = CookieDataArray[i].ToString().Split('-')[0];
                        string SizeID = CookieDataArray[i].ToString().Split('-')[1];

                        String CS = ConfigurationManager.ConnectionStrings["onlineShoppingDBConnection"]
                            .ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "select A.*,dbo.getSizeName(" + SizeID + ") as SizeName,"
                                + SizeID +
                                " as SizeId,SizeData.Name,SizeData.Extention from Product A cross apply( select top 1 B.Name,Extention from ProductImage B where B.ProductId=A.ProductId ) SizeData where A.ProductId="
                                + PID + "", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    sda.Fill(dtBrands);
                                }

                            }
                        }
                        CartTotal += Convert.ToInt64(dtBrands.Rows[i]["Price"]);
                        Total += Convert.ToInt64(dtBrands.Rows[i]["SellingPrice"]);
                    }
                    rptrCartProducts.DataSource = dtBrands;
                    rptrCartProducts.DataBind();
                    divPriceDetails.Visible = true;

                    spanCartTotal.InnerText = CartTotal.ToString();
                    spanTotal.InnerText = "Tk. " + Total.ToString();
                    spanDiscount.InnerText = "- " + (CartTotal - Total).ToString();
                }
                else
                {
                    //TODO Show Empty Cart
                    h5NoItems.InnerText = "Your Shopping Cart is Empty";
                    divPriceDetails.Visible = false;
                }
            }
            else
            {
                //TODO Show Empty Cart
                h5NoItems.InnerText = "Your Shopping Cart is Empty";
                divPriceDetails.Visible = false;

            }
        }


        protected void btnRemoveItem_OnClick(object sender, EventArgs e)
        {
            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
            Button btn = (Button) (sender);
            string PIDSIZE = btn.CommandArgument;

            List<String> CookiePIDList =
                CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            CookiePIDList.Remove(PIDSIZE);
            string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
            if (CookiePIDUpdated == "")
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);

            }
            else
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = CookiePIDUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);

            }
            Response.Redirect("Cart.aspx");
        }
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();
        protected void btnBuyNow_OnClick(object sender, EventArgs e)
        {
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');

            if (CookieDataArray.Length > 0 && Session["USERNAME"] != null)
            {
                h5NoItems.InnerText = "MY CART (" + CookieDataArray.Length + " Items)";
                
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string PID = CookieDataArray[i].ToString().Split('-')[0];
                    string SizeID = CookieDataArray[i].ToString().Split('-')[1];
                    string UserName = Session["USERNAME"].ToString();
                    int PId = Convert.ToInt32(PID);
                    int sizeId = Convert.ToInt32(SizeID);
                    string message = aProductBusinessLogic.SaveOrder(PId, sizeId, UserName);

                }
            }
        }
    }
}