using NUnit.Framework;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using SpindleSoft.Model;
using System.Collections.Generic;
using System;
using SpindleSoft.Savers;
namespace SpindleSoftTest
{
    [TestFixture]
    public class Customers_Test
    {
        private Uri BASE_URI = new Uri("http://192.168.0.108:14041");
        //private const Uri BASE_URI_ = new Uri("http://192.168.0.104:14041/customer/save");

        #region Create
        /*Negative Test Cases*/
        /*nCreate Customer with all required info missing*/
        /*nCreate Customer with one of the info missing for all required fields*/
        /*nCreate Customer with all fields with wrong data type*/
        /*nAdd CustomerImage with null*/

        /**/
        /*Positive Test Cases*/
        /*pCreate Customer with all required fields only*/
        /*pCreate Customer with all fields*/
        /*pAdd CustomerImage*/
        [TestCase("akashid", "8973150426", "7242496392", "address", "akash@gmail.com"),
        TestCase("akashied", "8971100725", "", "", "")]
        [Test]
        public void CreateCustomer_Test(string name, string mobile_no, string phone_no, string address, string email)
        {
            Customer _customer = new Customer(name, mobile_no, phone_no, address, email);

            var json = JsonConvert.SerializeObject(_customer);
            //            HttpWebRequest _request = HttpWebRequest.CreateHttp(new Uri(BASE_URI,"/save"));
            HttpWebRequest _request = HttpWebRequest.CreateHttp(new Uri(BASE_URI, "customer/save"));
            _request.ContentType = "application/json";
            _request.Method = "POST";
            using (StreamWriter _swriter = new StreamWriter(_request.GetRequestStream()))
            {
                _swriter.WriteAsync(json);
            }

            using (var _webResponse = (HttpWebResponse)_request.GetResponse())
            {
                //string _result = string.Empty;
                //using (var _sReader = new StreamReader(_webResponse.GetResponseStream()))
                //{
                //    _result = _sReader.ReadToEnd();
                //}

                Assert.AreEqual(_webResponse.StatusCode, HttpStatusCode.Created);
            }
        }
        #endregion Create

        #region CreateImage
        [TestCase("C:\\Users\\NSuhanShetty\\Desktop\\icon\\AddReferral.png","8971150421", true)]
        [Test]
        public void PCreateCustomerImage_Test(string fileName, string mobile_no, bool _bool)
        {
            //todo: try to implement using restSharp
             Image _image = Image.FromFile(fileName);
            byte[] _imageByte = (byte[])new ImageConverter().ConvertTo(_image, typeof(byte[]));
            Uri _uri = new Uri(BASE_URI, "customer/upload/image");
            
            //todo: make following codes inline
            Dictionary<string, object> _postParameters = new Dictionary<string,object>();
            _postParameters.Add("file",new FormUpload.FileParameter(_imageByte));
            _postParameters.Add("mobile",mobile_no);

            HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(_uri.ToString(), "someone", _postParameters);

            // Process response
            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            string fullResponse = responseReader.ReadToEnd();
            webResponse.Close();
            //Response.Write(fullResponse);

            //Image _image = Image.FromFile(fileName);
            ////byte[] _imageByte = (byte[])new ImageConverter().ConvertTo(_image, typeof(byte[]));
            //FileStream fStream = new FileStream(fileName, FileAccess.ReadWrite);

            //try
            //{
            //    using (var _client = new HttpClient())
            //    using (var _formdata = new MultipartFormDataContent())
            //    {
            //        HttpWebRequ
            //        var _fileContent = new ByteArrayContent(_imageByte);
            //        _fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            //        {
            //            FileName = mobile_no
            //        };
            //        _formdata.Add(_fileContent);
            //        Uri _uri = new Uri(BASE_URI, "customer/upload/image");
            //        var _response = _client.PostAsync(_uri, _formdata).Result;
            //        Assert.AreEqual(true,_response.IsSuccessStatusCode);
            //    }
            //}
            //catch (WebException ex)
            //{
            //    //todo: log in log4net
            //    //return false;
            //}
        }

        //[TestCase("",8971150421,false)]
        //[TestCase("", "", false)]
        //[Test]
        //public void NCreateCustomerImage_Test(string fileName, string mobile_no, bool _bool)
        //{
        //    byte[] _imageByte = null;
        //    HttpContent _httpContent = new ByteArrayContent(_imageByte);

        //    using (var _client = new HttpClient())
        //    using (var _formdata = new MultipartContent())
        //    {
        //        _formdata.Add(_httpContent);

        //        var _response = _client.PostAsync(new Uri(BASE_URI, "customer/save/image/" + mobile_no), _formdata).Result;
        //        Assert.AreEqual(_response.IsSuccessStatusCode, _bool);
        //    }
        //}
        #endregion CreateImage

        #region getCustomer
        [TestCase("", "", ""),
        TestCase("akash", "", ""),
        TestCase("akash", "8971150421", "8242496322"),
        TestCase("akash", "89", "8242496322"),
        TestCase("akash", "89", "824"),
        TestCase("", "", "824"),
        TestCase("", "89", "")]
        [Test]
        public void PGetAllCustomers_Test(string name, string mobileno, string phoneno)
        {
            Uri uri = new Uri(BASE_URI, "customer/get?name=" + name + "&mobile=" + mobileno + "&phone=" + phoneno);
            List<Customer> customers = GetCustomersList(uri);
            Assert.Greater(customers.Count, 0);
            System.Diagnostics.Debug.WriteLine("name=" + name + ", mobile=" + mobileno + ", phone=" + phoneno);
        }

        /// <summary>
        /// Get List of Customers based on the parameters sent in the URI
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>List of Customers</returns>
        private List<Customer> GetCustomersList(Uri uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Customer>>(s);
        }

        [TestCase(""),
        TestCase("abc")]
        [Test]
        public void NGetCustomer_ImageByID(string mobileNo)
        {
            Uri uri = new Uri(BASE_URI, "customer/get/image/" + mobileNo);
            Object _customerImage = GetCustomerImage(uri);
            Assert.AreSame(_customerImage, null);
        }

        [TestCase("8971150421")]
        [Test]
        public void PGetCustomer_ImageByID(string mobileNo)
        {
            Uri uri = new Uri(BASE_URI, "customer/get/image/" + mobileNo);
            Object _customerImage = GetCustomerImage(uri);
            Assert.AreNotSame(_customerImage, null);
        }

        private Customer GetCustomerByID()
        {
            Uri uri = new Uri(BASE_URI, "customer/get?id=1");
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Customer>(s);
        }

        /// <summary>
        /// Get Customers based on the unquie parameters sent in the URI
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>Customer</returns>
        private Customer GetCustomer(string uri)
        {
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
                return null;
            }
        }

        /// <summary>
        /// Get's Customers Image based on the unique parameters sent in the URI
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>Customer</returns>
        private object GetCustomerImage(Uri uri)
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
        #endregion getCustomer
    }
}