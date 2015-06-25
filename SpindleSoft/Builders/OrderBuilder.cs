using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate.Criterion;
using log4net;

namespace SpindleSoft.Builders
{
    public class OrderBuilder
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OrderBuilder));
        #region OrderTypeBuilder
        public static List<OrderItem> GetOrderTypeList()
        {
            List<OrderItem> orderTypeList = new List<OrderItem>();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    NHibernate.IQuery sqlQuery = session.CreateSQLQuery("select * from OrderItem").SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(OrderItem)));
                    return orderTypeList = sqlQuery.List<OrderItem>() as List<OrderItem>;
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

                    //string query = "select * from OrderItem o inner join orders ord on ord.ID = o.OrderID where o.name = " + itemName + " and ord.CustomerID = " + custId;

                    //Orders orderAlias = null;
                    //OrderItem itemAlias = null;

                    //var query = session.QueryOver<OrderItem>(() => itemAlias)
                    //     .JoinAlias(() => itemAlias.order, () => orderAlias)
                    //    .Where(() => orderAlias.customer.ID == custId)
                    //    .And(() => itemAlias.Name == itemName)
                    // .TransformUsing(NHibernate.Transform.Transformers.AliasToBean<OrderItem>());

                    //var query = session.CreateCriteria<OrderItem>("ord")
                    //    .CreateAlias("Orders","o")
                    //    .CreateAlias("ord.Name", "n")
                    //    .Add(Restrictions.Eq("n", itemName))
                    //    .Add(Restrictions.Eq("o.CustomerID",custId));
                    //return orderItem = query.UniqueResult<OrderItem>();

                    //NHibernate.IQuery sqlQuery = session.CreateSQLQuery(query)
                    //                            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(OrderItem)));

                    log.Info("testing and feeling awesome");
                    orderItem = (from i in session.Query<OrderItem>()
                                 join o in session.Query<Orders>() on i.Order.ID equals o.ID
                                 where (o.Customer.ID == custId && i.Name == itemName)
                                 select i).SingleOrDefault();
                    return orderItem;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
