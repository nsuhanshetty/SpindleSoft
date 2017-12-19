
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using log4net;
using System.Collections;

namespace SpindleSoft.Builders
{
    static class SettingsBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(SettingsBuilder));
        //todo : Rename to GetBaseResourcePath
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

        public static List<BackUpLog> GetBackUpLog()
        {
            List<BackUpLog> backUpLogList = new List<BackUpLog>();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        return (from s in session.Query<BackUpLog>()
                                orderby s.ID descending
                                select s).Take(5).ToList<BackUpLog>();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return backUpLogList;
            }
        }

        public static BackUpLog GetLastBackUpLog()
        {
            BackUpLog bkLog = new BackUpLog();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        return (from s in session.Query<BackUpLog>()
                                orderby s.ID descending
                                select s).Take(1).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return bkLog;
            }
        }
    }

    static class SMSBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(SMSBuilder));

        public static IList GetSMSLog(DateTime fromDate, DateTime toDate, string custName)
        {
            IList SMSLogList;
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //int SI = 1;
                        SMSLogList = (from s in session.Query<SMSLog>()
                                      join c in session.Query<Customer>() on s.Customer.ID equals c.ID
                                      where s.Customer.Name.StartsWith(custName) && (s.DateOfUpdate.Date >= fromDate && s.DateOfUpdate.Date <= toDate)
                                      orderby s.ID descending
                                      select new { c.Name, s.Message, s.Status }).ToList();
                        return SMSLogList;
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
