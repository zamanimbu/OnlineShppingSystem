using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCartApp.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int GenderId { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string MaterialCare { get; set; }
        public int FreeDelivery { get; set; }
        public int DaysReturn { get; set; }
        public int Cod { get; set; }
    }
}