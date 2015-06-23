using FluentNHibernate.Mapping;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.FluentMapping
{
    class OrdersMapping
    {
    }

        class OrdersTypeMapping : ClassMap<OrderItem>
        {
        public OrdersTypeMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.OrderID);
            Map(x => x.Price);
            Map(x => x.Quantity);
            Map(x => x.Length);
            Map(x => x.Waist);
            Map(x => x.Chest);
            Map(x => x.Shoulder);
            Map(x => x.D);
            Map(x => x.Front);
            Map(x => x.Back);
            Map(x => x.BottomLength);
            Map(x => x.BottomWaist);
            Map(x => x.BottomHip);
            Map(x => x.SleeveLoose);
            Map(x => x.SleeveArmHole);
            Map(x => x.SleeveLength);
            Map(x => x.Comment);
        }
    }
}
