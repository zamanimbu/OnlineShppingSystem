﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCartApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}