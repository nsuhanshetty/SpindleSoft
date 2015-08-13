using NUnit.Framework;
using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindlesSoftTestCases.PeoplePractice_Tests
{
    class CustomerTestCases
    {
        #region GetCustomer

        //getCustomerInfo
        [Test]
        [TestCase("2111111112", true)]
        [TestCase("2111111116", false)]
        public void GetStaffInfo_Test(string mobileno, bool success)
        {
            Customer cust = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomerInfo(mobileno);
            Assert.AreEqual(cust != null, success);
        }

        //getCustomerimage
        [Test]
        [TestCase(2, true)]
        [TestCase(9000, false)]
        public void GetCustomerImage_Test(int _ID, bool success)
        {
            Image image = PeoplePracticeBuilder.GetCustomerImage(_ID);
            Assert.AreEqual(image != null, success);

            if (image != null)
                Assert.AreSame(image.GetType(), typeof(System.Drawing.Bitmap));
        }


        //getCustomerList
        [Test]
        [TestCase("", "", ""),
        TestCase("akash", "", ""),
        TestCase("", "", "7242496392"),
        TestCase("", "8973", "")]
        public void GetCustomerList_Test(string name, string mobileno, string phoneno)
        {
            List<Customer> customers = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomersList(name, mobileno, phoneno);
            Assert.Greater(customers.Count, 0);
        }
        #endregion getCustomer

        #region CreateCustomer

        [Test]
        [TestCase("Customer1", "2111111112", 2, "#no Address", "n@s.com"),
        TestCase("Customer2", "2111111113", 2, "", "m@s.com"),
        TestCase("Customer3", "2111111114", 2, "", "")]
        public void SaveCustomerInfo_Test(string name, string mobNo, string phoneNo, string address = "", string email = "")
        {
            Customer cust = new Customer(name, mobNo, phoneNo, address, email);
            int _ID = PeoplePracticeSaver.SaveCustomerInfo(cust);
            Assert.AreEqual(_ID!=0, true);
        }

        [Test]
        [TestCase("C:\\Users\\NSuhanShetty\\Desktop\\icon\\AddReferral.png", 2)]
        [TestCase("C:\\Users\\NSuhanShetty\\Desktop\\icon\\User.png", 2)]
        public void SaveCustomerImage_Test(string path, int _ID)
        {
            //byte[] bytes = System.IO.File.ReadAllBytes(path);
            //System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            Image image = Image.FromFile(path);
            bool success = PeoplePracticeSaver.SaveCustomerImage(image, _ID);
            Assert.AreEqual(success, true);
        }
        #endregion Customer
    }
}
