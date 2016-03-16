using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate;
using System.Collections;

namespace SpindleSoft.Builders
{
    public class AlterationBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(AlterationBuilder));

        /// <summary>
        /// Get Alteration Based on ID
        /// </summary>
        /// <param name="altId"></param>
        /// <returns></returns>
        public static Alteration GetAlteration(int altId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Alteration alt = session.CreateCriteria<Alteration>()
                    .Add(Restrictions.IdEq(altId))
                    .SetFetchMode("AlterationItems", FetchMode.Eager)
                    .UniqueResult<Alteration>();
                return alt;
            }
        }

        /// <summary>
        ///  Get AlterationList for Register's
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobNo"></param>
        /// <param name="altId"></param>
        /// <returns></returns>
        public static IList GetAlterationList(string name = "", string mobNo = "", string altId = "")
        {
            IList altList;
            using (var session = NHibernateHelper.OpenSession())
            {
                if (mobNo == "" && name == "" && altId == "")
                {
                    return altList = (from cust in session.Query<Customer>()
                                      join alt in session.Query<Alteration>() on cust.ID equals alt.Customer.ID
                                      orderby alt.PromisedDate descending
                                      select new
                                      {
                                          AlterationID = alt.ID,
                                          CustomerName = cust.Name,
                                          MobileNo = cust.Mobile_No,
                                          alt.TotalPrice,
                                          AmountPaid = alt.CurrentPayment,
                                          PromisedDate = alt.PromisedDate.ToString("dd/MMM/yy")
                                      }).Take(25).ToList();
                }
                else
                {
                    return altList = (from alt in session.Query<Alteration>()
                                      join cust in session.Query<Customer>() on alt.Customer.ID equals cust.ID
                                      where (cust.Name.StartsWith(name) && cust.Mobile_No.StartsWith(mobNo) && alt.ID.ToString().StartsWith(altId))
                                      select new
                                      {
                                          AlterationID = alt.ID,
                                          CustomerName = cust.Name,
                                          MobileNo = cust.Mobile_No,
                                          alt.TotalPrice,
                                          AmountPaid = alt.CurrentPayment,
                                          PromisedDate = alt.PromisedDate.ToString("dd/MMM/yy")
                                      }).Take(25).ToList();
                }
            }
        }

        /// <summary>
        /// Get List Of Order ID's for particular Customer
        /// </summary>
        /// <param name="_custID">Customer ID</param>
        /// <returns></returns>
        public static List<string> GetOrderIDs(int _custID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Orders orderAlias = null;
                Customer custAlias = null;
                List<string> orderList = new List<string>();
                orderList.Add("");
                orderList.AddRange((from ord in
                                        (session.QueryOver<Orders>(() => orderAlias)
                                         .JoinAlias(() => orderAlias.Customer, () => custAlias)
                                         .Where(() => custAlias.ID == _custID)
                                         .List())
                                    select ord.ID.ToString()).ToList());
                return orderList;
            }
        }

        /// <summary>
        /// Get OrderItems
        /// </summary>
        /// <param name="_orderID"></param>
        /// <param name="custID"></param>
        /// <returns></returns>
        public static List<OrderItem> GetOrderItems(int _orderID = 0, int custID = 0)
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
                        .Future()
                        .OrderBy(o => o.DateUpdated);
                    return query.ToList();

                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    return null;
                }
            }
        }

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
                    List<string> names = new List<string>() { "" };
                    names.AddRange((from s in session.Query<AlterationItem>()
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
    }
}
