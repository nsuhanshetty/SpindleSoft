using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpindleSoft.Model;
using SpindleSoft.Builders;
using SpindleSoft.Savers;
using System.Collections;

namespace SpindlesSoftTestCases.Functions
{
    class Main_TestCase
    {
        [Test]
        public static void GetR2SCount_BuilderTestCase()
        {
            IList ordersList = MainBuilder.GetAlterList_BasedOnStatus(0);
            Assert.IsNotEmpty(ordersList);
        }

        [TestCase (27,1)]
        [TestCase(27, 0)]
        public static void SaveUpdatedStatus_Order(int _id, int _status)
        {
            bool success = MainSaver.UpdateOrderStatus(_id, _status);
            Assert.IsTrue(success);
        }
    }
}
