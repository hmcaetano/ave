using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public class Product 
    {
        public int ProductID { get; set;}
        public string ProductName { set; get; }
        public decimal UnitPrice { set; get; }
        public short UnitsInStock { set; get; }


        public Product() { }

        public Product(
            int productId,
            string productName,
            decimal unitPrice,
            short unitsInStock
)
        {
            ProductID = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public override string ToString()
        {
            return "Product [id=" + ProductID + ", name=" + ProductName + ", price=" + UnitPrice
                    + ", stock=" + UnitsInStock + "]";
        }

    }

}
