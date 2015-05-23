using System;

namespace SpindleSoft.Model
{
    internal class Alteration
    {
        public int AlterationID { get; set; }

        public int CustomerID { get; set; }

        public DateTime PromiseDate { get; set; }

        public string Description { get; set; }
    }
}