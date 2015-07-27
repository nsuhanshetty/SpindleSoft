using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Collections;
using NHibernate;
using SpindleSoft.Model;

namespace SpindleSoft.Builders
{

    public class MainBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(MainBuilder));

        //public static IList GetReadyToStitchOrdersList()
        //{
        //    using (var session = NHibernateHelper.OpenSession())
        //    {
        //        var listOrders = from ord in ((session.QueryOver<Orders>()
        //                                     .Where(x => x.Status == 0)
        //                                     .OrderBy(x => x.PromisedDate).Asc
        //                                     .List()))
        //                         select new { ord.ID, DueDate = ord.PromisedDate };

        //        return listOrders.ToList();
        //    }
        //}

        //public static IList GetStitchInProgresstOrdersList()
        //{
        //    using (var session = NHibernateHelper.OpenSession())
        //    {
        //        var listOrders = from ord in ((session.QueryOver<Orders>()
        //                                      .Where(x => x.Status == 1)
        //                                      .OrderBy(x => x.PromisedDate).Asc
        //                                      .List()))
        //                         select new { ord.ID, DueDate = ord.PromisedDate };

        //        return listOrders.ToList();
        //    }
        //}

        public static IList GetOrdersList_BasedOnStatus(int _status)
        {
            if (_status > 2) return null;
            using (var session = NHibernateHelper.OpenSession())
            {
                var listOrders = from ord in ((session.QueryOver<Orders>()
                                              .Where(x => x.Status == _status)
                                              .OrderBy(x => x.PromisedDate).Asc
                                              .List()))
                                 select new { ord.ID, DueDate = ord.PromisedDate };

                return listOrders.ToList();
            }
        }

    }
}
