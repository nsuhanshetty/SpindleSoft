using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Model
{
    public class Document
    {
        public virtual int ID { get; set; }
        public virtual string Type { get; set; }
        public virtual string Path { get; set; }
        public virtual Image Image { get; set; }
        public virtual DateTime DateUpdated { get; set; }
    }

    public class SecurityDocument : Document
    {
        public virtual Staff Staff { get; set; }
    }

    public class OrderItemDocument : Document
    {
        public virtual OrderItem orderItem { get; set; }
    }
}
