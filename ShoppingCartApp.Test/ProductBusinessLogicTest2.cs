using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShoppingCartApp.BLL;
using OnlineShoppingCartApp.Model;
using System.Xml;

namespace ShoppingCartApp.Test
{
    [TestClass]
    public class ProductBusinessLogicTest2
    {
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetAllSubCategoriesTest()
        {
            SubCategory s1 = new SubCategory
            {
                SubCategoryId = 1,
                SubCategoryName = "Polo Shirt"
               
            };
            SubCategory s2 = new SubCategory
            {
                SubCategoryId = 2,
                SubCategoryName = "Full Sleve Shirt"
                
            };
            SubCategory s3 = new SubCategory
            {
                SubCategoryId = 3,
                SubCategoryName = "Casual Pant"
               
            };
            SubCategory s4 = new SubCategory
            {
                SubCategoryId = 4,
                SubCategoryName = "Sports Pant"
                
            };
            SubCategory s5 = new SubCategory
            {
                SubCategoryId = 5,
                SubCategoryName = "Short Panjabi"
                
            };

            List<SubCategory> actualSubCategories = new List<SubCategory>();
            actualSubCategories.Add(s1);
            actualSubCategories.Add(s2);
            actualSubCategories.Add(s3);
            actualSubCategories.Add(s4);
            actualSubCategories.Add(s5);
            List<SubCategory> predictedSubCategories = aProductBusinessLogic.GetAllSubCategories();
            CollectionAssert.AreEqual(actualSubCategories.Select(x=>x.SubCategoryId).ToList(), predictedSubCategories.Select(x=>x.SubCategoryId).ToList());
            CollectionAssert.AreEqual(actualSubCategories.Select(x=>x.SubCategoryName).ToList(), predictedSubCategories.Select(x=>x.SubCategoryName).ToList());
            //CollectionAssert.AreEqual(actualSubCategories.Select(x=>x.CategoryId).ToList(), predictedSubCategories.Select(x=>x.CategoryId).ToList());

        }

        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetAllGendersTest()
        {
            Gender g1 = new Gender
            {
                GenderId = 1,
                GenderName = "Male"
            };
            Gender g2 = new Gender
            {
                GenderId = 2,
                GenderName = "Female"
            };

            List<Gender> actualGenders = new List<Gender>();
            actualGenders.Add(g1);
            actualGenders.Add(g2);
            List<Gender> predictedGenders = aProductBusinessLogic.GetAllGenders();
            CollectionAssert.AreEqual(actualGenders.Select(x=>x.GenderId).ToList(),predictedGenders.Select(x=>x.GenderId).ToList());
            CollectionAssert.AreEqual(actualGenders.Select(x=>x.GenderName).ToList(),predictedGenders.Select(x=>x.GenderName).ToList());

        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetAllSubCategoriesByCategoryTest()
        {
            SubCategory s1 = new SubCategory
            {
                SubCategoryId = 1,
                SubCategoryName = "Polo Shirt"

            };
            SubCategory s2 = new SubCategory
            {
                SubCategoryId = 2,
                SubCategoryName = "Full Sleve Shirt"

            };
            List<SubCategory> actualSubCategories = new List<SubCategory>();
            actualSubCategories.Add(s1);
            actualSubCategories.Add(s2);
            List<SubCategory> predictedSubCategories = aProductBusinessLogic.GetAllSubCategoriesByCategory(1);
            CollectionAssert.AreEqual(actualSubCategories.Select(x => x.SubCategoryId).ToList(), predictedSubCategories.Select(x => x.SubCategoryId).ToList());
            CollectionAssert.AreEqual(actualSubCategories.Select(x => x.SubCategoryName).ToList(), predictedSubCategories.Select(x => x.SubCategoryName).ToList());
        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void AddSizeTest()
        {
            Size aSize = new Size
            {
                SizeName = "S",
                BrandId = 2,
                CategoryId = 2,
                SubCategoryId = 3,
                GenderId = 2
            };

            string actual = "Save SuccessFully";
            string predict = aProductBusinessLogic.AddSize(aSize);
            Assert.AreEqual(actual,predict);
        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetAllRepeaterCategoryTest()
        {
            //DataTable actualDataTable = new DataTable();
            //actualDataTable.Columns.Add("SubCategoryId", typeof (int));
            //actualDataTable.Columns.Add("SubCategoryName", typeof (string));
            //actualDataTable.Columns.Add("CategoryId", typeof (int));
            //actualDataTable.Columns.Add("CategoryId", typeof (int));
            //actualDataTable.Columns.Add("CategoryName", typeof (string));

            //actualDataTable.Rows.Add(1, "Polo Shirt", 1,1, "Shirt");
            //actualDataTable.Rows.Add(2, "Full Sleve Shirt", 1,1, "Shirt");
            //actualDataTable.Rows.Add(3, "Casual Pant", 2,2, "Pant");
            //actualDataTable.Rows.Add(4, "Sports Pant", 2,2, "Pant");
            //actualDataTable.Rows.Add(5, "Short Panjabi", 3,3, "Panjabi");
           
            DataTable predictedDataTable = aProductBusinessLogic.GetAllRepeaterCategory();
            int count = predictedDataTable.Columns.Count;
            int row = predictedDataTable.Rows.Count;
            Assert.IsNotNull(predictedDataTable);
            Assert.AreEqual(count,5);
            Assert.AreEqual(row,5);

        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetAllRepeaterSIzeTest()
        {
            DataTable predictedDataTable = aProductBusinessLogic.GetAllRepeaterSIze();
            int columnCount = predictedDataTable.Columns.Count;
            int rowCount = predictedDataTable.Rows.Count;
            Assert.AreEqual(5, rowCount);
            Assert.AreEqual(15, columnCount);
        }


    }
}
