using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public class SupplierDataMapper: AbstractDatatMapper<Supplier>
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

        
        public SupplierDataMapper(String connstr): base(connstr)
        {
            
        }

        public override  Supplier GetById(int id)
        {
            using (SqlCommand cmdGet = sqlGetById(getConnection()))
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


        public override IEnumerable<Supplier> GetAll()
        {
            using (SqlCommand cmdGet = getConnection().CreateCommand())
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

        public override void Update(Supplier val)
        {
            using (SqlCommand cmdUpdate = sqlUpdate(getConnection()))
            {
                if(trx != null) 
                    cmdUpdate.Transaction = trx;
                cmdUpdate.Parameters["@CompanyName"].Value = val.CompanyName;
                cmdUpdate.Parameters["@SupplierID"].Value = val.SupplierID;

                cmdUpdate.ExecuteNonQuery();
            }
        }


        public override void Delete(Supplier val)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Supplier val) 
        {
            using (SqlCommand cmdInsert = sqlInsert(getConnection()))
            {
                cmdInsert.Parameters["@CompanyName"].Value = val.CompanyName;
                if(trx != null) 
                    cmdInsert.Transaction = trx;
                val.SupplierID = (int)cmdInsert.ExecuteScalar();
            }

        }

    }
}
