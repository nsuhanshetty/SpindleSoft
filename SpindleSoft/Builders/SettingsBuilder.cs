
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using log4net;

namespace SpindleSoft.Builders
{
    static class SettingsBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(SettingsBuilder));
        public static Setting GetBaseImagePath()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        return (from s in session.Query<Setting>()
                                where s.Name == "ImageBaseFolder"
                                select s).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }

        }
    }
}
