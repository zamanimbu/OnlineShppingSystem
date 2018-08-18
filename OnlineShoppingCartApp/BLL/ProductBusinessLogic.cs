using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.Model;
using OnlineShoppingCartApp.DAL;
namespace OnlineShoppingCartApp.BLL
{
    public class ProductBusinessLogic
    {
        ProductDataAccess aProductDataAccess = new ProductDataAccess();
        public string AddBrand(Brand aBrand)
        {
            int rowEffected = aProductDataAccess.AddBrand(aBrand);

            if (rowEffected > 0)
            {
                return "Save SuccessFully";
            }
            else
            {
                return "Save Failed";
            }
        }

        public string AddCategory(Category aCategory)
        {
            int rowEffected = aProductDataAccess.AddCategory(aCategory);

            if (rowEffected > 0)
            {
                return "Save SuccessFully";
            }
            else
            {
                return "Save Failed";
            }
        }


        public List<Category> GetAllCategories()
        {
            return aProductDataAccess.GetAllCategories();
        }

        public string AddSubCategory(SubCategory aSubCategory)
        {
            int rowEffected = aProductDataAccess.AddSubCategory(aSubCategory);

            if (rowEffected > 0)
            {
                return "Save SuccessFully";
            }
            else
            {
                return "Save Failed";
            }
        }

        public List<Brand> GetAllBrands()
        {
            return aProductDataAccess.GetAllBrands();
        }

        public List<SubCategory> GetAllSubCategories()
        {
            return aProductDataAccess.GetAllSubCategories();
        }

        public List<Gender> GetAllGenders()
        {
            return aProductDataAccess.GetAllGenders();
        }

        public List<SubCategory> GetAllSubCategoriesByCategory(int mainCategoryId)
        {
            return aProductDataAccess.GetAllSubCategoriesByCategory(mainCategoryId);
        }

        public string AddSize(Size aSize)
        {
            SqlParameter[] aSqlParameter = new SqlParameter[5];

            aSqlParameter[0] = new SqlParameter("@SizeName",SqlDbType.VarChar);
            aSqlParameter[0].Value = aSize.SizeName;

            aSqlParameter[1] = new SqlParameter("@BrandId", SqlDbType.Int);
            aSqlParameter[1].Value = aSize.BrandId;

            aSqlParameter[2] = new SqlParameter("@CategoryId", SqlDbType.Int);
            aSqlParameter[2].Value = aSize.CategoryId;

            aSqlParameter[3] = new SqlParameter("@SubCategoryId", SqlDbType.Int);
            aSqlParameter[3].Value = aSize.SubCategoryId;

            aSqlParameter[4] = new SqlParameter("@GenderId", SqlDbType.Int);
            aSqlParameter[4].Value = aSize.GenderId;

            int rowEffected = aProductDataAccess.AddSize(aSqlParameter);

            if (rowEffected > 0)
            {
                return "Save SuccessFully";
            }
            else
            {
                return "Save Failed";
            }
        }

        public DataTable GetAllRepeaterCategory()
        {
            return aProductDataAccess.GetAllRepeaterCategory();
        }

        public DataTable GetAllRepeaterSIze()
        {
            return aProductDataAccess.GetAllRepeaterSIze().Tables[0];
        }


        public DataTable GetAllSelectedSize(int brandId, int categoryId, int subCategoryId, int genderId)
        {
            return aProductDataAccess.GetAllSelectedSize(brandId, categoryId, subCategoryId, genderId).Tables[0];
        }

        

        public string AddProduct(Product aProduct, CheckBoxList sizeCheackBoxList, TextBox quantityTextBox, FileUpload fileUploadImage01, FileUpload fileUploadImage02, FileUpload fileUploadImage03, FileUpload fileUploadImage04, FileUpload fileUploadImage05)
        {
            SqlParameter[] aSqlParameter = new SqlParameter[13];

            aSqlParameter[0] = new SqlParameter("@ProductName", SqlDbType.VarChar);
            aSqlParameter[0].Value = aProduct.ProductName;

            aSqlParameter[1] = new SqlParameter("@Price", SqlDbType.Decimal);
            aSqlParameter[1].Value = aProduct.Price;

            aSqlParameter[2] = new SqlParameter("@SellingPrice", SqlDbType.Decimal);
            aSqlParameter[2].Value = aProduct.SellingPrice;

            aSqlParameter[3] = new SqlParameter("@BrandId", SqlDbType.Int);
            aSqlParameter[3].Value = aProduct.BrandId;

            aSqlParameter[4] = new SqlParameter("@CategoryId", SqlDbType.Int);
            aSqlParameter[4].Value = aProduct.CategoryId;

            aSqlParameter[5] = new SqlParameter("@SubCategoryId", SqlDbType.Int);
            aSqlParameter[5].Value = aProduct.SubCategoryId;

            aSqlParameter[6] = new SqlParameter("@GenderId", SqlDbType.Int);
            aSqlParameter[6].Value = aProduct.GenderId;

            aSqlParameter[7] = new SqlParameter("@Description", SqlDbType.VarChar);
            aSqlParameter[7].Value = aProduct.Description;

            aSqlParameter[8] = new SqlParameter("@Details", SqlDbType.VarChar);
            aSqlParameter[8].Value = aProduct.Details;

            aSqlParameter[9] = new SqlParameter("@MaterialCare", SqlDbType.VarChar);
            aSqlParameter[9].Value = aProduct.MaterialCare;

            aSqlParameter[10] = new SqlParameter("@FreeDelivery", SqlDbType.Int);
            aSqlParameter[10].Value = aProduct.FreeDelivery;

            aSqlParameter[11] = new SqlParameter("@DaysReturn", SqlDbType.Int);
            aSqlParameter[11].Value = aProduct.DaysReturn;

            aSqlParameter[12] = new SqlParameter("@Cod", SqlDbType.Int);
            aSqlParameter[12].Value = aProduct.Cod;

            int rowEffected = aProductDataAccess.AddProduct(aProduct,aSqlParameter,sizeCheackBoxList,quantityTextBox, fileUploadImage01, fileUploadImage02, fileUploadImage03,
                fileUploadImage04, fileUploadImage05);

            if (rowEffected > 0)
            {
                return "Save SuccessFully";
            }
            else
            {
                return "Save Failed";
            }
        }


        public DataTable BindAllProduct()
        {
            return aProductDataAccess.BindAllProduct().Tables[0];
        }


        public DataTable GetRblSize(string brandId, string catId, string subCatId, string genderId)
        {
            return aProductDataAccess.GetRblSize(brandId,catId,subCatId,genderId);
        }

        public DataTable BindRepeaterProductImages(int pId)
        {
            return aProductDataAccess.BindRepeaterProductImages(pId);
        }

        public DataTable BindRpeaterProductDetails(int pId)
        {
            return aProductDataAccess.BindRpeaterProductDetails(pId);
        }

        public string SaveOrder(int pid, int sizeId, string userName)
        {
            int rowEffected =  aProductDataAccess.SaveOrder(pid, sizeId, userName);

            if (rowEffected>0)
            {
                return "Order Sent";
            }
            else
            {
                return "Order CouldNot save";
            }
        }
    }
}