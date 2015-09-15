using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using log4net;

namespace SpindleSoft.Savers
{
    public class SalesSaver
    {
        static ILog log = LogManager.GetLogger(typeof(SalesSaver));

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
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        transaction.Rollback();
                        return false;
                    }
                }
            }


        }

        public static bool SaveSaleItemInfo(Sale sale)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        
                        foreach (SaleItem item in sale.SaleItems)
                        {
                            item.Sale = sale;
                            //session.SaveOrUpdate(item);
                        }
                       
                        //update SKU
                        foreach (SaleItem item in sale.SaleItems)
                        {
                            SKUItem sku = item.SKUItem;
                            sku.Quantity -= item.Quantity;
                            session.SaveOrUpdate(sku);
                        }
                        session.SaveOrUpdate(sale);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
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
                                           where s.ID == item.SKUItem.ID
                                           select s).Single();
                            sku.Quantity -= item.Quantity;
                            session.SaveOrUpdate(sku);
                        }
                        transaction.Commit();
                        return true;
                    }

                    catch (Exception ex)
                    {
                        log.Error(ex);
                        transaction.Rollback();
                        return false;
                        //throw;
                    }
                }
            }
        }

        public static bool DeleteSaleItems(int _id)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        var item = session.Get<SaleItem>(_id);
                        session.Delete(item);
                        trans.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        trans.Rollback();
                    }
                }
            }
            return success;
        }
    }
}
