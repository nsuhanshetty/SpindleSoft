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
//using NHibernate;

namespace SpindleSoft.Builders
{
    public class PeoplePracticeBuilder
    {
        //todo: appsettings not working for path
        static string customerPicPath = "d:\\CustomerImages";
        //System.Windows.Forms.Application.StartupPath + "\\CustomerImages";
        static string StaffImagePath = "d:\\StaffImages";
        //System.Windows.Forms.Application.StartupPath + "\\StaffImages";

        #region CustomerBuilder
        public static List<Customer> GetCustomersList(string name = "", string mobileno = "", string phoneno = "")
        {
            List<Customer> _cust = new List<Customer>();
            using (var session = NHibernateHelper.OpenSession())
            {
                string query = "select c.Name,c.Mobile_No,c.Phone_No from customer c where (c.Name like :Name)" +
                "and (c.Mobile_No like :Mobile_No) and (c.Phone_No like :Phone_No) order by c.UpdatedTime desc";

                NHibernate.IQuery sqlQuery = (session.CreateSQLQuery(query)
                   .SetParameter("Name", name + "%")
                   .SetParameter("Mobile_No", mobileno + "%")
                   .SetParameter("Phone_No", phoneno + "%"))
                   .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Customer)));
                return _cust = sqlQuery.List<Customer>() as List<Customer>;

                //var _custs = session.QueryOver<Customer>()
                //      .WhereRestrictionOn(c => c.Mobile_No).IsLike(mobileno + '%')
                //      .And(Restrictions.On<Customer>(c => c.Name).IsLike(name + '%'))
                //      .And(Restrictions.On<Customer>(c => c.Phone_No).IsLike(phoneno + '%'))
                //     .List() as List<Customer>;
                // return _custs;
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
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }

        public static Image GetCustomerImage(string mobNo)
        {
            try
            {
                using (Image image = Image.FromFile(customerPicPath + "\\" + mobNo + ".png"))
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

        public static Staff GetStaffInfo(string mobNo)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var staff = (from _staff in session.Query<Staff>()
                                 where _staff.Mobile_No == mobNo
                                 select _staff).Single();
                    return staff;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }

        public static Image GetStaffImage(string mobileNo)
        {
            try
            {
                using (Image image = Image.FromFile(StaffImagePath + "\\" + mobileNo + ".png"))
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
        #endregion Staff

        #region Vendor
        public static List<Vendors> GetVendorsList(string name = "", string mobileno = "")
        {
            List<Vendors> _vend = new List<Vendors>();
            using (var session = NHibernateHelper.OpenSession())
            {
                string query = "select v.Name,v.MobileNo from vendors v where (v.Name like :Name)" +
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
