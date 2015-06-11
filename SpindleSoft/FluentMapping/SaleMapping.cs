using FluentNHibernate.Mapping;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.FluentMapping
{
    class SaleMapping
    {

    }

    class SaleItemMapping: ClassMap<SaleItem>
    {
        public SaleItemMapping()
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
        }
    }
}
