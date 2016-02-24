﻿using FluentNHibernate.Mapping;
using SpindleSoft.Model;

namespace SpindleSoft.FluentMapping
{
    class SecurityDocumentMapping : ClassMap<SecurityDocument>
    {
        public SecurityDocumentMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.Staff)
                                    .Class<Staff>()
                                    .Column("StaffID")
                                    .Cascade.None();
            Map(x => x.Type);
        }
    }

    class OrderItemDocumentMapping : ClassMap<OrderItemDocument>
    {
        public OrderItemDocumentMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.orderItem)
                                    .Class<OrderItem>()
                                    .Column("OrderItemID")
                                    .Cascade.None();
            Map(x => x.Type);
        }
    }
}