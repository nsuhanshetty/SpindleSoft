﻿using SpindleSoft.Model;
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
        #region OrderBuilder

        /// <summary>
        /// Gets the Name of all the ordertype
        /// </summary>
        /// <returns></returns>
        public static List<string> GetListOfClothingTypes()
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
                    string query = ("select i.* from orderitem i " +
                                    "inner join orders o on o.ID = i.OrderID " +
                                    "where i.Name = :name and o.CustomerID = :custId " +
                                    "order by i.DateUpdated");
                    var sqlQuery = session.CreateSQLQuery(query)
                                                .SetParameter("name", itemName)
                                                .SetParameter("custId", custId)
                                                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(OrderItem)));
                    log.Info(sqlQuery as OrderItem);
                    return orderItem = sqlQuery as OrderItem;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public static List<Orders> GetOrdersList(string custName = "", string custMob = "", string orderId = "")
        {
            List<Orders> orderList = new List<Orders>();
            int id;
            int.TryParse(orderId, out id);
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    //todo: Update to Linq
                    NHibernate.IQuery sqlQuery = session.CreateSQLQuery("select o.ID,o.TotalPrice,o.CurrentPayment,o.PromisedDate from orders o " +
                                                "join customer c on c.ID = o.CustomerID " +
                                                "where c.Name like :custName and c.Mobile_No like :custMob " +
                                                "and o.ID like :orderId")// and o.PromisedDate = :dateOfDelivery ")
                        //.SetParameter("dateOfDelivery", dateOfDelivery.Date.ToString("yyyy-MM-dd"))
                                                .SetParameter("orderId", id == 0 ? "" + "%" : id.ToString() + "%")
                                                .SetParameter("custName", custName + "%")
                                                .SetParameter("custMob", custMob + "%")
                                                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Orders)));
                    return orderList = sqlQuery.List<Orders>() as List<Orders>;
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
                    //return query.ToList();
                    //_order.OrdersItems = query.List<OrderItem>() as List<OrderItem>;


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
