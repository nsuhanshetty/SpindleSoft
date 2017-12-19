using Dropbox.Api;
using Dropbox.Api.Files;
using log4net;
using SpindleSoft.Model;
using SpindleSoft.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        static string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        static string CustomerImagePath = Secrets.FileLocation["CustomerImages"];
        static string StaffImagePath = Secrets.FileLocation["StaffImages"];
        static string StaffDocImagePath = Secrets.FileLocation["StaffDocImages"];

        #region Customer
        public static bool SaveCustomerInfo(Customer _customer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(_customer);
                        bool response = _customer.ID != 0 ? PeoplePracticeSaver.SaveCustomerImage(_customer.Image, _customer.ID) : false;
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

        public static bool SaveCustomerImage(Image image, int custID)
        {
            if (image == null) return true;
            string filePath = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, custID);
            try
            {
                return Utilities.ImageHelper.UploadToLocal(image, filePath);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public static bool DeleteCustomer(int custID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Customer cust = session.Get<Customer>(custID);
                        string _filePath = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, custID);
                        bool suceess = Utilities.ImageHelper.DeleteDocumentLocal(_filePath);
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
        public static int SaveStaffInfo(Staff staff)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (SecurityDocument doc in staff.SecurityDocuments)
                        {
                            doc.Staff = staff;
                        }

                        if (staff.Bank != null && staff.Bank.ID == 0)
                            session.SaveOrUpdate(staff.Bank);

                        session.SaveOrUpdate(staff);
                        transaction.Commit();

                        bool response = staff.ID != 0 ? SaveStaffImage(staff.Image, staff.ID) : false;
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

        public static bool DeleteStaff(int staffID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        string _filePath = string.Format("{0}/{1}/{2}.png", baseDoc, StaffImagePath, staffID);
                        bool success = Utilities.ImageHelper.DeleteDocumentLocal(_filePath);
                        Staff _staff = session.Get<Staff>(staffID);
                        if (!success)
                            return false;

                        session.Delete(_staff);
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

        public static bool SaveStaffImage(Image image, int _ID)
        {
            if (image == null) return true;
            string filePath = string.Format("{0}/{1}/{2}.png", baseDoc, StaffImagePath, _ID);
            try
            {
                return Utilities.ImageHelper.UploadToLocal(image, filePath);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        //public static async Task<bool> SaveStaffDocumentWebAsync(List<SecurityDocument> docList, int _staffID)
        //{
        //    if (docList.Count == 0) return true;

        //    try
        //    {
        //        var docListTasks = await Task.WhenAll(docList.Select(_doc => Utilities.ImageHelper.UploadToWebAsync(_doc.Image,
        //            string.Format("/staffDocument/{0}_{1}.png", _staffID, _doc.Type))));

        //        foreach (var docResult in docListTasks)
        //        {
        //            if (docResult == false) return false;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        return false;
        //    }
        //}

        public static bool SaveStaffDocumentLocal(List<SecurityDocument> docList, int _staffID)
        {
            if (docList.Count == 0) return true;

            try
            {
                foreach (var doc in docList)
                {
                    string filePath = string.Format("{0}/{1}/{2}_{3}.png", baseDoc, StaffDocImagePath, _staffID, doc.Type);
                    bool success = Utilities.ImageHelper.UploadToLocal(doc.Image, filePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public static bool DeleteStaffDocument(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Document doc = session.Get<Document>(_ID);

                        string filePath = string.Format("{0}/{1}/{2}_{3}.png", baseDoc, StaffDocImagePath, _ID, doc.Type);
                        bool suceess = Utilities.ImageHelper.DeleteDocumentLocal(filePath);
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

        public static bool DeleteVendor(int _vendID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Vendor _vend = session.Get<Vendor>(_vendID);
                        session.Delete(_vend);
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
        #endregion Vendor
    }
}
