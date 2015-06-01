using NUnit.Framework;
using SpindleSoft;
using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindlesSoftTestCases
{
    class StaffTestCases
    {
        #region getStaff
        //getstaffinfo
        [Test]
        [TestCase("1111111114", true)]
        [TestCase("1111111116", false)]
         public void GetStaffInfo_Test(string mobileno,bool success)
        {
            Staff staff = SpindleSoft.Builders.PeoplePracticeBuilder.GetStaffInfo(mobileno);
            Assert.AreEqual(staff != null, success);
        }
        

        //getstafflist
        [Test]
        [TestCase("", "", ""),
        TestCase("Staff1", "", ""),
        TestCase("Staff2", "1111", "2222222224"),
        TestCase("", "", "2222222224"),
        TestCase("", "1111111114", "")]
        public void GetStaffList_Test(string name, string mobileno, string phoneno)
        {
            List<Staff> staff = SpindleSoft.Builders.PeoplePracticeBuilder.GetStaffList(name, mobileno, phoneno);
            Assert.Greater(staff.Count, 0);
        }


        //getstaffimage
        [Test]
        [TestCase("1111111114", true)]
        [TestCase("1111111116", false)]
        public void GetStaffImage_Test(string mobileNo, bool success)
        {
            Image image = PeoplePracticeBuilder.GetStaffImage(mobileNo);
            Assert.AreEqual(image != null, success);

            if (image != null)
                Assert.AreSame(image.GetType(), typeof(System.Drawing.Bitmap));
        }
        #endregion getStaff

        #region Create
        [Test]
        [TestCase("Staff1", "1111111112", "2222222223", "#no Address", true),
        TestCase("Staff2", "1111111113", "2222222224", "", true),
        TestCase("Staff3", "1111111114", "2222222225", "", false)]
        public void SaveStaffInfo_Test(string name, string mobNo, string phoneNo, string address = "", bool IsTemporary = true)
        {
            Staff staff = new Staff(name, mobNo, phoneNo, address, IsTemporary);
            bool success = PeoplePracticeSaver.SaveStaffInfo(staff);
            Assert.AreEqual(success, true);
        }

        [Test]
        [TestCase("C:\\Users\\NSuhanShetty\\Desktop\\icon\\AddReferral.png", "1111111114")]
        [TestCase("C:\\Users\\NSuhanShetty\\Desktop\\icon\\User.png", "1111111114")]
        public void SaveStaffImage_Test(string path, string mobNo)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            Image image = Image.FromStream(ms);
            bool success = PeoplePracticeSaver.SaveStaffImage(image, mobNo);
            Assert.AreEqual(success, true);
        }
        #endregion Create
    }
}
