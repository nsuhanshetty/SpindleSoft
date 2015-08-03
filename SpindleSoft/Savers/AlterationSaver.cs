using log4net;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Savers
{
    public class AlterationSaver
    {
        static ILog log = LogManager.GetLogger(typeof(AlterationSaver));

        public static bool SaveAlterationInfo(Alteration _alteration)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (var item in _alteration.AlterationItems)
                        {
                            item.Alteration = _alteration;
                        }
                        session.SaveOrUpdate(_alteration);
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }

        }

        public static bool DeleteAlterationItems(int _id)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        var item = session.Get<AlterationItem>(_id);
                        session.Delete(item);
                        trans.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {

                        log.Error(ex);
                    }
                }
            }
            return success;
        }

        public static bool DeleteAlteration(int _altID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        var alt = session.Get<Alteration>(_altID);
                        session.Delete(alt);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }
    }
}
