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
//using NHibernate;

namespace SpindleSoft.Builders
{
    public class PeoplePracticeBuilder
    {
        //todo: appsettings not working for path
        static string customerPicPath = "d:\\CustomerImages";
        static string StaffImagePath = "d:\\StaffImages";
        static string DocumentImagePath = "d:\\DocumentImages";

        static ILog log = LogManager.GetLogger(typeof(PeoplePracticeBuilder));

        #region CustomerBuilder
        public static List<Customer> GetCustomersList(string name = "", string mobileno = "", string phoneno = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Customer cust = null;
                List<Customer> custList = session.QueryOver<Customer>(() => cust)
                     .Where(NHibernate.Criterion.Restrictions.On(() => cust.Name).IsLike(name + "%"))
                     .Where(NHibernate.Criterion.Restrictions.On(() => cust.Mobile_No).IsLike(mobileno + "%"))
                     .Where(NHibernate.Criterion.Restrictions.On(() => cust.Phone_No).IsLike(phoneno + "%"))
                     .List() as List<Customer>;

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
            catch (Exception)
            {
                //todo: log4net
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
                using (Image image = Image.FromFile(customerPicPath + "\\" + _custID + ".png"))
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
        public static List<Staff> GetStaffList(string name = "", string mobNo = "", string phNo = "")
        {
            List<Staff> staff = new List<Staff>();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    staff = session.QueryOver<Staff>()
                         .WhereRestrictionOn(c => c.Mobile_No).IsLike(mobNo + '%')
                         .And(Restrictions.On<Staff>(c => c.Name).IsLike(name + '%'))
                         .And(Restrictions.On<Staff>(c => c.Phone_No).IsLike(phNo + '%')).List() as List<Staff>;
                }
                return staff;
            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }

        public static Staff GetStaffInfo(int _ID)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var staff = (from _staff in session.Query<Staff>()
                                 where _staff.ID == _ID
                                 select _staff).SingleOrDefault();
                    staff.SecurityDocuments = session.QueryOver<Document>()
                        .Where(x => (x.Staff.ID == _ID))
                        .Fetch(o => o.Staff).Eager
                        .Future().ToList();
                    return staff;
                }
            }
            catch (Exception)
            {
                //todo: log4net
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
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }

        public static List<string> GetDocumentTypeList()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<string> _docList = (from s in session.Query<Document>()
                                             select s.Type).Distinct().ToList();
                    return _docList;
                }

            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }

        public static IList<Document> GetDocumentList(IList<Document> docList)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    foreach (Document doc in docList)
                    {
                        doc.Path = string.Format("{0}\\{2}_{1}.png", DocumentImagePath, doc.Type, doc.Staff.ID);
                        doc.Image = Image.FromFile(doc.Path);
                    }
                    return docList;
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
        public static List<Vendors> GetVendorsList(string name = "", string mobileno = "")
        {
            List<Vendors> _vend = new List<Vendors>();
            using (var session = NHibernateHelper.OpenSession())
            {
                string query = "select v.Name,v.MobileNo,v.ID from vendors v where (v.Name like :Name)" +
                "and (v.MobileNo like :MobileNo) order by v.UpdatedTime desc";

                NHibernate.IQuery sqlQuery = (session.CreateSQLQuery(query)
                   .SetParameter("Name", name + "%")
                   .SetParameter("MobileNo", mobileno + "%"))
                   .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Vendors)));
                return _vend = sqlQuery.List<Vendors>() as List<Vendors>;
            }
        }

        public static Vendors GetVendorInfo(string mobileno)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    Vendors vendor = (from v in session.Query<Vendors>()
                                      where v.MobileNo == mobileno
                                      select v).Single();
                    return vendor;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }
        #endregion Vendor

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
