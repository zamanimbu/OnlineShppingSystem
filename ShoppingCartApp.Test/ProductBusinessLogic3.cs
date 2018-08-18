using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShoppingCartApp.BLL;
using OnlineShoppingCartApp.Model;

namespace ShoppingCartApp.Test
{
    [TestClass]
    public class ProductBusinessLogic3
    {
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]

        public void GetAllSelectedSizeTest()
        {
            DataTable predictedDataTable = aProductBusinessLogic.GetAllSelectedSize(1,1,1,1);
            int columnCount = predictedDataTable.Columns.Count;
            int rowCount = predictedDataTable.Rows.Count;
            Assert.AreEqual(2, rowCount);
            Assert.AreEqual(6, columnCount);
        }
        //[TestMethod]
        //[TestCategory("ProductBusinessLogicTest")]
        //public void AddProductTest()
        //{
        //    Product aProduct = new Product
        //    {
        //        ProductName = "Winter Shirt",
        //        Price = 5000,
        //        SellingPrice = 4500,
        //        BrandId = 1,
        //        CategoryId = 1,
        //        SubCategoryId = 1,
        //        GenderId = 1,
        //        Description = "None",
        //        Details = "None",
        //        MaterialCare = "None",
        //        FreeDelivery = 1,
        //        DaysReturn = 1,
        //        Cod = 1
        //    };
        //    string actual = "Save SuccessFully";
        //    string predicted = aProductBusinessLogic.AddProduct(aProduct);
        //}
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void BindAllProductTest()
        {
            DataTable predictedDataTable = aProductBusinessLogic.BindAllProduct();
            int columnCount = predictedDataTable.Columns.Count;
            int rowCount = predictedDataTable.Rows.Count;
            Assert.AreEqual(1, rowCount);
            Assert.AreEqual(22, columnCount);
        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetRblSizeTest()
        {
            DataTable predictedDataTable = aProductBusinessLogic.GetRblSize("1","1","1","1");
            int columnCount = predictedDataTable.Columns.Count;
            int rowCount = predictedDataTable.Rows.Count;
            Assert.AreEqual(2, rowCount);
            Assert.AreEqual(6, columnCount);
        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void BindRepeaterProductImagesTest()
        {
            DataTable predictedDataTable = aProductBusinessLogic.BindRepeaterProductImages(1);
            int columnCount = predictedDataTable.Columns.Count;
            int rowCount = predictedDataTable.Rows.Count;
            Assert.AreEqual(5, rowCount);
            Assert.AreEqual(4, columnCount);
        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void BindRpeaterProductDetailsTest()
        {
            DataTable predictedDataTable = aProductBusinessLogic.BindRpeaterProductDetails(1);
            int columnCount = predictedDataTable.Columns.Count;
            int rowCount = predictedDataTable.Rows.Count;
            Assert.AreEqual(1, rowCount);
            Assert.AreEqual(14, columnCount);
        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void SaveOrderTest()
        {
            string predicted = aProductBusinessLogic.SaveOrder(1,1,"ashraf");
            string actual = "Order Sent";
            Assert.AreEqual(actual, predicted);
        }

    }
}
