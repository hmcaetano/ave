using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public class ProductDataMapper: IDataMapper<Product>
    {
        public static readonly string SQL_GET_ALL = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products]";
        public static readonly string SQL_GET_BY_ID = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products] WHERE ProductId = @ProductId";
        public static readonly string SQL_UPDATE = "UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock WHERE ProductId = @ProductId";
        public static readonly string SQL_INSERT = "INSERT INTO Products (ProductName, UnitPrice, UnitsInStock) OUTPUT inserted.ProductID VALUES (@ProductName, @UnitPrice, @UnitsInStock) ";

        public static SqlCommand sqlGetById(SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = SQL_GET_BY_ID;
            cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int));
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

        private readonly SqlConnection c;

        public ProductDataMapper(SqlConnection c) {
            this.c = c;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            using (SqlCommand cmdGet = c.CreateCommand())
            {
                cmdGet.CommandText = SQL_GET_ALL;
                using (SqlDataReader dr = cmdGet.ExecuteReader())
                {
                    dr.Read();
                    Product newProd = new Product(
                        (int) dr[0], (string) dr[1], (decimal)dr[2], (short) dr[3]);
                    yield return newProd;
                }
            }

        }

        public void Update(Product val)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product val)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product val)
        {
            throw new NotImplementedException();
        }
    }
}
