using FluentNHibernate.Mapping;
using SpindleSoft.Model;

namespace SpindleSoft.FluentMapping
{
    class DocumentMapping : ClassMap<Document>
    {
        public DocumentMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.Staff)
                                    .Class<Staff>()
                                    .Column("StaffID")
                                    .Cascade.None();
            Map(x => x.Type);
        }
    }
}
