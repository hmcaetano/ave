using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public class SupplierDataMapper: IDataMapper<Supplier>
    {
        public static readonly string SQL_GET_ALL = "SELECT [SupplierID],[CompanyName] FROM [Northwind].[dbo].[Suppliers]";
        public static readonly string SQL_GET_BY_ID = SQL_GET_ALL + " WHERE SupplierID = @SupplierID";
        public static readonly string SQL_UPDATE = "";
        public static readonly string SQL_INSERT = "";

        public static SqlCommand sqlGetById(SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = SQL_GET_BY_ID;
            cmd.Parameters.Add(new SqlParameter("@SupplierID", SqlDbType.Int));
            return cmd;
        }


        public static SqlCommand sqlUpdate(SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = SQL_UPDATE;
            cmd.Parameters.Add(new SqlParameter("@SupplierID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar));
            return cmd;
        }

        public static SqlCommand sqlInsert(SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = SQL_INSERT;
            cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar));
            return cmd;
        }

        private readonly SqlConnection c;

        public SupplierDataMapper(SqlConnection c)
        {
            this.c = c;
        }

        public Supplier GetById(int id)
        {
            return GetById(id, null);
        }
        public Supplier GetById(int id, SqlTransaction trx)
        {
            using (SqlCommand cmdGet = sqlGetById(c))
            {
                if (trx != null)
                    cmdGet.Transaction = trx;

                cmdGet.Parameters["@SupplierID"].Value = id;
                using (SqlDataReader dr = cmdGet.ExecuteReader())
                {
                    dr.Read();
                    return new Supplier((int) dr[0], (string) dr[1]);
                }
            }
        }


        public IEnumerable<Supplier> GetAll()
        {
            using (SqlCommand cmdGet = c.CreateCommand())
            {
                cmdGet.CommandText = SQL_GET_ALL;
                using (SqlDataReader dr = cmdGet.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        yield return new Supplier((int)dr[0], (string)dr[1]);
                    }
                }
            }

        }

        public void Update(Supplier val)
        {
            Update(val, null);
        }

        public void Update(Supplier p, SqlTransaction trx)
        {
            using (SqlCommand cmdUpdate = sqlUpdate(c))
            {
                if(trx != null) 
                    cmdUpdate.Transaction = trx;
                cmdUpdate.Parameters["@CompanyName"].Value = p.CompanyName;
                cmdUpdate.Parameters["@SupplierID"].Value = p.SupplierID;

                cmdUpdate.ExecuteNonQuery();
            }
        }


        public void Delete(Supplier val)
        {
            throw new NotImplementedException();
        }

        public void Insert(Supplier val) {
            Insert(val, null);
        }

        public void Insert(Supplier val, SqlTransaction trx)
        {
            using (SqlCommand cmdInsert = sqlInsert(c))
            {
                cmdInsert.Parameters["@CompanyName"].Value = val.CompanyName;
                if(trx != null) 
                    cmdInsert.Transaction = trx;
                val.SupplierID = (int)cmdInsert.ExecuteScalar();
            }

        }

    }
}
