using Newtonsoft.Json;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

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
                    return JsonConvert.DeserializeObject<Customer>(s);
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
    }
}
