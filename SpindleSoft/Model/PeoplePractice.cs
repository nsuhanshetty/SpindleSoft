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
        public virtual int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; }

        [JsonProperty(PropertyName = "mobile_no")]
        public virtual string Mobile_No { get; set; }

        [JsonProperty(PropertyName = "phone_no")]
        public virtual string Phone_No { get; set; }

        [JsonProperty(PropertyName = "address")]
        public virtual string Address { get; set; }

        [JsonProperty(PropertyName = "email")]
        public virtual string Email { get; set; }

        //[JsonIgnore]
        public virtual Image Image { get; set; }

        public virtual int ReferralID { get; set; }

        //public object updated_at { get; set; }

        public Customer() { }

        public Customer(string _name, string _mobileNo, string _phoneNo, string _address, string _email)
        {
            //this.ID = _id;
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
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual string Mobile_No { get; set; }

        public virtual string Phone_No { get; set; }

        public virtual string Address { get; set; }

        public virtual Image Image { get; set; }

        public virtual int Type { get; set; }

        public virtual int PayCycle { get; set; }

        public virtual string Designation { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual string BankUserName { get; set; }

        public virtual string AccNo { get; set; }

        public virtual string IfscCode { get; set; }

        public virtual IList<Document> SecurityDocuments { get; set; }

        public Staff() { }

        public Staff(string name, string mobNo, string phNo, string address = "", int type = 1)
        {
            this.Name = name;
            this.Mobile_No = mobNo;
            this.Phone_No = phNo;
            this.Address = address;
            this.Type = type;
        }
    }

    public class SalaryItem
    {
        public virtual int ID { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Salary Salary { get; set; }

        public virtual decimal Amount { get; set; }

        public SalaryItem() { }

        public SalaryItem(Staff _staff, decimal _amount)
        {
            this.Staff = _staff;
            this.Amount = _amount;
        }
    }

    public class Salary
    {
        public virtual int ID { get; set; }

        public virtual DateTime DateOfSalary { get; set; }

        public virtual decimal TotalSalaryAmount { get; set; }

        public virtual IList<SalaryItem> SalaryItemList { get; set; }

        //public virtual Expense Expense { get; set; }
    }

    public class Group
    {
        public int GroupID { get; set; }

        public string Name { get; set; }

        public List<Customer> CustomerList { get; set; }
    }

    public class Vendor
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual string MobileNo { get; set; }

        public virtual string Address { get; set; }

        public virtual bool IsProduct { get; set; }

        public virtual string OfferingType { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual string AccNo { get; set; }

        public virtual string IFSCCode { get; set; }

        public virtual string BankUserName { get; set; }

        //public Vendor(string name,string mobno, string address, string bankusername, string accno, Bank bank,string IfscNo)
        //{
        //    this.Name = name;
        //    this.MobileNo = mobno;
        //    this.Address = address;

        //    this.BankUserName = bankusername;
        //    this.AccNo = accno;
        //    this.Bank = bank;
        //    this.IFSCCode = IfscNo;
        //}

        public Vendor() { }
    }
}