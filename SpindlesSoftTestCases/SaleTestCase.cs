using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpindleSoft.Savers;
using SpindleSoft.Model;

namespace SpindlesSoftTestCases
{
    public class SaleTestCase
    {
        [Test]
        [TestCase("prodName1","I am awesome", "Red", "M", "Cotton", 100, 200, null, true)]
        [TestCase("prodName2", "I am too awesome", "Green", "XL", "Polyster", 100, 200, null, true)]
        public void SaveSaleItem(string name, string desc, string color, string size, string material, int CP, int SP, int VendID, bool IsSelfMade)
        {
            SKUItem saleItem = new SKUItem();

            saleItem.Color = color;
            saleItem.CostPrice = CP;
            saleItem.SellingPrice = SP;
            saleItem.IsSelfMade = IsSelfMade;
            saleItem.Material = material;
            saleItem.Name = name;
            saleItem.Description = desc;
            saleItem.Size = size;
            saleItem.VendorID = VendID;

            bool success = SalesSaver.SaveSaleItemInfo(saleItem);
            Assert.AreEqual(success, true);
        }
    }
}
