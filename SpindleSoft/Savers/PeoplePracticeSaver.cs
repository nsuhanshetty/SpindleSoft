using Newtonsoft.Json;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SpindleSoft.Savers
{
    class PeoplePracticeSaver
    {
        //private static Uri BaseUri = new Uri("http://192.168.0.106:14041");
        private static Uri BaseUri = new Uri(System.Configuration.ConfigurationManager.AppSettings.Get("BaseUri"));

        public static bool CreateCustomer(Customer _customer)
        {
            var json = JsonConvert.SerializeObject(_customer);
            HttpWebRequest _request = HttpWebRequest.CreateHttp(new Uri(BaseUri, "customer/save"));
            _request.ContentType = "application/json";
            _request.Method = "POST";
            try
            {
                using (StreamWriter _swriter = new StreamWriter(_request.GetRequestStream()))
                {
                    _swriter.WriteAsync(json);
                }

                using (var _webResponse = (HttpWebResponse)_request.GetResponse())
                {
                    return (_webResponse.StatusCode == HttpStatusCode.Created) ? true : false;
                }
            }
            catch(WebException ex)
            {
                //todo: log in log4net
                Logger.Error(ex);
                return false;
            }
        }

        //todo: Combine with CreateCustomer
        public static bool CreateCustomers(List<Customer> _customers)
        {
            var json = JsonConvert.SerializeObject(_customers);
            HttpWebRequest _request = HttpWebRequest.CreateHttp(new Uri(BaseUri, "customers/save"));
            _request.ContentType = "application/json";
            _request.Method = "POST";
            try
            {
                using (StreamWriter _swriter = new StreamWriter(_request.GetRequestStream()))
                {
                    _swriter.WriteAsync(json);
                }

                using (var _webResponse = (HttpWebResponse)_request.GetResponse())
                {
                    return (_webResponse.StatusCode == HttpStatusCode.Created) ? true : false;
                }
            }
            catch(WebException ex)
            {
                //todo: log in log4net
                return false;
            }
        }

        //send all the info as form using dicitonary
        public static bool CreateCustomerImage(Image _image, string mobile_no)
        {
            byte[] _imageByte = (byte[])new ImageConverter().ConvertTo(_image, typeof(byte[]));

            //todo: Check if Server Or Client error and let customer know abt it.
            try
            {
                //todo: try to implement using restSharp
                Uri _uri = new Uri(BaseUri, "customer/upload/image");

                //todo: make following codes inline
                Dictionary<string, object> _postParameters = new Dictionary<string, object>();
                _postParameters.Add("file", new FormUpload.FileParameter(_imageByte));
                _postParameters.Add("mobile", mobile_no);

                HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(_uri.ToString(), "someone", _postParameters);

                // Process response
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string fullResponse = responseReader.ReadToEnd();
                webResponse.Close();
                return true;
            }                
            catch(WebException ex)
            {
                //todo: log in log4net
                return false;
            }
        }

        private static object GetCustomerImage(Uri uri)
        {
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
                return null;
                throw;
            }
        }
    }
}
