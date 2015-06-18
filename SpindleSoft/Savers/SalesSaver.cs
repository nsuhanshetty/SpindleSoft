using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace SpindleSoft.Savers
{
    public class SalesSaver
    {
        public static bool SaveSkuItemInfo(SKUItem skuItem)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(skuItem);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        //todo: log4net
                        transaction.Rollback();
                        return false;
                    }
                }
            }


        }

        public static bool SaveSaleItemInfo(Sale sale, List<SaleItem> saleItems)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(sale);
                        foreach (SaleItem item in saleItems)
                        {
                            item.SaleID = sale.ID;
                            session.SaveOrUpdate(item);
                        }

                        //update SKU
                        foreach (SaleItem item in saleItems)
                        {
                            SKUItem sku = (from s in session.Query<SKUItem>()
                                           where s.ID == item.SKUID
                                           select s).Single();
                            sku.Quantity -= item.Quantity;
                            session.SaveOrUpdate(sku);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        //todo: log4net
                        transaction.Rollback();
                        return false;
                    }
                }
            }


        }

        public static bool UpdateSKUList(List<SaleItem> saleItems)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (SaleItem item in saleItems)
                        {
                            SKUItem sku = (from s in session.Query<SKUItem>()
                                           where s.ID == item.SKUID
                                           select s).Single();
                            sku.Quantity -= item.Quantity;
                            session.SaveOrUpdate(sku);
                        }
                        transaction.Commit();
                        return true;
                    }

                    catch (Exception)
                    {
                        //todo: Log4net
                        transaction.Rollback();
                        return false;
                        //throw;
                    }
                }
            }
        }

    }
}
