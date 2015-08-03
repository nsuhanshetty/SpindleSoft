using System;
using System.Collections.Generic;

namespace SpindleSoft.Model
{
    public class Alteration
    {
        public virtual int ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DateTime PromisedDate { get; set; }

        public virtual int TotalPrice { get; set; }

        public virtual int CurrentPayment { get; set; }

        public virtual int Status { get; set; }

        public virtual IList<AlterationItem> AlterationItems { get; set; }

        public Alteration() { }

        public Alteration(Customer cust, DateTime promiseDate, List<AlterationItem> alterationItems, int totalPrice, int currPayment)
        {
            this.Customer = cust;
            this.PromisedDate = promiseDate;
            this.AlterationItems = alterationItems;
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

        //public virtual Orders Order { get; set; } //from where its derived

        public virtual int Price { get; set; }

        public virtual string Comment { get; set; }

        public AlterationItem() { }

        public AlterationItem(string name, int quantity, int price, string comment)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.Comment = comment;
        }
    }
}