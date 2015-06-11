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
                    bool exist = session.Query<SaleItem>().Count(x => x.Name == productName) > 0;
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
                    bool exist = session.Query<SaleItem>().Count(x => x.ProductCode == prodCode) > 0;
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
                    var variationValuesDB = (from s in session.Query<SaleItem>()
                                             select new { s.Color, s.Material, s.Size }).Distinct().ToArray();

                    List<string> colorList = (from vall in variationValuesDB
                                              select vall.Color).ToList<string>();
                    List<string> materialList = (from vall in variationValuesDB
                                                 select vall.Material).ToList<string>();
                    List<string> sizeList = (from vall in variationValuesDB
                                             select vall.Size).ToList<string>();

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
    }
}
