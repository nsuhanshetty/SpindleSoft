using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Utilities
{
    class Secrets
    {
        public static Dictionary<string, string> FileLocation = new Dictionary<string, string>()
        {
            {"BaseDocDirectory",""},
            {"CustomerImages","Customer_ProfilePictures" },
            {"StaffImages","Staff_ProfilePictures" },
            {"StaffDocImages","Staff_SecurityDocuments" },
            {"OrderItemDocs","Order_OrderItemDocuments" },
            {"SKUItemDocs","SKUItem_SKUItemDocuments" },
            {"DBBackUp","DBBackUp_Path" }            
        };

        public static readonly string SMSGatewayUserName = "suhan";
        public static readonly string SMSGatewayPassword = "Suhan@123";
        public static readonly string ConnStringBackUp = "server=localhost;user=sa;pwd=sshetty;database=spindlesoftdb;Convert Zero Datetime=True;";
    }
}
