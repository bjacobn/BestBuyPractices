﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuy_CRUD
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
    }
}
