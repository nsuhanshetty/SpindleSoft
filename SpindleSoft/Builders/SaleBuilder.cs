using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace SpindleSoft.Builders
{
    class SaleBuilder
    {
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

        public static List<SKUItem> GetSaleItems(string name = "", string procode = "", string Desc = "", string color = "", string size = "",
            string material = "", bool IsSelfMade = true, string vendName = "")
        {
            //todo : also add vendor name along with the list
            List<SKUItem> _saleItem = new List<SKUItem>();
            using (var session = NHibernateHelper.OpenSession())
            {
                string query = "select s.Name,s.ProductCode,s.Color,s.Size,s.Material,s.Quantity from skuitem s " +
                    //"inner join vendors v on v.ID = s.VendorID " +
                                  "where (s.Name like :name) and (s.ProductCode like :procode) and " +
                                  "s.Color like :color and s.Size like :size and s.Material like :material " +
                                  "and s.Quantity > 1 " +
                                  "order by s.UpdatedTime desc";

                NHibernate.IQuery sqlQuery = (session.CreateSQLQuery(query)
                    .SetParameter("name", name + "%")
                   .SetParameter("procode", procode + "%")
                   .SetParameter("color", (color == "All" ? "" : color) + "%")
                   .SetParameter("size", (size == "All" ? "" : size) + "%")
                   .SetParameter("material", (material == "All" ? "" : material) + "%"))
                    //.SetParameter("vendName", vendName + "%"))
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(SKUItem)));
                return _saleItem = sqlQuery.List<SKUItem>() as List<SKUItem>;

                //System.Collections.IList list = _saleItem.Select()  
                //return sqlQuery;
            }
        }

        public static SKUItem GetSaleItemInfo(string procode)
        {
            SKUItem _saleItem = new SKUItem();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _saleItem = (from s in session.Query<SKUItem>()
                                 where s.ProductCode == procode
                                 select s).Single();
                    return _saleItem;
                }
            }
            catch (Exception)
            {
                //log4net 
                return null;
            }
        }

        public static Vendors GetVendorsInfo(int vendorId)
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
    }
}
