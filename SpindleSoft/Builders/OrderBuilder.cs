﻿using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using log4net;
using System.Collections;
using System.Configuration;
using SpindleSoft.Utilities;

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

        public static OrderItem GetOrderItemLatestMeasurementBasedonProdName(int custID, string productName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    OrderItem item = (from ordItem in session.Query<OrderItem>()
                                      join ord in session.Query<Orders>() on ordItem.Order.ID equals ord.ID
                                      join cust in session.Query<Customer>() on ord.Customer.ID equals cust.ID
                                      where (cust.ID == custID && ordItem.Name == productName)
                                      orderby ordItem.ID descending
                                      select ordItem).ToList<OrderItem>().FirstOrDefault();

                    item.OrderItemDocuments = (from doc in session.Query<OrderItemDocument>()
                                               where doc.orderItem.ID == item.ID
                                               select doc).ToList();
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

        public static IList GetOrdersQuickList(string orderId = "")
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    IList orderList;
                    if (orderId == "")
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
                                     where (ord.ID.ToString().StartsWith(orderId))
                                     select new
                                     {
                                         OrderID = ord.ID,
                                         cust.Name,
                                         ord.TotalPrice
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
            string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
            string OrderItemDocPath = Secrets.FileLocation["OrderItemDocs"];

            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    //Orders _order = (from ord in session.Query<Orders>()
                    //                 where ord.ID == orderID
                    //                 select ord).SingleOrDefault();

                    Orders _order = (session.QueryOver<Orders>()
                                     .Where(x => x.ID == orderID)
                                     .Fetch(x => x.Customer).Eager).SingleOrDefault();

                    _order.OrdersItems = session.QueryOver<OrderItem>()
                        .Where(x => x.Order.ID == orderID)
                        .Fetch(o => o.Order).Eager
                        .Future().ToList();

                    foreach (var item in _order.OrdersItems)
                    {
                        item.OrderItemDocuments = session.QueryOver<OrderItemDocument>()
                            .Where(x => x.orderItem.ID == item.ID)
                            .Fetch(o => o.orderItem).Eager
                            .Future().ToList();
                    }

                    foreach (var item in _order.OrdersItems)
                    {
                        foreach (var doc in item.OrderItemDocuments)
                        {
                            doc.Image = Utilities.ImageHelper.GetDocumentLocal(string.Format("{0}/{1}/{2}_{3}.png", baseDoc, OrderItemDocPath, item.ID, doc.Type));
                        }
                    }
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

        public static List<string> GetOrderItemDocumentTypeList()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<string> _docList = (from s in session.Query<OrderItemDocument>()
                                             select s.Type).Distinct().ToList();
                    return _docList;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        /// <summary>
        /// Check if credit unpaid for a given Customer, where order has been delivered and amount not paid compeletly
        /// </summary>
        /// <param name="currentOrdID"></param>
        /// <returns></returns>
        public static List<Orders> GetCustomerOrderCredit(Orders currOrd = null)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    return (from ord in session.Query<Orders>()
                            join cust in session.Query<Customer>() on currOrd.Customer.ID equals cust.ID
                            where ord.ID != currOrd.ID && (ord.TotalPrice - ord.CurrentPayment) != 0 && ord.Status == 3
                            select ord).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        #endregion OrderBuilder
    }
}
