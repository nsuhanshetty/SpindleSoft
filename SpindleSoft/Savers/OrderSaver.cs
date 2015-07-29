using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SpindleSoft.Savers
{

    class OrderSaver
    {
        static ILog log = LogManager.GetLogger(typeof(OrderSaver));
        public static bool SaveOrder(Orders order)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in order.OrdersItems)
                        {
                            item.Order = order;
                        }
                        session.SaveOrUpdate(order);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        log.Error(ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool DeleteOrder(int _orderID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Orders ord = session.Get<Orders>(_orderID);
                        session.Delete(ord);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        tx.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
