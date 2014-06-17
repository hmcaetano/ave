using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public class ProductDataMapper : AbstractDatatMapper<Product>
    {
        public static readonly string SQL_GET_ALL = "SELECT [ProductId], [ProductName], [UnitPrice], [UnitsInStock], [SupplierID] FROM [Northwind].[dbo].[Products]";
        public static readonly string SQL_GET_BY_ID = SQL_GET_ALL + " WHERE ProductId = @ProductId";
        public static readonly string SQL_UPDATE = "UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock WHERE ProductId = @ProductId";
        public static readonly string SQL_INSERT = "INSERT INTO Products (ProductName, UnitPrice, UnitsInStock, SupplierID) OUTPUT inserted.ProductID VALUES (@ProductName, @UnitPrice, @UnitsInStock, @SupplierID) ";

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
            cmd.Parameters.Add(new SqlParameter("@SupplierID", SqlDbType.Int));
            return cmd;
        }

        private readonly IDataMapper<Supplier> suppMapper;

        public ProductDataMapper(String connStr, IDataMapper<Supplier> suppMapper):base(connStr)
        {
            this.suppMapper = suppMapper;
        }

        public override Product GetById(int id)
        {
            using (SqlCommand cmdGet = sqlGetById(getConnection()))
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
                        suppMapper.GetById((int)dr[4]));
                    return newProd;
                }
            }
        }


        public override IEnumerable<Product> GetAll()
        {
            using (SqlCommand cmdGet = getConnection().CreateCommand())
            {
                cmdGet.CommandText = SQL_GET_ALL;
                using (SqlDataReader dr = cmdGet.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Product newProd = new Product(
                            (int)dr[0], (string)dr[1], (decimal)dr[2], (short)dr[3], suppMapper.GetById((int)dr[4]));
                        yield return newProd;
                    }
                }
            }

        }

        public override void Update(Product p)
        {
            using (SqlCommand cmdUpdate = sqlUpdate(getConnection()))
            {
                if (trx != null)
                    cmdUpdate.Transaction = trx;
                cmdUpdate.Parameters["@ProductName"].Value = p.ProductName;
                cmdUpdate.Parameters["@UnitPrice"].Value = p.UnitPrice;
                cmdUpdate.Parameters["@UnitsInStock"].Value = p.UnitsInStock;
                cmdUpdate.Parameters["@ProductID"].Value = p.ProductID;

                cmdUpdate.ExecuteNonQuery();
            }
        }


        public override void Delete(Product val)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Product val)
        {
            using (SqlCommand cmdInsert = sqlInsert(getConnection()))
            {
                cmdInsert.Parameters["@ProductName"].Value = val.ProductName;
                cmdInsert.Parameters["@UnitPrice"].Value = val.UnitPrice;
                cmdInsert.Parameters["@UnitsInStock"].Value = val.UnitsInStock;
                cmdInsert.Parameters["@SupplierID"].Value = val.Supplier.SupplierID;
                if (trx != null)
                    cmdInsert.Transaction = trx;
                val.ProductID = (int)cmdInsert.ExecuteScalar();
            }

        }
    }

}
