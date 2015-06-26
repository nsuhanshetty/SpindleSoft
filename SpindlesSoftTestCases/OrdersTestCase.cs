using NUnit.Framework;
using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace SpindlesSoftTestCases
{
    class OrdersTestCase
    {
        ILog log = LogManager.GetLogger(typeof(OrdersTestCase));

        [Test]
        [TestCase(1, "blouse", true)]
        [TestCase(1, "bloused", false)]
        public void GetPreviousMeasurements(int custId, string itemName, bool success)
        {
            try
            {
                //OrderItem _orderItem = OrderBuilder.GetOrderItem(custId, itemName);
                //Assert.AreEqual(_orderItem != null, success);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                //throw;
            }
            
        }
    }
}
