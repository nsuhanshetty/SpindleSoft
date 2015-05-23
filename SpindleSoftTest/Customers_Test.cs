using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using SpindleSoft.Model;
using System.Collections.Generic;

namespace SpindleSoftTest
{
    
    public class Customers_Test
    {
        private const string BASE_URI_GET = "http://192.168.0.101:14041/Customer/get";

        [Theory,
        InlineData("", "", ""),
        InlineData("akash", "", ""),
        InlineData("akash", "9739996858", "08182270501"),
        InlineData("akash", "97", "08182270501"),
        InlineData("akash", "97", "081"),
        InlineData("", "", "081"),
        InlineData("", "97", "")
        ]
        [Fact]
        public void GetAllCustomers_Test(string name, string mobileno, string phoneno)
        {
            string uri = BASE_URI_GET + "?name=" + name + "&mobile=" + mobileno + " &phone=" + phoneno;
            List<Customer> customers = GetCustomersList(uri);
            Assert.NotEqual(customers.Count,0);
            System.Diagnostics.Debug.WriteLine("name=" + name + ", mobile=" + mobileno + ", phone=" + phoneno);
        }

        private List<Customer> GetCustomersList(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return  JsonConvert.DeserializeObject<List<Customer>>(s);
        }


        private CustomerList GeCustomerImageByID()
        {
            string uri = BASE_URI_GET + "/Image/123.png";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<CustomerList>(s);
        }

        private Customer GeCustomerByID()
        {
            string uri = BASE_URI_GET + "?id=1";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Customer>(s);
        }


        /*
         /customer/upload/image
         * /customer/get/image
         * cutomer/create
         */
    }
}