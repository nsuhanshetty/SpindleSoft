using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Dropbox.Api;
using System.IO;
using Dropbox.Api.Files;
using System.Collections;
using System.Configuration;
using SpindleSoft.Utilities;
//using NHibernate;

namespace SpindleSoft.Builders
{
    public class PeoplePracticeBuilder
    {
        //todo: appsettings not working for path
        //static string customerPicPath = "d:\\CustomerImages";
        //static string StaffImagePath = "d:\\StaffImages";
        //static string DocumentImagePath = "d:\\DocumentImages";

        static string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        static string CustomerImagePath = Secrets.FileLocation["CustomerImages"];
        static string StaffImagePath = Secrets.FileLocation["StaffImages"];
        static string StaffDocImagePath = Secrets.FileLocation["StaffDocImages"];


        static ILog log = LogManager.GetLogger(typeof(PeoplePracticeBuilder));

        #region CustomerBuilder
        public static IList GetCustomersList(string name = "", string mobileno = "", string phoneno = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList custList;
                if (name == "" && mobileno == "" && phoneno == "")
                {
                    custList = (from c in session.Query<Customer>()
                                join o in session.Query<Orders>() on c.ID equals o.Customer.ID
                                where o.Status != 3 /* completed Orders*/
                                orderby o.PromisedDate descending
                                select new { c.ID, c.Name, c.Mobile_No, c.Phone_No }).Distinct().Take(25).ToList();
                }
                else
                {
                    custList = (from c in session.Query<Customer>()
                                where (c.Name.StartsWith(name) && c.Mobile_No.StartsWith(mobileno) && c.Phone_No.StartsWith(phoneno))
                                select new { c.ID, c.Name, c.Mobile_No, c.Phone_No }).Take(25).ToList();
                }
                return custList;
            }
        }

