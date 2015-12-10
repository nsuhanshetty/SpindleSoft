using Dropbox.Api;
using Dropbox.Api.Files;
using log4net;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpindleSoft.Savers
{
    public class PeoplePracticeSaver
    {
        static ILog log = LogManager.GetLogger(typeof(PeoplePracticeSaver));

        static string CustomerImagePath = "/Customer_ProfilePictures";
        static string StaffImagePath = "/Staff_ProfilePictures";

        #region Customer
        public static async Task<bool> SaveCustomerInfo(Customer _customer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(_customer);
                        bool response = _customer.ID != 0 ? await PeoplePracticeSaver.SaveCustomerImage(_customer.Image, _customer.ID) : false;
                        if (!response)
                            return false;

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

        public static async Task<bool> SaveCustomerImage(Image image, int custID)
        {
            if (image == null) return true;
            string filePath = string.Format("{0}/{1}.png", CustomerImagePath, custID);
            try
            {
                //if (!System.IO.Directory.Exists(CustomerImagePath))
                //    System.IO.Directory.CreateDirectory(CustomerImagePath);
                //else if (System.IO.File.Exists(filePath))
                //    System.IO.File.Delete(filePath);

                //image.Save(filePath);
                return await Utilities.Helper.UploadAsync(image, filePath);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public static async Task<bool> DeleteCustomer(int custID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Customer cust = session.Get<Customer>(custID);
                        bool suceess = await Utilities.Helper.DeleteDocumentAsync(CustomerImagePath, custID.ToString());
                        if (!suceess)
                            return false;

                        session.Delete(cust);
                        
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }
        #endregion Customer

        #region Staff
        public static async Task<int> SaveStaffInfo(Staff staff)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (Document doc in staff.SecurityDocuments)
                        {
                            doc.Staff = staff;
                        }

                        if (staff.Bank != null && staff.Bank.ID == 0)
                            session.SaveOrUpdate(staff.Bank);

                        session.SaveOrUpdate(staff);
                        transaction.Commit();

                        bool response = staff.ID != 0 ? await SaveStaffImage(staff.Image, staff.ID) : false;
                        if (!response)
                            return 0;
                        return staff.ID;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return 0;
            }

        }

        public async static Task<bool> SaveStaffImage(Image image, int _ID)
        {
            if (image == null) return true;
            string filePath = string.Format("{0}/{1}.png", StaffImagePath, _ID);
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

        public static async Task<bool> SaveStaffDocument(List<Document> docList, int _staffID)
        {
            if (docList.Count == 0) return true;
            
            try
            {
                var docListTasks = await Task.WhenAll(docList.Select(_doc => Utilities.Helper.UploadAsync(_doc.Image, 
                    string.Format("/staffDocument/{0}_{1}.png", _staffID, _doc.Type))));

                foreach (var docResult in docListTasks)
                {
                    if (docResult == false) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        //private static async Task<bool> Upload(Image doc, string dropfilePath)
        //{
        //    string tempfileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
        //    doc.Save(tempfileName);

        //    using (var mem = new FileStream(tempfileName, FileMode.Open))
        //    {
        //        //todo: shift and fetch from passsword-appconfig;
        //        DropboxClient dbx = new DropboxClient("E-9ylJ5wcN0AAAAAAAAQKaAbks3oqnG3NwawDf3AsT9i8HZf0YeXHqd6p8fFjCYi");
        //        try
        //        {
        //            var updated = await dbx.Files.UploadAsync(dropfilePath, WriteMode.Overwrite.Instance, body: mem).ConfigureAwait(false);
        //            return true;
        //        }
        //        catch (ApiException<UploadError> apiEx)
        //        {
        //            log.Error(apiEx);
        //            return false;
        //        }
        //        catch (Exception ex)
        //        {
        //            log.Error(ex);
        //            return false;
        //        }
        //    }
        //}

        public static async  Task<bool> DeleteStaffDocument(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        //todo : Delete document from dropbox on delete
                        Document doc = session.Get<Document>(_ID);
                        bool suceess = await Utilities.Helper.DeleteDocumentAsync("/staffDocument", string.Format("{0}_{1}", _ID, doc.Type));
                        if (!suceess)
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

        #endregion Staff

        #region Vendor

        public static bool SaveVendorInfo(Vendor vendor)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        if (vendor.Bank != null && vendor.Bank.ID == 0)
                            session.SaveOrUpdate(vendor.Bank);

                        session.SaveOrUpdate(vendor);
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        #endregion Vendor
    }
}
