using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Model
{
    public class BackUpLog
    {
        public virtual int ID { get; set; }
        public virtual string FileName { get; set; }
        public virtual DateTime DateOfUpdate { get; set; }
    }
}
