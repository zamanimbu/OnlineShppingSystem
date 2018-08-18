using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCartApp.Model
{
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int GenderId { get; set; }
    }
}