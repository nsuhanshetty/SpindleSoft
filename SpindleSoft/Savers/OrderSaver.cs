using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Drawing;
using System.Configuration;
using SpindleSoft.Utilities;

namespace SpindleSoft.Savers
{
    //todo: remove comments
    class OrderSaver
    {
        static ILog log = LogManager.GetLogger(typeof(OrderSaver));
        static string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        static string OrderItemDocPath = Secrets.FileLocation["OrderItemDocs"];

        public static bool SaveOrder(Orders order)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {

                        foreach (var item in order.OrdersItems)
                        {
                            item.Order = order;
                            foreach (var doc in item.OrderItemDocuments)
                            {
                                doc.orderItem = item;
                            }
                        }
                        session.SaveOrUpdate(order);

                        List<bool> results = new List<bool>();
                        foreach (var item in order.OrdersItems)
                        {
                            foreach (var doc in item.OrderItemDocuments)
                            {
                                if (doc.Image != null)
                                {
                                    results.Add(Utilities.ImageHelper.UploadToLocal(doc.Image, string.Format("{0}/{1}/{2}_{3}.png", baseDoc, OrderItemDocPath, item.ID, doc.Type)));
                                }
                            }
                        }

                        if (results.Contains(false))
                            return false;

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        log.Error(ex.Message);
                        System.Windows.Forms.MessageBox.Show("Message:" + ex.Message + Environment.NewLine + "InnerException:" + ex.InnerException + "Source:" + ex.Source);
                        return false;
                    }
                }
            }
        }

        //public static async Task<bool> SaveItemImage(Image image, int _ID)
        //{
        //    if (image == null) return true;
        //    string filePath = string.Format("/OrderItem_ProfilePictures/{0}.png", _ID);
        //    try
        //    {
        //        return await Utilities.ImageHelper.UploadToLocal(image, filePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        return false;
        //    }
        //}

        public static bool DeleteOrder(int _orderID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Orders ord = session.Get<Orders>(_orderID);
                        session.Delete(ord);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        tx.Rollback();
                        return false;
                    }
                }
            }
        }

        public static bool DeleteOrderItems(int _id)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        List<bool> result = new List<bool>();
                        var item = session.Get<OrderItem>(_id);
                        foreach (var doc in item.OrderItemDocuments)
                        {
                            var _filePath = string.Format("{0}/{1}/{2}_{3}.png", baseDoc, OrderItemDocPath, item.ID, doc.Type);
                            result.Add(Utilities.ImageHelper.DeleteDocumentLocal(_filePath));
                        }

                        if (result.Any(x => x == false))
                            return false;
                        session.Delete(item);
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }
            return success;
        }

        public static bool DeleteOrderItemDocument(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Document doc = session.Get<Document>(_ID);

                        string filePath = string.Format("{0}/{1}/{2}_{3}.png", baseDoc, OrderItemDocPath, _ID, doc.Type);
                        bool success = Utilities.ImageHelper.DeleteDocumentLocal(filePath);
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
