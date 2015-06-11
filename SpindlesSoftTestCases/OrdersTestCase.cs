using NUnit.Framework;
using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindlesSoftTestCases
{
    class OrdersTestCase
    {
        [Test]
        [TestCase(1,"blouse",true)]
        [TestCase(1,"bloused",false)]
        public void GetPreviousMeasurements(int custId, string itemName,bool success)
        {
            OrderItem _orderItem = OrderBuilder.GetOrderItem(custId, itemName);

            Assert.AreEqual(_orderItem != null, success);
        }
    }
}
