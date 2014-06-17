using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindDataMappers
{
    public class Supplier
    {
        public Supplier(int p1, string p2)
        {
            this.SupplierID = p1;
            this.CompanyName = p2;
        }

        public int SupplierID{get; set;}
        public string CompanyName { get; set; }

    }
}
