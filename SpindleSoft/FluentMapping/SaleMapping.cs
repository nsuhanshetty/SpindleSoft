using FluentNHibernate.Mapping;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.FluentMapping
{
    class SKUItemMapping : ClassMap<SKUItem>
    {
        public SKUItemMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.ProductCode);
            Map(x => x.Description);
            Map(x => x.Color);
            Map(x => x.CostPrice);
            Map(x => x.SellingPrice);
            Map(x => x.Material);
            Map(x => x.IsSelfMade);
            Map(x => x.Size);
            Map(x => x.VendorID);
            Map(x => x.Quantity);
        }
    }

    class SaleMapping : ClassMap<Sale>
    {
        public SaleMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.Customer).Class<Customer>()
                                       .Columns("CustomerID"); ;
            Map(x => x.TotalPrice);
            Map(x => x.AmountPaid);
            Map(x => x.DateOfSale);
            HasMany(x => x.SaleItems).KeyColumn("SaleID")
                                        .Inverse()
                                        .Cascade.All();
        }
    }

    class SaleItemMapping : ClassMap<SaleItem>
    {
        public SaleItemMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.SKUItem).Class<SKUItem>()
                                   .Columns("SkuID")
                                   .Cascade.None(); ;
            References(x => x.Sale).Class<Sale>()
                                   .Columns("SaleID")
                                   .Cascade.None();
            Map(x => x.Quantity);
            Map(x => x.Price);
            //Map(x => x.DateOfUpdate);
        }
    }
}
