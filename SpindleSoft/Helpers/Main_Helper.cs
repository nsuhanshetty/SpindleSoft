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
using log4net;
using MySql.Data.MySqlClient;

namespace SpindleSoft.Helpers
{
    class Main_Helper
    {

        static ILog log = LogManager.GetLogger(typeof(Main_Helper));
        //static string constring = "server=localhost;user=sa;pwd=sshetty;database=spindlesoftdb;Convert Zero Datetime=True;";

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
                    //List<Customer> _custList = PeoplePracticeBuilder.GetCustomersList("", searchText, "");
                    var _custList = PeoplePracticeBuilder.GetCustomersQuickList(searchText);
                    if (_custList != null && _custList.Count != 0)
                    {
                        searchList = _custList;
                    }
                    break;
                case "Sales":
                    {
                        List<Sale> salesList = (SaleBuilder.GetSalesListQuick(searchText));
                        if (salesList != null && salesList.Count != 0)
                            searchList = (from sale in salesList
                                          select new { sale.Customer.Name, Total = sale.TotalPrice, SaleDate = sale.DateOfSale.ToString("dd/MM/yyyy") }).ToList();
                    }
                    break;
                case "Order":
                    {
                        IList ordersList = (OrderBuilder.GetOrdersQuickList(searchText));
                        if (ordersList != null && ordersList.Count != 0)
                            searchList = ordersList;
                    }
                    break;
                case "Alteration":
                    {
                        IList altList = (AlterationBuilder.GetAlterationQuickList(searchText));
                        if (altList != null && altList.Count != 0)
                            searchList = altList;
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
                    dgv.Rows[index].Cells[1].Value = ((DateTime)item.GetType().GetProperty("DueDate").GetValue(item, null)).ToString("dd/MMM/yy");
                }
            }
            return datalist == null ? 0 : datalist.Count;
        }

        //public static bool BackupData()
        //{
        //    try
        //    {
        //        string file = "d:\\backup.sql";
        //        using (MySqlConnection conn = new MySqlConnection(constring))
        //        {
        //            using (MySqlCommand cmd = new MySqlCommand())
        //            {
        //                using (MySqlBackup mb = new MySqlBackup(cmd))
        //                {
        //                    cmd.Connection = conn;
        //                    conn.Open();
        //                    mb.ExportToFile(file);
        //                    conn.Close();
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        return false; ;
        //    }
        //}
    }
}
