using NUnit.Framework;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindlesSoftTestCases
{
    class VendorTestCase
    {
        #region Saver 

        [Test]
        [TestCase("VendorName1", "8971150421","address","bankusername1", "accNo1234656","bankname1","IFSC8968668")]
        public static void SaveVendorDetails(string name,string mobno, string address, string bankusername, string accno, string bankname,string IfscNo)
        {
            Vendors vendor = new Vendors(name,mobno, address, bankusername, accno, bankname,IfscNo);
            bool success = PeoplePracticeSaver.SaveVendorInfo(vendor);
            Assert.AreEqual(success, true);
        }
        #endregion Saver
    }
}
