using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using System.Collections;
using System.Data;
using log4net;

namespace SpindleSoft.Builders
{
    class SaleBuilder
    {
        #region SKUItems
        public static bool IsExistingName(string productName)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    bool exist = session.Query<SKUItem>().Count(x => x.Name == productName) > 0;
                    return exist;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return true;
            }
        }

        public static bool IsExistingProdCode(string prodCode)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    bool exist = session.Query<SKUItem>().Count(x => x.ProductCode == prodCode) > 0;
                    return exist;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return true;
            }
        }

        public static List<List<string>> GetVariationValues()
        {
            //IList<T> variationValues;
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var variationValuesDB = (from s in session.Query<SKUItem>()
                                             select new { s.Color, s.Material, s.Size }).Distinct().ToArray();

                    List<string> colorList = (from vall in variationValuesDB
                                              select vall.Color).Distinct().ToList<string>();
                    List<string> materialList = (from vall in variationValuesDB
                                                 select vall.Material).Distinct().ToList<string>();
                    List<string> sizeList = (from vall in variationValuesDB
                                             select vall.Size).Distinct().ToList<string>();

                    List<List<string>> variationValues = new List<List<string>>();
                    variationValues.Add(colorList);
                    variationValues.Add(materialList);
                    variationValues.Add(sizeList);

                    return variationValues;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }

        public static List<SKUItem> GetSKUItems(string name = "", string procode = "", string Desc = "", string color = "", string size = "",
            string material = "", bool IsSelfMade = true, string vendName = "")
        {
            //todo : also add vendor name along with the list
            List<SKUItem> _skuItem = new List<SKUItem>();
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    string query = "select s.Name,s.ProductCode,s.Color,s.Size,s.Material,s.Quantity from skuitem s " +
                        //"inner join vendors v on v.ID = s.VendorID " +
                                      "where (s.Name like :name) and (s.ProductCode like :procode) and (s.Description like :desc) and " +
                                      "s.Color like :color and s.Size like :size and s.Material like :material " +
                                      "and s.Quantity > 1 " +
                                      "order by s.UpdatedTime desc";

                    NHibernate.IQuery sqlQuery = (session.CreateSQLQuery(query)
                        .SetParameter("name", name + "%")
                       .SetParameter("procode", procode + "%")
                       .SetParameter("desc", "%" + Desc + "%")
                       .SetParameter("color", (color == "All" ? "" : color) + "%")
                       .SetParameter("size", (size == "All" ? "" : size) + "%")
                       .SetParameter("material", (material == "All" ? "" : material) + "%"))
                        //.SetParameter("vendName", vendName + "%"))
                    .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(SKUItem)));
                    return _skuItem = sqlQuery.List<SKUItem>() as List<SKUItem>;
                }
                catch(Exception)
                {
                    return null;
                    //log4net
                }
                //System.Collections.IList list = _saleItem.Select()  
                //return sqlQuery;
            }
        }

        public static SKUItem GetSkuItemInfo(string procode)
        {
            SKUItem _skuItem = new SKUItem();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _skuItem = (from s in session.Query<SKUItem>()
                                where s.ProductCode == procode
                                select s).Single();
                    return _skuItem;
                }
            }
            catch (Exception)
            {
                //log4net 
                return null;
            }
        }
        #endregion SKUItems

        #region Vendors
        public static Vendors GetVendorsInfo(int? vendorId)
        {
            Vendors _vendor = new Vendors();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _vendor = (from v in session.Query<Vendors>()
                               where v.ID == vendorId
                               select v).Single();
                    return _vendor;
                }
            }
            catch (Exception)
            {
                //log4net 
                return null;
            }
        }

        public static List<string> GetVendorNames()
        {
            //IList<T> variationValues;
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<string> vendorNames = (from v in session.Query<Vendors>()
                                                select v.Name).Distinct().ToList<string>();
                    return vendorNames;
                }
            }
            catch (Exception)
            {
                //todo: log4net
                return null;
            }
        }
        #endregion Vendors

        #region Sale
        public static Sale GetSaleInfo(int _saleID)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    Sale sale = (from s in session.Query<Sale>()
                                 where s.ID == _saleID
                                 select s).Single();
                    return sale;
                }
            }
            catch (Exception)
            {
                //todo: Log4net
                return null;
            }
        }

        public static List<SaleItem> GetSaleItemInfo(int _saleID)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<SaleItem> saleItems = (from s in session.Query<SaleItem>()
                                                where s.ID == _saleID
                                                select s).ToList<SaleItem>();
                    return saleItems;
                }
            }
            catch (Exception)
            {
                //todo: Log4net
                return null;
            }
        }

        public static List<Sale> GetSalesList(string name = "", string procode = "", string mobNo = "", string saleID = "")
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var query = "select distinct s.ID,s.TotalPrice,s.AmountPaid,s.DateOfSale from sale s " + /*c.Name,c.Mobile_No,*/
                                "inner join customer c on c.ID = s.CustID " +
                                "inner join saleitem i on i.SaleID  = s.ID " +
                                "inner join skuitem k on k.ID = i.SKUID " +
                                "where c.Name like :name and c.Mobile_No like :mobNo and s.ID like :saleID and k.ProductCode like :procode";

                    NHibernate.IQuery sqlQuery = (session.CreateSQLQuery(query)
                    .SetParameter("name", name + "%")
                    .SetParameter("procode", procode + "%")
                    .SetParameter("mobNo", mobNo + "%")
                    .SetParameter("saleID", saleID + "%"))
                    .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Sale)));
                    return sqlQuery.List<Sale>() as List<Sale>;
                }
            }
            catch (Exception ex)
            {
                //todo: Log4net
                ILog log = LogManager.GetLogger(typeof(SaleBuilder));
                log.Error(ex.Message);
                return null;
            }
        }

        //public static List<Sale> GetSalesItemList(string saleID = "")
        //{
        //    try
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            var query = from s in session.Query<SaleItem>()
        //                        select new {s.Quantity,s.Price,}

        //            NHibernate.IQuery sqlQuery = (session.CreateSQLQuery(query)
        //            .SetParameter("name", name + "%")
        //            .SetParameter("procode", procode + "%")
        //            .SetParameter("mobNo", mobNo + "%")
        //            .SetParameter("saleID", saleID + "%"))
        //            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(Sale)));
        //            return sqlQuery.List<Sale>() as List<Sale>;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //todo: Log4net
        //        return null;
        //    }
        //}
        #endregion Sale
    }
}
