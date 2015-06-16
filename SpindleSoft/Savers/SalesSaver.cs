using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Savers
{
    public class SalesSaver
    {
        public static bool SaveSaleItemInfo(SKUItem saleItem)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(saleItem);
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return false;
            }

        }
    }
}
