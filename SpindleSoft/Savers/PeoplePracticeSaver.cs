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
        //private static Uri BaseUri = new Uri("http://192.168.0.106:14041");
        //private static Uri BaseUri = new Uri(System.Configuration.ConfigurationManager.AppSettings.Get("BaseUri"));

        static string CustomerImagePath = "d:\\CustomerImages";
        //System.Windows.Forms.Application.StartupPath + "\\CustomerImages";
        static string StaffImagePath = "d:\\StaffImages";
        //System.Windows.Forms.Application.StartupPath + "\\StaffImages";

        #region Customer
        public static bool SaveCustomerInfo(Customer _customer)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(_customer);
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }

        }

        public static bool SaveCustomerImage(Image image, string mobNo)
        {
            string filePath = string.Format("{0}\\{1}.png", CustomerImagePath, mobNo);
            try
            {
                if (!System.IO.Directory.Exists(CustomerImagePath))
                    System.IO.Directory.CreateDirectory(CustomerImagePath);
                else if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                image.Save(filePath);
                return true;
            }
            catch (Exception)
            {
                //todo: log4.net
                return false;
            }
        }
        #endregion Customer

        #region Staff
        public static bool SaveStaffInfo(Staff staff)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(staff);
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

        public static bool SaveStaffImage(Image image, string mobNo)
        {
            string filePath = string.Format("{0}\\{1}.png", StaffImagePath, mobNo);
            try
            {
                if (!System.IO.Directory.Exists(StaffImagePath))
                    System.IO.Directory.CreateDirectory(StaffImagePath);
                else if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                image.Save(filePath, ImageFormat.Png);
                return true;
            }
            catch (Exception)
            {
                //todo: log4.net
                return false;
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
            catch(Exception)
            {
                //log4net 
                return false;
            }
        }

        #endregion Vendor
    }
}
