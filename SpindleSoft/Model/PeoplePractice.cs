using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpindleSoft.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Customer
    {
        //[JsonIgnore]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "mobile_no")]
        public string Mobile_No { get; set; }

        [JsonProperty(PropertyName = "phone_no")]
        public string Phone_No { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        //[JsonIgnore]
        public Image Image { get; set; }

        //public object updated_at { get; set; }

        public Customer() { }

        public Customer(string _name, string _mobileNo, string _phoneNo, string _address, string _email)
        {
            this.Name = _name;
            this.Mobile_No = _mobileNo;
            this.Phone_No = _phoneNo;
            this.Address = _address;
            this.Email = _email;
        }
    }

    //public class Customer
    //{
    //    public object updated_at { get; set; }
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string mobile_no { get; set; }
    //    public string phone_no { get; set; }
    //    public string address { get; set; }
    //    public string email { get; set; }
    //    public object image { get; set; }
    //}

    public class CustomerList
    {
        public List<Customer> Customers { get; set; }
    }

    public class Staff
    {
        public int StaffID { get; set; }

        public string Name { get; set; }

        public string MobileNo { get; set; }

        public string Address { get; set; }

        public Image Image { get; set; }
    }

    public class Group
    {
        public int GroupID { get; set; }

        public string Name { get; set; }

        public List<Customer> CustomerList { get; set; }
    }
}