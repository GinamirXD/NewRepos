using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Associations
{
    public class Customer
    {
        public int Code { get; set; }
        public int ContactPhone { get; set; }
        public string FullName { get; set; }
        public bool Privileged { get; set; }

        public override string ToString()
        {
            return $"Покупатель {Code} -  {FullName} {ContactPhone} Privileged:{Privileged}";
        }
    }
}
