using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverFramework.business_objects
{
    class Product
    {
        public Product(string productName, string categoryId, string supplierId, string unitPrice, string quantityPerUnit, string unitsInStock, string unitsOnOrder, string reorderLevel, bool discontinued)
        {
            ProductName = productName;
            CategoryId = categoryId;
            SupplierId = supplierId;
            UnitPrice = unitPrice;
            QuantityPerUnit = quantityPerUnit;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
        }
        
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string SupplierId { get; set; }
        public string UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitsInStock { get; set; }
        public string UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
