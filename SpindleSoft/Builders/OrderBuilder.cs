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
    public class OrderBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(OrderBuilder));
        #region OrderTypeBuilder
        public static List<string> GetOrderTypeList()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<string> names = (from s in session.Query<OrderItem>()
                                          select s.Name).Distinct().ToList();
                    return names;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }
        /// <summary>
        ///  Based on the selected customer load the measurement from previous order
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="itemName"></param>
        /// <returns>OrderItem</returns>
        public static OrderItem GetOrderItem(int custId, string itemName)
        {
            OrderItem orderItem = new OrderItem();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    //todo: convert to linq
                    //order by updated date desc
                    //singleOrDefault
                    string query = ("select i.* from orderitem i, orders o where o.ID = i.OrderID and i.Name = :name and o.CustomerID = :custId");
                    var sqlQuery = session.CreateSQLQuery(query)
                                                .SetParameter("name", itemName)
                                                .SetParameter("custId", custId)
                                                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(OrderItem)));
                    log.Info(sqlQuery as OrderItem);
                    return orderItem = sqlQuery as OrderItem;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }

        //public static List<OrderType> GetOrderTypeList()
        //{
        //    List<OrderType> orderTypeList = new List<OrderType>();
        //    try
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            NHibernate.IQuery sqlQuery = session.CreateSQLQuery("select id,name,price from ordertype ").SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(OrderType)));
        //            return orderTypeList = sqlQuery.List<OrderType>() as List<OrderType>;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //todo: log4net
        //        return null;
        //    }
        //}
        #endregion OrderTypeBuilder
    }
}
