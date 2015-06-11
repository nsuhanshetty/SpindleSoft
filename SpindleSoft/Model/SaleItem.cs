using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Model
{
    public class SaleItem
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

        public virtual bool IsSelfMade { get; set; }
    }
}
