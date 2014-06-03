using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTests
{
    public class Product 
    {
        public static readonly string SQL_GET_ALL = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products]";
        public static readonly string SQL_GET_BY_ID = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products] WHERE ProductId = {0}";
        public static readonly string SQL_UPDATE = "UPDATE Products SET UnitPrice = {0}, UnitsInStock = {1} WHERE ProductId = {2}";

        public static string sqlGetById(int id)
        {
            string res = String.Format(SQL_GET_BY_ID, id);
            return res;
        }


        public static string sqlUpdate(Product p)
        {
            return  String.Format(SQL_UPDATE, p.UnitPrice, p.UnitsInStock, p.ProductID);
        }


        public int ProductID { get { return prodId; } }
        public string ProductName { set; get; }
        public decimal UnitPrice { set; get; }
        public short UnitsInStock { set; get; }

        private readonly int prodId;

        public Product(
            int productId,
            string productName,
            decimal unitPrice,
            short unitsInStock
)
        {
            prodId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public Product(SqlDataReader dr)
        {
            prodId = (int) dr["ProductId"];
            ProductName = (string)dr["ProductName"];
            UnitPrice = (decimal)dr["UnitPrice"];
            UnitsInStock = (short)dr["UnitsInStock"];
        }

        public override string ToString()
        {
            return "Product [id=" + ProductID + ", name=" + ProductName + ", price=" + UnitPrice
                    + ", stock=" + UnitsInStock + "]";
        }

    }

}
