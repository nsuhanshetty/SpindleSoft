using log4net;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Savers
{
    public class MainSaver
    {
        static ILog log = LogManager.GetLogger(typeof(MainSaver));

        public static bool UpdateOrderStatus(int _id, int _status)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Orders ord = session.Get<Orders>(_id);
                        ord.Status = _status;
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return true;
                    }
                }
            }

        }
    }
}
