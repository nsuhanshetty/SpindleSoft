using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Builders
{
    public class OrderBuilder
    {
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
                    string query = "select * from OrderItem o inner join orders ord on ord.ID = o.OrderID where o.name = " + itemName + " and ord.CustomerID = " + custId;
                    NHibernate.IQuery sqlQuery = session.CreateSQLQuery(query)
                                                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(OrderItem)));
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
