using Newtonsoft.Json;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;

namespace SpindleSoft.Builders
{
    class PeoplePracticeBuilder
    {
        //private static Uri BaseUri = new Uri("http://192.168.0.104:14041");
        private static Uri BaseUri = new Uri(System.Configuration.ConfigurationManager.AppSettings.Get("BaseUri"));

        #region CustomerBuilder
        public static List<Customer> GetCustomersList(string name, string mobileno, string phoneno)
        {
            //todo: Akash : like "%<value>%" must be replaced with like "<value>%"
            Uri uri = new Uri(BaseUri ,"customer/get?name=" + name + "&mobile_no=" + mobileno + " &phoneno=" + phoneno);
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Customer>>(s);
                }
            }
            catch (WebException ex)
            {
                //add to log4net
                return null;
            }
        }

        /*public static DataTable GetCustomersTable(string name, string mobileno, string phoneno)
        {
            //todo: Akash : like "%<value>%" must be replaced with like "<value>%"
            Uri uri = new Uri(BaseUri, "customer/get?name=" + name + "&mobile_no=" + mobileno + " &phoneno=" + phoneno);
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    return ToDataTable(JsonConvert.DeserializeObject<List<Customer>>(s));
                }
            }
            catch (WebException ex)
            {
                //add to log4net
                return null;
            }
        }*/

        public static Customer GetCustomerInfo(string mobileno)
        {
            Uri uri = new Uri(BaseUri, "customer/get?name=&mobile=" + mobileno + "&phone=");
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    List<Customer> _custList =  JsonConvert.DeserializeObject<List<Customer>>(s);
                    return _custList[0];
                }
            }
            catch (WebException ex)
            {
                //add to log4net
                Logger.Error(ex);
                return null;
            }
        }

        public static Image GetCustomerImage(string mobileNo)
        {
            Uri uri = new Uri(BaseUri, "customer/get/image/" + mobileNo);
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        return Image.FromStream(reader.BaseStream);
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Status.ToString());
                //todo : add to log4net;
                return null;
                throw;
            }
        }

        #endregion CustomerBuilder

        #region Staff
        public static List<Staff> GetStaffList(string name, string mobileno, string phoneno)
        {
            //todo: Akash : like "%<value>%" must be replaced with like "<value>%"
            Uri uri = new Uri(BaseUri, "staff/get?name=" + name + "&mobile_no=" + mobileno + " &phoneno=" + phoneno);
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Staff>>(s);
                }
            }
            catch (WebException ex)
            {
                //add to log4net
                return null;
            }
        }

        public static Staff GetStaffInfo(string mobileno)
        {
            Uri uri = new Uri(BaseUri, "staff/get?name=&mobile=" + mobileno + "&phone=");
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    List<Staff> _custList = JsonConvert.DeserializeObject<List<Staff>>(s);
                    return _custList[0];
                }
            }
            catch (WebException ex)
            {
                //add to log4net
                Logger.Error(ex);
                return null;
            }
        }

        public static Image GetStaffImage(string mobileNo)
        {
            Uri uri = new Uri(BaseUri, "staff/get/image/" + mobileNo);
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        return Image.FromStream(reader.BaseStream);
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Status.ToString());
                //todo : add to log4net;
                return null;
                throw;
            }
        }
        #endregion Staff

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
