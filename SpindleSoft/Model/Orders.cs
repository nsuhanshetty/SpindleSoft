using System;
using System.Collections.Generic;

namespace SpindleSoft.Model
{
    public class Orders
    {
        public virtual int ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual float TotalPrice { get; set; }

        public virtual int CurrentPayment { get; set; }

        public virtual DateTime PromisedDate { get; set; }

        public virtual List<OrderItem> OrdersItems { get; set; }

        //public int StatusID { get; set; }

        //public string Status { get; set; }

        /*audit*/

        //public DateTime CreatedDate { get; set; }

        //public DateTime ModifieddDate { get; set; }
    }

    public class OrderItem
    {
        public virtual int ID { get; set; }

        public virtual Orders Order { get; set; }

        public virtual string Name { get; set; }

        public virtual int Quantity { get; set; }

        public virtual float Price { get; set; }

        public virtual float Length { get; set; }

        public virtual float Waist { get; set; }

        public virtual float Chest { get; set; }

        public virtual float Shoulder { get; set; }

        public virtual float Hip { get; set; }

        public virtual float D { get; set; }

        public virtual float Front { get; set; }

        public virtual float Back { get; set; }

        public virtual float BottomLength { get; set; }

        public virtual float BottomWaist { get; set; }

        public virtual float BottomHip { get; set; }

        public virtual float SleeveLoose { get; set; }

        public virtual float SleeveArmHole { get; set; }

        public virtual float SleeveLength { get; set; }

        //public DateTime CreatedDate { get; set; }

        public virtual DateTime DateUpdated { get; set; }

        public OrderItem() { }

        public OrderItem(string name)
        {
            this.Name = name;
            //this.OrderID = Convert.ToInt32(orderId);
        }

        public OrderItem(string name, int quantity, int price, float length, float waist,
            float shoulder, float chest, float d, float front, float back, float hip, float bothip, float botLen, float botWaist,
            float slvArmHole, float slvLen, float slvLoose)
        {
            //this.OrderID = orderID;
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;

            this.Length = length;
            this.Waist = waist;
            this.Shoulder = shoulder;
            this.Chest = chest;
            this.D = d;
            this.Front = front;
            this.Back = back;
            this.Hip = hip;

            this.BottomHip = bothip;
            this.BottomLength = botLen;
            this.BottomWaist = botWaist;

            this.SleeveArmHole = slvArmHole;
            this.SleeveLength = slvLen;
            this.SleeveLoose = slvLoose;
        }
    }

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