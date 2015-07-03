﻿using System;
using System.Collections.Generic;

namespace SpindleSoft.Model
{
    public class Alteration
    {
        public virtual int ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DateTime PromisedDate { get; set; }

        public virtual float TotalPrice { get; set; }

        public virtual int CurrentPayment { get; set; }

        public virtual IList<AlterationItem> AlterationItems { get; set; }

        public Alteration() { }

        public Alteration(Customer cust, DateTime promiseDate, List<AlterationItem> alteration, int totalPrice, int currPayment)
        {
            this.Customer = cust;
            this.PromisedDate = promiseDate;
            this.AlterationItems = alteration;
            this.TotalPrice = totalPrice;
            this.CurrentPayment = currPayment;
        }
    }

    public class AlterationItem
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual int Quantity { get; set; }

        public virtual Alteration Alteration { get; set; } //to which it belongs

        public virtual Orders Order { get; set; } //from where its derived

        public virtual int Price { get; set; }

        public virtual string Comment { get; set; }

        public AlterationItem() { }

        public AlterationItem(string name,int quantity, Orders order)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Order = order;
        }
    }
}