using System.Collections.Generic;

namespace SpindleSoft.Model
{
    internal class PromotionalSMS
    {
        public int SMSID { get; set; }

        public List<Group> Receipent { get; set; }

        public string Message { get; set; }

        public int StatusID { get; set; }
    }
}