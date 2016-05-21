using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using log4net;
using NHibernate.Criterion;
using NHibernate.Transform;
using System.Collections;

namespace SpindleSoft.Builders
{
    class SaleBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(SaleBuilder));
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
            catch (Exception ex)
            {
                log.Error(ex);
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
            catch (Exception ex)
            {
                log.Error(ex);
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
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static IList GetSKUItems(string _name = "", string _procode = "", string _desc = "",
                                                string _color = "", string _size = "", string _material = "",
                                                bool _IsSelfMade = true, string _vendName = "")
        {
            //todo : also add vendor name along with the list
            IList _itemList;
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    _color = _color == "All" ? "" : _color;
                    _size = _size == "All" ? "" : _size;
                    _material = _material == "All" ? "" : _material;

                    if (string.IsNullOrEmpty(_name) && string.IsNullOrEmpty(_procode) && string.IsNullOrEmpty(_desc))
                    {
                        _itemList = (from sku in session.Query<SKUItem>()
                                     orderby sku.ID descending
                                     select new { sku.ID, ProductName = sku.Name, sku.ProductCode, sku.Color, sku.Size, sku.Material, sku.Quantity, sku.IsSelfMade })
                                     .Distinct().Take(25).ToList();
                    }
                    else
                        _itemList = (from sku in session.Query<SKUItem>()
                                     //join v in session.Query<Vendor>() on sku.VendorID equals v.ID into gj
                                     where (sku.Name.StartsWith(_name) && sku.ProductCode.StartsWith(_procode) && sku.Description.Contains(_desc) &&
                                            sku.Color.StartsWith(_color) && sku.Color.StartsWith(_size) && sku.Color.StartsWith(_material) && sku.Quantity > 0)
                                     orderby sku.ID descending
                                     select new { sku.ID, ProductName = sku.Name, sku.ProductCode, sku.Color, sku.Size, sku.Material, sku.Quantity, sku.IsSelfMade }).ToList();
                    return _itemList;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }

        public static SKUItem GetSkuItemInfo(string _ID)
        {
            SKUItem _skuItem = new SKUItem();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _skuItem = (from s in session.Query<SKUItem>()
                                where s.ID.ToString() == _ID
                                select s).Single();

                    _skuItem.SKUItemDocuments = (from doc in session.Query<SKUItemDocument>()
                                                 join s in session.Query<SKUItem>() on doc.skuItem.ID equals s.ID
                                                 where s.ID.ToString() == _ID
                                                 select doc).ToList();
                    return _skuItem;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static int GetSkuStock(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.Get<SKUItem>(_ID).Quantity;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return 0;
                }
            }
        }

        public static List<string> GetSKUItemDocumentTypeList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<string> _docList = (from s in session.Query<SKUItemDocument>()
                                         select s.Type).Distinct().ToList();
                return _docList;
            }
        }
        #endregion SKUItems

        #region Vendors
        public static Vendor GetVendorsInfo(int? vendorId)
        {
            Vendor _vendor = new Vendor();
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    _vendor = (from v in session.Query<Vendor>()
                               where v.ID == vendorId
                               select v).Single();
                    return _vendor;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static List<string> GetVendorNames()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    List<string> vendorNames = (from v in session.Query<Vendor>()
                                                select v.Name).Distinct().ToList<string>();
                    return vendorNames;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
                    Sale _sale = (from s in session.Query<Sale>()
                                  where s.ID == _saleID
                                  select s).Single();

                    _sale.SaleItems = session.QueryOver<SaleItem>()
                                    .Where(x => x.Sale.ID == _saleID)
                                    .Fetch(o => o.Sale).Eager
                                    .Fetch(o => o.Sale.Customer).Eager
                                    .Fetch(o => o.SKUItem).Eager
                                    .Future().ToList();
                    return _sale;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static List<Sale> GetSalesList(string _name = "", string _procode = "", string _mobNo = "", string _saleID = "")
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    Sale saleAlias = null;
                    SaleItem saleItemAlias = null;
                    SKUItem skuItemAlias = null;
                    Customer custAlias = null;

                    List<Sale> saleList;
                    if (string.IsNullOrEmpty(_name) && string.IsNullOrEmpty(_procode) && string.IsNullOrEmpty(_mobNo) && string.IsNullOrEmpty(_saleID))
                    {
                        saleList = session.QueryOver<Sale>(() => saleAlias)
                                                                    .JoinAlias(() => saleAlias.Customer, () => custAlias)
                                                                    .Left.JoinAlias(() => saleAlias.SaleItems, () => saleItemAlias)
                                                                    .Left.JoinAlias(() => saleItemAlias.SKUItem, () => skuItemAlias)
                                                                    .OrderBy(() => saleAlias.DateOfSale).Desc
                                                                    .TransformUsing(Transformers.DistinctRootEntity).Take(25).List().ToList<Sale>();
                    }
                    else
                        saleList = session.QueryOver<Sale>(() => saleAlias)
                                                                    .JoinAlias(() => saleAlias.Customer, () => custAlias)
                                                                    .Left.JoinAlias(() => saleAlias.SaleItems, () => saleItemAlias)
                                                                    .Left.JoinAlias(() => saleItemAlias.SKUItem, () => skuItemAlias)
                                                                    .Where(Restrictions.On(() => custAlias.Name).IsLike(_name + "%"))
                                                                    .Where(Restrictions.On(() => skuItemAlias.ProductCode).IsLike(_procode + "%"))
                                                                    .Where(Restrictions.On(() => custAlias.Mobile_No).IsLike(_mobNo + "%"))
                                                                    .OrderBy(() => saleAlias.DateOfSale).Desc
                                                                    .TransformUsing(Transformers.DistinctRootEntity).List().ToList<Sale>();
                    return saleList;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static List<Sale> GetSalesListQuick(string _name = "")
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    Sale saleAlias = null;
                    SaleItem saleItemAlias = null;
                    SKUItem skuItemAlias = null;
                    Customer custAlias = null;

                    List<Sale> saleList;
                    if (string.IsNullOrEmpty(_name))
                    {
                        saleList = session.QueryOver<Sale>(() => saleAlias)
                                                                    .JoinAlias(() => saleAlias.Customer, () => custAlias)
                                                                    .Left.JoinAlias(() => saleAlias.SaleItems, () => saleItemAlias)
                                                                    .Left.JoinAlias(() => saleItemAlias.SKUItem, () => skuItemAlias)
                                                                    .OrderBy(() => saleAlias.DateOfSale).Desc
                                                                    .TransformUsing(Transformers.DistinctRootEntity).Take(25).List().ToList<Sale>();
                    }
                    else
                        saleList = session.QueryOver<Sale>(() => saleAlias)
                                                                    .JoinAlias(() => saleAlias.Customer, () => custAlias)
                                                                    .Left.JoinAlias(() => saleAlias.SaleItems, () => saleItemAlias)
                                                                    .Left.JoinAlias(() => saleItemAlias.SKUItem, () => skuItemAlias)
                                                                    .Where(Restrictions.On(() => custAlias.Name).IsLike(_name + "%"))
                                                                    .OrderBy(() => saleAlias.DateOfSale).Desc
                                                                    .TransformUsing(Transformers.DistinctRootEntity).List().ToList<Sale>();
                    return saleList;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static List<SKUItem> GetSalesItemList(string saleID)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var query = "select s.Name,s.ProductCode,s.Color,s.Material,s.Size from skuitem s " +
                                "inner join saleitem i on i.SKUID = s.ID " +
                                "where i.SaleID = :saleid";

                    NHibernate.IQuery sqlQuery = session.CreateSQLQuery(query)
                    .SetParameter("saleid", saleID)
                    .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(SKUItem)));
                    return sqlQuery.List<SKUItem>() as List<SKUItem>;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }

        public static IList GetSKUItemList(string _name = "", string _procode = "", string _desc = "",
                                                string _color = "", string _size = "", string _material = "")
        {
            IList _itemList;
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    _color = _color == "All" ? "" : _color;
                    _size = _size == "All" ? "" : _size;
                    _material = _material == "All" ? "" : _material;

                    if (string.IsNullOrEmpty(_name) && string.IsNullOrEmpty(_procode) && string.IsNullOrEmpty(_desc))
                    {
                        _itemList = (from sku in session.Query<SKUItem>()
                                     orderby sku.ID descending
                                     select new { sku.ID, ProductName = sku.Name, sku.ProductCode })
                                     .Distinct().Take(25).ToList();
                    }
                    else
                        _itemList = (from sku in session.Query<SKUItem>()
                                     //join v in session.Query<Vendor>() on sku.VendorID equals v.ID into gj
                                     where (sku.Name.StartsWith(_name) && sku.ProductCode.StartsWith(_procode) && sku.Description.Contains(_desc) &&
                                            sku.Color.StartsWith(_color) && sku.Color.StartsWith(_size) && sku.Color.StartsWith(_material) && sku.Quantity > 0)
                                     orderby sku.ID descending
                                     select new { sku.ID, ProductName = sku.Name, sku.ProductCode }).ToList();
                    return _itemList;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }
        #endregion Sale
    }
}
