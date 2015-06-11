using System;

namespace SpindleSoft.Model
{
    internal class Alteration
    {
        public int AlterationID { get; set; }

        public int CustomerID { get; set; }

        public DateTime PromiseDate { get; set; }

        public string Description { get; set; }

        public Alteration()
        {
                
        }

        public Alteration(int custid, string promisedate, string descrip)
        {
            this.CustomerID = custid;
            this.PromiseDate = Convert.ToDateTime(promisedate);
            this.Description = descrip;
        }
    }
}