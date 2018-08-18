using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShoppingCartApp.BLL;
using OnlineShoppingCartApp.Model;

namespace ShoppingCartApp.Test
{
    [TestClass]
    public class ProductBusinessLogicTest
    {
        ProductBusinessLogic aProductBusinessLogic = new ProductBusinessLogic();
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void AddBrandTest()
        {
            Brand aBrand = new Brand
            {
                BrandName = "Nike"
            };
            string actual = "Save SuccessFully";
            string predict = aProductBusinessLogic.AddBrand(aBrand);

            Assert.AreEqual(actual,predict);

        }
        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void AddCategoryTest()
        {
            Category aCategory = new Category
            {
                CategoryName = "Shoe"
            };
            string actual = "Save SuccessFully";
            string predict = aProductBusinessLogic.AddCategory(aCategory);

            Assert.AreEqual(actual, predict);

        }


        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetAllCategoriesTest()
        {
            Category c1 = new Category
            {
                CategoryId = 1,
                CategoryName = "Shirt"
            };
            Category c2 = new Category
            {
                CategoryId = 2,
                CategoryName = "Pant"
            };
            Category c3 = new Category
            {
                CategoryId = 3,
                CategoryName = "Panjabi"
            };
            Category c4 = new Category
            {
                CategoryId = 4,
                CategoryName = "Shoe"
            };

            List<Category> actualCategories = new List<Category>();
            actualCategories.Add(c1);
            actualCategories.Add(c2);
            actualCategories.Add(c3);
            actualCategories.Add(c4);
            List<Category> predictedCategories = aProductBusinessLogic.GetAllCategories();

            CollectionAssert.AreEqual(actualCategories.Select(x=>x.CategoryName).ToList(), predictedCategories.Select(x=>x.CategoryName).ToList());

        }


        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void AddSubCategoryTest()
        {
            SubCategory aSubCategory = new SubCategory
            {
                CategoryId = 1,
                SubCategoryName = "Half Sleve Shirt"
            };
            string actual = "Save SuccessFully";
            string predict = aProductBusinessLogic.AddSubCategory(aSubCategory);

            Assert.AreEqual(actual, predict);

        }


        [TestMethod]
        [TestCategory("ProductBusinessLogicTest")]
        public void GetAllBrandsTest()
        {
            Brand b1 = new Brand
            {
                BrandName = "Adidas"
            };
            Brand b2 = new Brand
            {
                BrandName = "Yellow"
            };
            Brand b3 = new Brand
            {
                BrandName = "Aarong"
            };
            Brand b4 = new Brand
            {
                BrandName = "Nike"
            };

            List<Brand> actualBrands = new List<Brand>();
            actualBrands.Add(b1);
            actualBrands.Add(b2);
            actualBrands.Add(b3);
            actualBrands.Add(b4);
           
            List<Brand> predictedBrands = aProductBusinessLogic.GetAllBrands();

            CollectionAssert.AreEqual(actualBrands.Select(x => x.BrandName).ToList(), predictedBrands.Select(x => x.BrandName).ToList());

        }

    }
}
