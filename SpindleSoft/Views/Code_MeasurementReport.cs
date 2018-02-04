using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Views
{
    public partial class MeasurementReport
    {
        private OrderItem _orderItem;
        private Customer _cust;
        public MeasurementReport(OrderItem data, Customer cust) { this._orderItem = data; this._cust = cust; }
    }
}
