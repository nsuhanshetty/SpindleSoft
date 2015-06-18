using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Helpers
{
    class Main_Helper
    {
        /// <summary>
        /// getdatsource - based on the searchstate and seatch text appropriate list must be selected.
        /// </summary>
        /// <param name="searchState"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public static DataTable GetDataSource(string searchState, string searchText)
        {
            //todo: need to send only two properties and only top 10
            DataTable _dataTable = null;
            //Dictionary<string,string> dataSourceList = null;
            switch (searchState)
            {
                case "Customer":
                    List<Customer> _custList = PeoplePracticeBuilder.GetCustomersList("", searchText, "");
                    if (_custList != null && _custList.Count != 0)
                    {
                        //_custList.Select(c => i => new { i.Name, i.Mobile_No }).ToList());
                        _dataTable = ToDataTable(_custList);
                        _dataTable.Columns.Remove("ID");
                        _dataTable.Columns.Remove("phone_no");
                        _dataTable.Columns.Remove("email");
                        _dataTable.Columns.Remove("address");
                        _dataTable.Columns.Remove("image");
                        _dataTable.Columns.Remove("ReferralID");
                    }
                    break;
                case "Sales":
                    {
                        List<Sale> salesList = (SaleBuilder.GetSalesList("", "", "", searchText));
                        if (salesList != null && salesList.Count != 0)
                            _dataTable = ToDataTable((from sale in salesList
                                                    select new { sale.TotalPrice, sale.AmountPaid, sale.DateOfSale }).ToList());
                    }
                    break;
                default:
                    //var dataSourceList = null;
                    break;
            }
            return _dataTable;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
