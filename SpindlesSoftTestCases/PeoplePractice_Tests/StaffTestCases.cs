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
        [TestCase(1, true)]
        [TestCase(2, false)]
         public void GetStaffInfo_Test(int _ID,bool success)
        {
            Staff staff = SpindleSoft.Builders.PeoplePracticeBuilder.GetStaffInfo(_ID);
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
        [TestCase(2, true)]
        [TestCase(3, false)]
        public void GetStaffImage_Test(int _ID, bool success)
        {
            Image image = PeoplePracticeBuilder.GetStaffImage(_ID);
            Assert.AreEqual(image != null, success);

            if (image != null)
                Assert.AreSame(image.GetType(), typeof(System.Drawing.Bitmap));
        }
        #endregion getStaff

        #region Create
        [Test]
        [TestCase("Staff1", "1111111112", "2222222223", "#no Address", 1),
        TestCase("Staff2", "1111111113", "2222222224", "", 1),
        TestCase("Staff3", "1111111114", "2222222225", "", 2)]
        public void SaveStaffInfo_Test(string name, string mobNo, string phoneNo, string address = "", int IsTemporary = 1)
        {
            Staff staff = new Staff(name, mobNo, phoneNo, address, IsTemporary);
            int _ID = PeoplePracticeSaver.SaveStaffInfo(staff);
            Assert.AreEqual(_ID!=0, true);
        }

        [Test]
        [TestCase("C:\\Users\\NSuhanShetty\\Desktop\\icon\\AddReferral.png",2)]
        [TestCase("C:\\Users\\NSuhanShetty\\Desktop\\icon\\User.png", 3)]
        public void SaveStaffImage_Test(string path, int _ID)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            Image image = Image.FromStream(ms);
            bool success = PeoplePracticeSaver.SaveStaffImage(image, _ID);
            Assert.AreEqual(success, true);
        }
        #endregion Create
    }
}
