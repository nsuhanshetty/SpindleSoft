using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Drawing;

namespace SpindleSoft.Savers
{

    class OrderSaver
    {
        static ILog log = LogManager.GetLogger(typeof(OrderSaver));
        static string OrderItemProfile = "/OrderItem_ProfilePictures";

        public static async Task<bool> SaveOrder(Orders order)
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
                            //if (item.Image != null && !await SaveItemImage(item.Image, item.ID))
                            //    return false;
                        }
                        session.SaveOrUpdate(order);

                        foreach (var item in order.OrdersItems)
                        {
                            if (item.Image != null && !await SaveItemImage(item.Image, item.ID))
                                return false;
                        }
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

        public static async Task<bool> SaveItemImage(Image image, int _ID)
        {
            if (image == null) return true;
            string filePath = string.Format("/OrderItem_ProfilePictures/{0}.png", _ID);
            try
            {
                return await Utilities.Helper.UploadAsync(image, filePath);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

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

        public static async Task<bool> DeleteOrderItems(int _id)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        var item = session.Get<OrderItem>(_id);
                        bool suceess = await Utilities.Helper.DeleteDocumentAsync("/OrderItem_ProfilePictures", _id.ToString());
                        if (!suceess)
                            return false;
                        session.Delete(item);
                        trans.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }
            return success;
        }
    }
}
