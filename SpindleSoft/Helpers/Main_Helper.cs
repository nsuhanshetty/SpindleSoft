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
using System.Windows.Forms;

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
            switch (searchState)
            {
                //todo : remove the datatable _dataTable
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
                case "Order":
                    {
                        List<Orders> ordersList = (OrderBuilder.GetOrdersList("", "", searchText));
                        if (ordersList != null && ordersList.Count != 0)
                            _dataTable = ToDataTable((from order in ordersList
                                                      select new
                                                      {
                                                          order.ID,
                                                          Total = order.TotalPrice,
                                                          Paid = order.CurrentPayment,
                                                          DueDate = order.PromisedDate.ToString("dd-MM-yy")
                                                      }).ToList());
                    }
                    break;
                case "Alteration":
                    {
                        List<Alteration> altList = (AlterationBuilder.GetAlterationList("", "", searchText));
                        if (altList != null && altList.Count != 0)
                            _dataTable = ToDataTable((from alt in altList
                                                      select new { alt.TotalPrice, Paid = alt.CurrentPayment, DueDate = alt.PromisedDate }).ToList());
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

        public static int FillDatagrid(IList datalist, DataGridView dgv)
        {
            if (datalist != null)
            {
                dgv.DataSource = null;
                dgv.Rows.Clear();
                foreach (var item in datalist)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item.GetType().GetProperty("ID").GetValue(item, null);
                    dgv.Rows[index].Cells[1].Value = ((DateTime)item.GetType().GetProperty("DueDate").GetValue(item, null)).ToString("dd/MMMM/yy");
                }
            }
            return datalist == null ? 0 : datalist.Count;
        }
    }
}
