using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate;

namespace SpindleSoft.Builders
{
    public class AlterationBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(AlterationBuilder));
        public static List<OrderItem> GetOrderItems(int _orderID, int custID = 0)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    //get order items belonging to that customer
                    bool OrderExists = false;
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

        public static List<Alteration> GetAlterationList(string name = "", string mobNo = "", string altId = "")
        {
            List<Alteration> altList = new List<Alteration>();
            int id;
            int.TryParse(altId, out id);

            using (var session = NHibernateHelper.OpenSession())
            {
                //todo : convert to Linq
                var sqlQuery = session.CreateSQLQuery("select a.ID,a.TotalPrice,a.CurrentPayment,a.PromisedDate from alteration a " +
                             "join customer c on c.ID = a.CustomerID " +
                             "where c.Name like :custname  and c.Mobile_No like :custMobNo and a.ID like :altID")
                             .SetParameter("custname",name + '%')
                             .SetParameter("custMobNo", mobNo + '%')
                             .SetParameter("altID", altId + '%')
                             .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Alteration)));
                return altList = sqlQuery.List<Alteration>() as List<Alteration>;            
            }
        }
    }
}
