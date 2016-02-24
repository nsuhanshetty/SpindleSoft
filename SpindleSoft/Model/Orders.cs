using System;
using System.Collections.Generic;

namespace SpindleSoft.Model
{
    public class Orders
    {
        public virtual int ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual int TotalPrice { get; set; }

        public virtual int CurrentPayment { get; set; }

        public virtual DateTime PromisedDate { get; set; }

        public virtual int Status { get; set; }

        public virtual IList<OrderItem> OrdersItems { get; set; }

        //public virtual IList<AlterationItem> AlterationItems { get; set; }

        public Orders() { }

        public Orders(Customer cust, DateTime promiseDate, List<OrderItem> ordersItems, int totalPrice, int currPayment, int status)
        {
            this.Customer = cust;
            this.PromisedDate = promiseDate;
            this.OrdersItems = ordersItems;
            this.TotalPrice = totalPrice;
            this.CurrentPayment = currPayment;
            this.Status = status;
        }
    }

    public class OrderItem
    {
        public virtual int ID { get; set; }

        public virtual Orders Order { get; set; }

        public virtual string Name { get; set; }

        public virtual System.Drawing.Image Image { get; set; }

        public virtual int Quantity { get; set; }

        public virtual float Price { get; set; }

        public virtual string Length { get; set; }

        public virtual string Waist { get; set; }

        public virtual string Chest { get; set; }

        public virtual string Shoulder { get; set; }

        public virtual string Hip { get; set; }

        public virtual string D { get; set; }

        public virtual string Front { get; set; }

        public virtual string Back { get; set; }

        public virtual string BottomLength { get; set; }

        public virtual string BottomLoose { get; set; }

        public virtual string BottomWaist { get; set; }

        public virtual string BottomHip { get; set; }

        public virtual string SleeveLoose { get; set; }

        public virtual string SleeveArmHole { get; set; }

        public virtual string SleeveLength { get; set; }

        public virtual string Comment { get; set; }

        public virtual DateTime DateUpdated { get; set; }

        public virtual IList<AlterationItem> AlterationItems { get; set; }

        public virtual IList<OrderItemDocument> OrderItemDocuments { get; set; }

        public OrderItem() { }

        public OrderItem(string itemName, int price, int quantity)
        {
            this.Name = itemName;
            //this.OrderID = Convert.ToInt32(orderId);
            this.Price = price;
            this.Quantity = quantity;
        }

        public OrderItem(string name, int quantity, int price, string length, string waist,
            string shoulder, string chest, string d, string front, string back, string hip,
            string bothip, string botLen, string botWaist, string botLoose,
            string slvArmHole, string slvLen, string slvLoose, string comment)
        {
            //this.Order = orderID;
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;

            this.Length = length;
            this.Waist = waist;
            this.Chest = chest;
            this.Shoulder = shoulder;
            this.Front = front;
            this.Back = back;
            this.D = d;
            this.Hip = hip;

            this.BottomHip = bothip;
            this.BottomWaist = botWaist;
            this.BottomLength = botLen;
            this.BottomLoose = botLoose;

            this.SleeveArmHole = slvArmHole;
            this.SleeveLength = slvLen;
            this.SleeveLoose = slvLoose;

            this.Comment = comment;
        }
    }

    //todo: Remove if not used
    //public class OrderType
    //{
    //    public virtual int ID { get; set; }
    //    public virtual string Name { get; set; }
    //    public virtual int Price { get; set; }
    //    public virtual bool IsBasicMeasurement { get; set; }
    //    public virtual bool IsBottomMeasurement { get; set; }
    //    public virtual bool IsSleeveMeasurement { get; set; }

    //    public OrderType()
    //    {

    //    }

    //    public OrderType(string name, string price, bool isbasicMeasure = true, bool isbottomMeasure = false, bool issleeveMeasure = false)
    //    {
    //        // this.ID = id;
    //        this.Name = name;
    //        this.Price = Convert.ToInt32(price);
    //        this.IsBasicMeasurement = isbasicMeasure;
    //        this.IsBottomMeasurement = isbottomMeasure;
    //        this.IsSleeveMeasurement = issleeveMeasure;
    //    }
    //}

    //todo: Remove if not used
    //public class Product
    //{
    //    public int ProductId { get; set; }

    //    public string ProductType { get; set; }

    //    public string ProductName { get; set; }

    //    public string ProductOptionID { get; set; }

    //    public string ProductOptionName { get; set; }

    //    /*audit*/

    //    public DateTime CreatedDate { get; set; }

    //    public DateTime ModifieddDate { get; set; }
    //}
}