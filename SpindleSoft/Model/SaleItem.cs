﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Model
{
    public class SKUItem
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual string ProductCode { get; set; }

        public virtual string Description { get; set; }

        public virtual string Color { get; set; }

        public virtual string Size { get; set; }

        public virtual string Material { get; set; }

        public virtual int CostPrice { get; set; }

        public virtual int SellingPrice { get; set; }

        public virtual int VendorID { get; set; }

        public virtual int Quantity { get; set; }

        public virtual bool IsSelfMade { get; set; }
    }

    public class Sale
    {
        public virtual int ID { get; set; }

        public virtual int CustID { get; set; }

        public virtual List<SaleItem> SaleItems { get; set; }

        public virtual int TotalPrice { get; set; }

        public virtual int AmountPaid { get; set; }

        public virtual DateTime DateOfSale { get; set; }
    }

    public class SaleItem
    {
        public virtual int ID { get; set; }

        public virtual int SKUID { get; set; }

        public virtual int Quantity { get; set; }

        public virtual DateTime DateOfUpdate { get; set; }

        public SaleItem(){ }

        public SaleItem(int _sKUID, int _quantity)
        {
            this.SKUID = _sKUID;
            this.Quantity = _quantity;
        }
    }
}