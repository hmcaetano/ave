using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTests
{
    public class Product 
    {
        public static readonly string SQL_GET_ALL = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products]";
        public static readonly string SQL_GET_BY_ID = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products] WHERE ProductId = @ProductId";
        public static readonly string SQL_UPDATE = "UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock WHERE ProductId = @ProductId";
        public static readonly string SQL_INSERT = "INSERT INTO Products (ProductName, UnitPrice, UnitsInStock) OUTPUT inserted.ProductID VALUES (@ProductName, @UnitPrice, @UnitsInStock) ";

        public static SqlCommand sqlGetById(SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = SQL_GET_BY_ID;
            cmd.Parameters.Add(new SqlParameter("@ProductId",SqlDbType.Int));
            return cmd;
        }


        public static SqlCommand sqlUpdate(SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = SQL_UPDATE;
            cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@UnitsInStock", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
            return cmd;
        }

        public static SqlCommand sqlInsert(SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = SQL_INSERT;
            cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@UnitsInStock", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
            return cmd;
        }

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

        public Product(SqlDataReader dr)
        {
            ProductID = (int) dr["ProductId"];
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
