using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace SpindleSoft.Builders
{
    class AlterationBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(AlterationBuilder));
        public static List<OrderItem> GetOrderItems(int _orderID,int custID = 0)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    //get order items belonging to that customer
                    bool OrderExists=false;
                    if (custID != 0)
                    {
                        OrderExists = session.Query<Orders>()
                            .Any(x => (x.Customer.ID == custID && x.ID == _orderID));
                    }

                    if (custID != 0 && !OrderExists) 
                        return null;

                    var query = session.QueryOver<OrderItem>()
                        .Where(x => x.Order.ID == _orderID)
                        .Fetch(o => o.Order).Eager
                        .Future();
                    return query.ToList();

                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    return null;
                }
            }
        }
    }
}
