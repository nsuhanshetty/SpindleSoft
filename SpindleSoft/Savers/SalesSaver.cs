using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using log4net;
using System.Configuration;
using SpindleSoft.Utilities;

namespace SpindleSoft.Savers
{
    public class SalesSaver
    {
        static ILog log = LogManager.GetLogger(typeof(SalesSaver));
        static string baseDoc = Secrets.FileLocation["BaseDocDirectory"];

        public static bool SaveSkuItemInfo(SKUItem skuItem)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in skuItem.SKUItemDocuments)
                        {
                            item.skuItem =skuItem;
                        }
                        session.SaveOrUpdate(skuItem);

                        List<bool> results = new List<bool>();
                        string _skuItemDocPath = Secrets.FileLocation["SKUItemDocs"];
                        foreach (var doc in skuItem.SKUItemDocuments)
                        {
                            if (doc.Image != null)
                                results.Add(ImageHelper.UploadToLocal(doc.Image, string.Format("{0}/{1}/{2}_{3}.png", baseDoc, _skuItemDocPath, skuItem.ID, doc.Type)));
                        }
                         
                        if (results.Contains(false))
                            return false;

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

        public static bool DeleteSkuItem(string _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        var _item = session.Get<SKUItem>(int.Parse(_ID));
                        session.Delete(_item);
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public static bool CheckIfSKUItemSold(string ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        bool _exists = session.Query<SaleItem>().Any(x => x.SKUItem.ID.ToString() == ID);
                        if (_exists)
                            return false;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        trans.Rollback();
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

        public static bool DeleteSale(int _id)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        var item = session.Get<Sale>(_id);
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

        public static bool DeleteSKUItemDocument(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        string OrderItemDocPath = Secrets.FileLocation["OrderItemDocs"];
                        Document doc = session.Get<Document>(_ID);
                        string filePath = string.Format("{0}/{1}/{2}_{3}.png", baseDoc, OrderItemDocPath, _ID, doc.Type);

                        bool success = ImageHelper.DeleteDocumentLocal(filePath);
                        if (!success)
                            return false;
                        session.Delete(doc);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }
    }
}
