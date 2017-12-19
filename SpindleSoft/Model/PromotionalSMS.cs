using System.Collections.Generic;

namespace SpindleSoft.Model
{
    public class SMSLog
    {
        public enum SectionType
        {
            Customer = 0,
            Order,
            Alteration,
            Sales
        }

        public virtual int ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual string Message { get; set; }

        public virtual SectionType SectionID { get; set; }

        public virtual string Status { get; set; }

        public virtual System.DateTime DateOfUpdate { get; set; }

        public SMSLog() { }

        public SMSLog(Customer cust, string msg, SectionType sectID, string status)
        {
            this.Customer = cust;
            this.Message = msg;
            this.SectionID = sectID;
            this.Status = status;
            this.DateOfUpdate = System.DateTime.Now.Date;
        }
    }
}