using log4net;
using Newtonsoft.Json;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SpindleSoft.Savers
{
    public class PeoplePracticeSaver
    {
        static ILog log = LogManager.GetLogger(typeof(PeoplePracticeSaver));

        static string CustomerImagePath = "d:\\CustomerImages";
        static string StaffImagePath = "d:\\StaffImages";
        static string DocumentImagePath = "d:\\DocumentImages";

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
            string filePath = string.Format("{0}\\{1}.png", CustomerImagePath, custID);
            try
            {
                if (!System.IO.Directory.Exists(CustomerImagePath))
                    System.IO.Directory.CreateDirectory(CustomerImagePath);
                else if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                image.Save(filePath);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
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
                        foreach (Document doc in staff.SecurityDocuments)
                        {
                            doc.Staff = staff;
                        }
                        session.SaveOrUpdate(staff);
                        transaction.Commit();
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

        public static bool SaveStaffImage(Image image, int _ID)
        {
            string filePath = string.Format("{0}\\{1}.png", StaffImagePath, _ID);
            try
            {
                if (!System.IO.Directory.Exists(StaffImagePath))
                    System.IO.Directory.CreateDirectory(StaffImagePath);
                else if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                image.Save(filePath, ImageFormat.Png);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public static bool SaveStaffDocument(List<Document> docList, int _staffID)
        {
            foreach (Document doc in docList)
            {
                string filePath = string.Format("{0}\\{2}_{1}.png", DocumentImagePath, doc.Type, _staffID);
                try
                {
                    if (!System.IO.Directory.Exists(DocumentImagePath))
                        System.IO.Directory.CreateDirectory(DocumentImagePath);
                    else if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);

                    doc.Image.Save(filePath, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return false;
                }
            }
            return true;
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

        public static bool SaveVendorInfo(Vendors vendor)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
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
