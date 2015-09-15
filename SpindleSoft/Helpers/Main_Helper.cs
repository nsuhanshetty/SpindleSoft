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
        public static IList GetDataSource(string searchState, string searchText)
        {
            IList searchList = null;
            switch (searchState)
            {
                case "Customer":
                    List<Customer> _custList = PeoplePracticeBuilder.GetCustomersList("", searchText, "");
                    if (_custList != null && _custList.Count != 0)
                    {
                        searchList = (from cust in _custList
                                      select new { cust.ID, cust.Name, cust.Mobile_No }).ToList();
                    }
                    break;
                case "Sales":
                    {
                        List<Sale> salesList = (SaleBuilder.GetSalesList("", "", "", searchText));
                        if (salesList != null && salesList.Count != 0)
                            searchList = (from sale in salesList
                                          select new { sale.TotalPrice, sale.AmountPaid, sale.DateOfSale }).ToList();
                    }
                    break;
                case "Order":
                    {
                        List<Orders> ordersList = (OrderBuilder.GetOrdersList("", "", searchText));
                        if (ordersList != null && ordersList.Count != 0)
                            searchList = (from order in ordersList
                                          select new
                                          {
                                              order.ID,
                                              Total = order.TotalPrice,
                                              Paid = order.CurrentPayment,
                                              DueDate = order.PromisedDate.ToString("dd-MM-yy")
                                          }).ToList();
                    }
                    break;
                case "Alteration":
                    {
                        List<Alteration> altList = (AlterationBuilder.GetAlterationList("", "", searchText));
                        if (altList != null && altList.Count != 0)
                            searchList = (from alt in altList
                                          select new { alt.ID,
                                                       Total = alt.TotalPrice, 
                                                       Paid = alt.CurrentPayment, 
                                                       DueDate = alt.PromisedDate
                                                    }).ToList();
                    }
                    break;

                default:
                    break;
            }
            return searchList;
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
