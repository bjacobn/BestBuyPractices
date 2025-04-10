﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuy_CRUD
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        // Custom Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        //Read Data
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        //Create Data
        public void CreateProduct(string name, double price, int categoryID)
        {

            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID); ", new { name = name, price = price, categoryID = categoryID });
        }

        //Update Data
        public void UpdateProduct(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET name = @updatedName WHERE ProductID = @productID;", new { updatedName = updatedName, productID = productID });
        }

        //Delete Data
        public void DeleteProduct(int productID)
        {
            //Delete sequence requires primary key
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;", new { productID = productID });

            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;", new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;", new { productID = productID });
        }
    }
}

