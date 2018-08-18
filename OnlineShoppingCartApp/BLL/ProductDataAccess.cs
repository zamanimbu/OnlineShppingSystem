using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Hosting;
using System.Web.UI.WebControls;
using OnlineShoppingCartApp.DAL;
using OnlineShoppingCartApp.Model;

namespace OnlineShoppingCartApp.BLL
{
    public class ProductDataAccess : Gateway
    {
        public int AddBrand(Brand aBrand)
        {
            Query = "insert into Brand values('" + aBrand.BrandName + "') ";
            Command.CommandText = Query;
            Connection.Open();
            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;
        }

        public int AddCategory(Category aCategory)
        {
            Query = "insert into Category values('" + aCategory.CategoryName + "') ";
            Command.CommandText = Query;
            Connection.Open();
            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            Query = "select * from Category";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Category aCategory = new Category
                {
                    CategoryId = Convert.ToInt32(Reader["CategoryId"]),
                    CategoryName = Reader["CategoryName"].ToString()
                };
                categories.Add(aCategory);
            }
            Reader.Close();
            Connection.Close();
            return categories;
        }

        public int AddSubCategory(SubCategory aSubCategory)
        {
            Query = "insert into SubCategory values('" + aSubCategory.SubCategoryName + "', '" + aSubCategory.CategoryId + "') ";
            Command.CommandText = Query;
            Connection.Open();
            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;
        }

