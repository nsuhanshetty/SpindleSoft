using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpindleSoft.Builders;
using SpindleSoft.Savers;
using SpindleSoft.Model;

namespace SpindlesSoftTestCases.Functions
{
    public class Alteration_TestCase
    {
        [Test]
        [TestCase("", "", ""), 
        TestCase("c","","1"),
        TestCase("c", "6", "1")]
        public static void GetAlterationItems_Test(string name = null, string mobNo = null, string altID = null)
        {
            List<Alteration> altList = AlterationBuilder.GetAlterationList(name, mobNo, altID);
            Assert.IsNotEmpty(altList);
        }

        [TestCase(27)]
        public static void GetListOfOrderIDs_BasedOnthe_CustomerID_Test(int _custID)
        {
            var names = AlterationBuilder.GetOrderIDs(_custID);
            Assert.IsNotEmpty(names);
        }

        [TestCase(4)]
         public static void DeleteAlterationItems_BasedOnAlterationItemID(int _id)
        {
            bool success = AlterationSaver.DeleteAlterationItems(_id);
            Assert.AreEqual(success, true);
        }
    }
}
