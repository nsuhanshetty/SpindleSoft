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

        public static bool SaveBackUpLog(BackUpLog bkLog)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(bkLog);
                    transaction.Commit();
                    return true;
                }
            }
        }
    }

    static class SMSSaver
    {
        public static bool SaveSMSLog(SMSLog sms)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(sms);
                    transaction.Commit();
                    return true;
                }
            }
        }
    }
}