        public List<Brand> GetAllBrands()
        {
            List<Brand> brands = new List<Brand>();
            Query = "select * from Brand";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Brand aBrand = new Brand
                {
                    BrandName = Reader["BrandName"].ToString(),
                    BrandId = Convert.ToInt32(Reader["BrandId"])
                };
                brands.Add(aBrand);
            }
            Reader.Close();
            Connection.Close();
            return brands;
        }

        public List<SubCategory> GetAllSubCategories()
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            Query = "select * from SubCategory";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                SubCategory aSubCategory = new SubCategory
                {
                    SubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]),
                    SubCategoryName = Reader["SubCategoryName"].ToString()
                };
                subCategories.Add(aSubCategory);
            }
            Reader.Close();
            Connection.Close();
            return subCategories;
        }

        public List<Gender> GetAllGenders()
        {
            List<Gender> genders = new List<Gender>();
            Query = "select * from Gender";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Gender aGender = new Gender
                {
                    GenderId = Convert.ToInt32(Reader["GenderId"]),
                    GenderName = Reader["GenderName"].ToString()
                };
                genders.Add(aGender);
            }
            Reader.Close();
            Connection.Close();
            return genders;
        }

        public List<SubCategory> GetAllSubCategoriesByCategory(int mainCategoryId)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            Query = "select * from SubCategory where CategoryId = '" + mainCategoryId + "'";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                SubCategory aSubCategory = new SubCategory
                {
                    SubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]),
                    SubCategoryName = Reader["SubCategoryName"].ToString()
                };
                subCategories.Add(aSubCategory);
            }
            Reader.Close();
            Connection.Close();
            return subCategories;
        }

        public int AddSize(SqlParameter[] aSqlParameter)
        {
            int rowEffected = 0;
            Command = new SqlCommand("spInsertSize", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddRange(aSqlParameter);
            Connection.Open();
            rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;
        }

        public DataTable GetAllRepeaterCategory()
        {
            Query = "select A.*,B.* from SubCategory A inner join Category B on B.CategoryId=A.CategoryId";
            Command.CommandText = Query;
            Connection.Open();
            SqlDataAdapter aSqlDataAdapter = new SqlDataAdapter(Command);
            DataTable aDataTable = new DataTable();
            aSqlDataAdapter.Fill(aDataTable);
            Connection.Close();
            return aDataTable;
        }

        public DataSet GetAllRepeaterSIze()
        {
            DataSet aDataSet = new DataSet();

            Command = new SqlCommand("spRepeaterSize", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Connection.Open();
            SqlDataAdapter aDataAdapter = new SqlDataAdapter(Command);
            aDataAdapter.Fill(aDataSet);
            Connection.Close();
            return aDataSet;
        }

        public DataSet GetAllSelectedSize(int brandId, int categoryId, int subCategoryId, int genderId)
        {
            DataSet aDataSet = new DataSet();
            Command = new SqlCommand("spGetSelectedSize", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add("@BrandId", SqlDbType.Int).Value = brandId;
            Command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
            Command.Parameters.Add("@SubCategoryId", SqlDbType.Int).Value = subCategoryId;
            Command.Parameters.Add("@GenderId", SqlDbType.Int).Value = genderId;

            Connection.Open();
            SqlDataAdapter aDataAdapter = new SqlDataAdapter(Command);
            aDataAdapter.Fill(aDataSet);
            Connection.Close();
            return aDataSet;
        }

        //public int AddProduct(SqlParameter[] aSqlParameter)
        //{

        //}

        public int AddProduct(Product aProduct, SqlParameter[] aSqlParameter, CheckBoxList sizeCheackBoxList, TextBox quantityTextBox, FileUpload fileUploadImage01, FileUpload fileUploadImage02, FileUpload fileUploadImage03, FileUpload fileUploadImage04, FileUpload fileUploadImage05)
        {
            int rowEffected = 0;
            Command = new SqlCommand("spInsertProduct", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddRange(aSqlParameter);
            Connection.Open();
            Int32 productId = Convert.ToInt32(Command.ExecuteScalar());
            for (int i = 0; i < sizeCheackBoxList.Items.Count; i++)
            {
                if (sizeCheackBoxList.Items[i].Selected == true)
                {
                    int sizeId = Convert.ToInt32(sizeCheackBoxList.Items[i].Value);
                    int quantity = Convert.ToInt32(quantityTextBox.Text);

                    SqlCommand command = new SqlCommand("insert into ProductSizeQuantity values('" + productId + "','" + sizeId + "','" + quantity + "')", Connection);
                    command.ExecuteNonQuery();
                }
            }

            if (fileUploadImage01.HasFile)
            {
                string SavePath = HostingEnvironment.MapPath("~/Image/ProductImages/") + productId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fileUploadImage01.PostedFile.FileName);
                fileUploadImage01.SaveAs(SavePath + "\\" + aProduct.ProductName.Trim() + "01" + Extention);

                Command = new SqlCommand("insert into ProductImage values('" + productId + "','" + aProduct.ProductName.Trim() + "01" + "','" + Extention + "')",Connection);
                Command.ExecuteNonQuery();
            }
            if (fileUploadImage02.HasFile)
            {
                string SavePath = HostingEnvironment.MapPath("~/Image/ProductImages/") + productId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fileUploadImage02.PostedFile.FileName);
                fileUploadImage02.SaveAs(SavePath + "\\" + aProduct.ProductName.Trim() + "02" + Extention);

                Command = new SqlCommand("insert into ProductImage values('" + productId + "','" + aProduct.ProductName.Trim() + "02" + "','" + Extention + "')",Connection);
                Command.ExecuteNonQuery();
            }
            if (fileUploadImage03.HasFile)
            {
                string SavePath = HostingEnvironment.MapPath("~/Image/ProductImages/") + productId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fileUploadImage03.PostedFile.FileName);
                fileUploadImage03.SaveAs(SavePath + "\\" + aProduct.ProductName.Trim() + "03" + Extention);

                Command = new SqlCommand("insert into ProductImage values('" + productId + "','" + aProduct.ProductName.Trim() + "03" + "','" + Extention + "')",Connection);
                Command.ExecuteNonQuery();
            }
            if (fileUploadImage04.HasFile)
            {
                string SavePath = HostingEnvironment.MapPath("~/Image/ProductImages/") + productId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fileUploadImage04.PostedFile.FileName);
                fileUploadImage04.SaveAs(SavePath + "\\" + aProduct.ProductName.Trim() + "04" + Extention);

                Command = new SqlCommand("insert into ProductImage values('" + productId + "','" + aProduct.ProductName.Trim() + "04" + "','" + Extention + "')",Connection);
                Command.ExecuteNonQuery();
            }
            if (fileUploadImage05.HasFile)
            {
                string SavePath = HostingEnvironment.MapPath("~/Image/ProductImages/") + productId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fileUploadImage05.PostedFile.FileName);
                fileUploadImage05.SaveAs(SavePath + "\\" + aProduct.ProductName.Trim() + "05" + Extention);

                Command = new SqlCommand("insert into ProductImage values('" + productId + "','" + aProduct.ProductName.Trim() + "05" + "','" + Extention + "')",Connection);
                Command.ExecuteNonQuery();
            }
            Connection.Close();

            if (productId > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }


        public DataSet BindAllProduct()
        {
            DataSet aDataSet = new DataSet();

            Command = new SqlCommand("spBindAllProduct", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Connection.Open();
            SqlDataAdapter aDataAdapter = new SqlDataAdapter(Command);
            aDataAdapter.Fill(aDataSet);
            Connection.Close();
            return aDataSet;
        }

        

        public DataTable GetRblSize(string brandId, string catId, string subCatId, string genderId)
        {
            Query = "select * from Size where BrandId=" + brandId +
                    " and CategoryId=" + catId + " and SubCategoryId=" + subCatId +
                    " and GenderId=" + genderId + "";
            Command.CommandText = Query;
            Connection.Open();
            SqlDataAdapter aSqlDataAdapter = new SqlDataAdapter(Command);
            DataTable aDataTable = new DataTable();
            aSqlDataAdapter.Fill(aDataTable);
            Connection.Close();
            return aDataTable;
        }

        public DataTable BindRepeaterProductImages(int pId)
        {
            Query = "select * from ProductImage where ProductId=" + pId + "";
            Command.CommandText = Query;
            Connection.Open();
            SqlDataAdapter aSqlDataAdapter = new SqlDataAdapter(Command);
            DataTable aDataTable = new DataTable();
            aSqlDataAdapter.Fill(aDataTable);
            Connection.Close();
            int dt = aDataTable.Rows.Count;
            return aDataTable;
        }

        public DataTable BindRpeaterProductDetails(int pId)
        {
            Query = "select * from Product where ProductId=" + pId + "";
            Command.CommandText = Query;
            Connection.Open();
            SqlDataAdapter aSqlDataAdapter = new SqlDataAdapter(Command);
            DataTable aDataTable = new DataTable();
            aSqlDataAdapter.Fill(aDataTable);
            Connection.Close();
            return aDataTable;
        }

        public int SaveOrder(int pid, int sizeId, string userName)
        {
            Query = "insert into [Order] values('"+pid+"','"+sizeId+"','"+userName+"')";

            Command.CommandText = Query;
            Connection.Open();
            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;

        }
    }
}