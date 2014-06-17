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
        public static readonly string SQL_GET_ALL = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock], [SupplierID] FROM [Northwind].[dbo].[Products]";
        public static readonly string SQL_GET_BY_ID = SQL_GET_ALL + " WHERE ProductId = @ProductId";
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
        private readonly IDataMapper<Supplier> suppMapper;

        public ProductDataMapper(SqlConnection c, IDataMapper<Supplier> suppMapper)
        {
            this.c = c;
            this.suppMapper = suppMapper;
        }

        public Product GetById(int id)
        {
            return GetById(id, null);
        }
        public Product GetById(int id, SqlTransaction trx)
        {
            using (SqlCommand cmdGet = sqlGetById(c))
            {
                if (trx != null)
                    cmdGet.Transaction = trx;

                cmdGet.Parameters["@ProductId"].Value = id;
                using (SqlDataReader dr = cmdGet.ExecuteReader())
                {
                    dr.Read();
                    Product newProd = new Product(
                        (int)dr[0], 
                        (string)dr[1], 
                        (decimal)dr[2], 
                        (short)dr[3], 
                        suppMapper.GetById((int) dr[4]));
                    return newProd;
                }
            }
        }


        public IEnumerable<Product> GetAll()
        {
            using (SqlCommand cmdGet = c.CreateCommand())
            {
                cmdGet.CommandText = SQL_GET_ALL;
                using (SqlDataReader dr = cmdGet.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Product newProd = new Product(
                            (int)dr[0], (string)dr[1], (decimal)dr[2], (short)dr[3], suppMapper.GetById((int) dr[4]));
                        yield return newProd;
                    }
                }
            }

        }

        public void Update(Product val)
        {
            Update(val, null);
        }

        public void Update(Product p, SqlTransaction trx)
        {
            using (SqlCommand cmdUpdate = sqlUpdate(c))
            {
                if(trx != null) 
                    cmdUpdate.Transaction = trx;
                cmdUpdate.Parameters["@ProductName"].Value = p.ProductName;
                cmdUpdate.Parameters["@UnitPrice"].Value = p.UnitPrice;
                cmdUpdate.Parameters["@UnitsInStock"].Value = p.UnitsInStock;
                cmdUpdate.Parameters["@ProductID"].Value = p.ProductID;

                cmdUpdate.ExecuteNonQuery();
            }
        }


        public void Delete(Product val)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product val) {
            Insert(val, null);
        }

        public void Insert(Product val, SqlTransaction trx)
        {
            using (SqlCommand cmdInsert = sqlInsert(c))
            {
                cmdInsert.Parameters["@ProductName"].Value = val.ProductName;
                cmdInsert.Parameters["@UnitPrice"].Value = val.UnitPrice;
                cmdInsert.Parameters["@UnitsInStock"].Value = val.UnitsInStock;
                if(trx != null) 
                    cmdInsert.Transaction = trx;
                val.ProductID = (int)cmdInsert.ExecuteScalar();
            }

        }

    }
}
