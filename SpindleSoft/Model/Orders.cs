using System;
using System.Collections.Generic;

namespace SpindleSoft.Model
{
    internal class Orders
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public float TotalPrice { get; set; }

        public int CurrentPayment { get; set; }

        public DateTime PromisedDate { get; set; }

        public List<OrderItem> OrdersItems { get; set; }

        public int StatusID { get; set; }

        public string Status { get; set; }

        /*audit*/

        public DateTime CreatedDate { get; set; }

        public DateTime ModifieddDate { get; set; }
    }

    internal class OrderItem
    {
        public int OrderQuantity { get; set; }

        public float Price { get; set; }

        public Product Product { get; set; }

        /*audit*/

        public DateTime CreatedDate { get; set; }

        public DateTime ModifieddDate { get; set; }
    }

    internal class Product
    {
        public int ProductId { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }

        public string ProductOptionID { get; set; }

        public string ProductOptionName { get; set; }

        /*audit*/

        public DateTime CreatedDate { get; set; }

        public DateTime ModifieddDate { get; set; }
    }
}