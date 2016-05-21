using FluentNHibernate.Mapping;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.FluentMapping
{
    class SettingMapping : ClassMap<Setting>
    {
        public SettingMapping()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.Value);
        }
    }

    class BackUpLogMapping : ClassMap<BackUpLog>
    {
        public BackUpLogMapping()
        {
            Id(x => x.ID);
            Map(x => x.FileName);
            Map(x => x.DateOfUpdate);
        }
    }

    class SMSLogMapping : ClassMap<SMSLog>
    {
        public SMSLogMapping()
        {
            Id(x => x.ID);
            Map(x => x.Message);
            References(x => x.Customer).Class<Customer>()
                                       .Columns("CustomerID");
            Map(x => x.SectionID);
            Map(x => x.Status);
            Map(x => x.DateOfUpdate);
        }
    }
}
