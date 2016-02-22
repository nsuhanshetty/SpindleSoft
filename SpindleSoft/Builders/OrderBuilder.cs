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
    public class OrderBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(OrderBuilder));
        #region OrderBuilder
        public static List<string> GetListOfClothingTypes()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<string> names = new List<string>() { "" };
                    names.AddRange((from s in session.Query<OrderItem>()
                                    select s.Name).Distinct().ToList());
                    return names;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }


        /// <summary>
        ///  Based on the selected customer load the measurement from previous order
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="itemName"></param>
        /// <returns>OrderItem</returns>
        //public static OrderItem GetOrderItem(int custId, string itemName)
        //{
        //    OrderItem orderItem = new OrderItem();
        //    try
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            //todo: convert to linq
        //            //order by updated date desc
        //            //singleOrDefault
        //            string query = ("select i.* from orderitem i " +
        //                            "inner join orders o on o.ID = i.OrderID " +
        //                            "where i.Name = :name and o.CustomerID = :custId " +
        //                            "order by i.DateUpdated");
        //            OrderItem ordItem = null;
        //            Orders ord = null;

        //            var sqlQuery = session.CreateSQLQuery(query)
        //                                        .SetParameter("name", itemName)
        //                                        .SetParameter("custId", custId)
        //                                        .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(OrderItem)));
        //            log.Info(sqlQuery as OrderItem);
        //            return orderItem = sqlQuery as OrderItem;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //        return null;
        //    }
        //}

        public static OrderItem GetOrderItem(int custID, string productName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    bool OrderExists = false;
                    if (custID != 0)
                    {
                        OrderExists = session.Query<Orders>()
                            .Any(x => (x.Customer.ID == custID));
                    }

                    if (custID != 0 && !OrderExists)
                        return null;

                    OrderItem item;
                    var list = (session.QueryOver<OrderItem>()
                                .Where(x => x.Name == productName)
                                .OrderBy(x => x.ID).Desc
                                .List<OrderItem>());
                    item = list.FirstOrDefault();
                    return item;
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    return null;
                }
            }
        }

        public static IList GetOrdersList(string custName = "", string custMob = "", string orderId = "")
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    IList orderList;
                    if (custMob == "" && custName == "" && orderId == "")
                    {
                        orderList = (from cust in session.Query<Customer>()
                                     join ord in session.Query<Orders>() on cust.ID equals ord.Customer.ID
                                     orderby ord.PromisedDate descending
                                     select new
                                        {
                                            OrderID = ord.ID,
                                            cust.Name,
                                            ord.TotalPrice,
                                            AmountPaid = ord.CurrentPayment,
                                            PromisedDate = ord.PromisedDate
                                        }).Take(25).ToList();
                    }
                    else
                    {
                        orderList = (from cust in session.Query<Customer>()
                                     join ord in session.Query<Orders>() on cust.ID equals ord.Customer.ID
                                     where (cust.Name.StartsWith(custName) && cust.Mobile_No.StartsWith(custMob) && ord.ID.ToString().StartsWith(orderId))
                                     select new
                                        {
                                            OrderID = ord.ID,
                                            cust.Name,
                                            ord.TotalPrice,
                                            AmountPaid = ord.CurrentPayment,
                                            PromisedDate = ord.PromisedDate
                                        }).Take(25).ToList();
                    }
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public static Orders GetOrderInfo(int orderID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    Orders _order = (from ord in session.Query<Orders>()
                                     where ord.ID == orderID
                                     select ord).SingleOrDefault();

                    _order.OrdersItems = session.QueryOver<OrderItem>()
                        .Where(x => x.Order.ID == orderID)
                        .Fetch(o => o.Order).Eager
                        .Future().ToList();

                    //foreach (var item in _order.OrdersItems)
                    //{
                    //    item.Image = await Utilities.Helper.GetDocumentAsync(string.Format("/OrderItem_ProfilePictures/{0}.png", item.ID));
                    //}

                    return _order;
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    return null;
                }
            }
        }

        public static List<OrderItem> GetOrderItems(int _orderID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
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



        #endregion OrderBuilder
    }
}
