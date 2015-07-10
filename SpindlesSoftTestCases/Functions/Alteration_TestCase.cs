using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpindleSoft.Builders;
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
    }
}
