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
}
