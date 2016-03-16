using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SpindleSoft.Model;

namespace SpindleSoft.Savers
{
    static class SettingSaver
    {
        public static bool UpdateBaseImagePath(Setting _setting)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(_setting);
                    transaction.Commit();
                    return true;
                }
            }
        }
    }
}