        public static IList GetCustomersQuickList(string name = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList custList;
                if (name == "")
                {
                    custList = (from c in session.Query<Customer>()
                                join o in session.Query<Orders>() on c.ID equals o.Customer.ID
                                where o.Status != 3 /* completed Orders*/
                                orderby o.PromisedDate descending
                                select new { c.ID, c.Name, c.Mobile_No }).Distinct().Take(25).ToList();
                }
                else
                {
                    custList = (from c in session.Query<Customer>()
                                where (c.Name.StartsWith(name))
                                select new { c.ID, c.Name, c.Mobile_No }).Take(25).ToList();
                }
                return custList;
            }
        }

        public static Customer GetCustomerInfo(string mobNo)
        {
            Customer _cust = new Customer();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _cust = (from cust in session.Query<Customer>()
                             where cust.Mobile_No == mobNo
                             select cust).Single();
                }
                return _cust;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static Customer GetCustomerInfo(int ID)
        {
            Customer _cust = new Customer();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _cust = (from cust in session.Query<Customer>()
                             where cust.ID == ID
                             select cust).Single();
                }
                return _cust;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public static Customer GetCustomer(int custId)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    return session.Get<Customer>(custId);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public static Image GetCustomerImage(int _custID)
        {
            try
            {
                using (Image image = Image.FromFile(CustomerImagePath + "\\" + _custID + ".png"))
                {
                    Bitmap bitmap = new Bitmap(image);
                    return bitmap;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public static bool IsCustomerMobileNoUnique(string mobNo)
        {
            bool _exists;
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _exists = session.Query<Customer>().Any(x => x.Mobile_No == mobNo);
                    return _exists;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return true;
            }
        }

        #endregion CustomerBuilder

        #region Staff
        public static IList GetStaffList(string name = "", string mobNo = "", string phNo = "")
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    //staff = session.QueryOver<Staff>()
                    //     .WhereRestrictionOn(c => c.Mobile_No).IsLike(mobNo + '%')
                    //     .And(Restrictions.On<Staff>(c => c.Name).IsLike(name + '%'))
                    //     .And(Restrictions.On<Staff>(c => c.Phone_No).IsLike(phNo + '%')).List() as List<Staff>;

                    var staff = (from _staff in session.Query<Staff>()
                                 where (_staff.Name.StartsWith(name) && _staff.Mobile_No.StartsWith(mobNo) && _staff.Phone_No.StartsWith(phNo))
                                 select new { _staff.ID, _staff.Name, _staff.Mobile_No, _staff.Phone_No }).ToList();
                    return staff;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static Staff GetStaffInfo(int _ID)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    //var staff = (from _staff in session.Query<Staff>()
                    //             where _staff.ID == _ID
                    //             select _staff).SingleOrDefault();

                    var staff = session.QueryOver<Staff>()
                        .Where(x => x.ID == _ID)
                        .Fetch(x => x.Bank).Eager
                        .Future().SingleOrDefault();

                    staff.SecurityDocuments = session.QueryOver<SecurityDocument>()
                        .Where(x => (x.Staff.ID == _ID))
                        .Fetch(o => o.Staff).Eager
                        .Future().ToList();
                    return staff;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static Image GetStaffImage(int _ID)
        {
            try
            {
                using (Image image = Image.FromFile(StaffImagePath + "\\" + _ID + ".png"))
                {
                    Bitmap bitmap = new Bitmap(image);
                    return bitmap;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static List<string> GetSecurityDocumentTypeList()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<string> _docList = (from s in session.Query<SecurityDocument>()
                                             select s.Type).Distinct().ToList();
                    return _docList;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static async Task<IList<SecurityDocument>> GetDocumentListAsync(IList<SecurityDocument> docList)
        {
            using (DropboxClient dbx = new DropboxClient("DropSecretNameHere"))
            {
                try
                {
                    foreach (SecurityDocument doc in docList)
                    {

                        string dropfilePath = string.Format("/staffDocument/{0}_{1}.png", doc.Staff.ID, doc.Type);
                        var downloadedFileResponse = await dbx.Files.DownloadAsync(dropfilePath);
                        var downloadedFileStream = await downloadedFileResponse.GetContentAsStreamAsync();
                        doc.Image = Image.FromStream(downloadedFileStream);
                    }
                }
                catch (ApiException<DownloadError> apiEx)
                {
                    log.Error(apiEx);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            return docList;
        }

        public static void GetSecurityDocumentListLocal(IList<SecurityDocument> docList)
        {
            try
            {
                foreach (SecurityDocument doc in docList)
                {
                    string _fileName = string.Format("{0}/{1}/{2}_{3}.png", baseDoc, StaffDocImagePath, doc.Staff.ID, doc.Type);
                    if (File.Exists(_fileName))
                    {
                        using (var stream = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            doc.Image = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            //return docList;
        }

        public static List<string> GetDesignations()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    List<string> designationList = (from s in session.Query<Staff>()
                                                    select s.Designation).Distinct().ToList();
                    log.Info("Fetching Bank Names successfull");
                    return designationList;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }

        #endregion Staff

        #region Vendor
        public static IList GetVendorsList(string name = "", string mobileno = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var _vendList = (from vend in session.Query<Vendor>()
                                 where (vend.Name.StartsWith(name) && vend.MobileNo.StartsWith(mobileno))
                                 select new { vend.ID, vend.Name, vend.MobileNo, vend.Address }).Take(20).ToList();
                return _vendList;
            }
        }

        public static Vendor GetVendorInfo(int _ID)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var vendor = session.QueryOver<Vendor>()
                                 .Where(x => x.ID == _ID)
                                 .Fetch(x => x.Bank).Eager
                                 .Future().SingleOrDefault();
                    return vendor;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static List<string> GetVendorOfferingType(bool _section)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var offeringList = (from vend in session.Query<Vendor>()
                                        where vend.IsProduct == _section
                                        select vend.OfferingType).Distinct().ToList();

                    return offeringList;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        #endregion Vendor

        public static List<Bank> GetBankNames()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    List<Bank> bankList = session.Query<Bank>().ToList();
                    log.Info("Fetching Bank Names successfull");
                    return bankList;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }

        public static Bank GetBankByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    Bank bank = session.Query<Bank>()
                        .Where(x => x.Name == name).SingleOrDefault();

                    log.Info("Fetching Bank Names successfull");
                    return bank;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }

        public static bool IfBankExits(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    bool exists = session.Query<Bank>().Any(x => x.Name == name);
                    return exists;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return false;
                }
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
