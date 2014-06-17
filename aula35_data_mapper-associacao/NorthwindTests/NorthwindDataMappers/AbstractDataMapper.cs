using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public abstract class AbstractDataMapper<T>:IDataMapper<T>
    {
        private readonly String connStr;
        private SqlConnection c;
        protected SqlTransaction trx;
        
        public AbstractDataMapper(string connStr){
            this.connStr = connStr;
        }

        protected SqlConnection GetConnection()
        {
            if (c == null)
            {
                c = new SqlConnection();
                c.ConnectionString = this.connStr;
                c.Open();
            }
            return c;
        }

        public void BeginTrx()
        {
            if (trx != null) throw new InvalidOperationException("Transaction already initialized!");
            trx = GetConnection().BeginTransaction();
        }

        public void Rollback()
        {
            trx.Rollback();
        }

        public void Commit()
        {
            trx.Commit();
        }

        public void Dispose()
        {
            if (trx != null)
            {
                trx.Dispose();
                trx = null;
            }
            if (c != null)
            { 
                c.Dispose();
                c = null;
            }
        }

        public abstract T GetById(int id);

        protected abstract SqlCommand GetUpdateCommand(SqlConnection connection);

        protected abstract String GetSqlGetAllQuery();

        protected abstract T NewInstance(SqlDataReader dr);

        public IEnumerable<T> GetAll()
        {
            using (SqlCommand cmdGet = GetConnection().CreateCommand())
            {
                cmdGet.CommandText = GetSqlGetAllQuery();
                using (SqlDataReader dr = cmdGet.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        yield return NewInstance(dr);
                    }
                }
            }
        }

        public virtual void Update(T val)
        {
            using (SqlCommand command = GetUpdateCommand(GetConnection()))
            {
                if (trx != null)
                    command.Transaction = trx;
               SetSqlUpdateParameters(command, val);

                command.ExecuteNonQuery();
            }
        }

        protected abstract void SetSqlUpdateParameters(SqlCommand command, T val);

        protected abstract void SetSqlInsertParameters(SqlCommand command, T val);

        public abstract void Delete(T val);

        protected abstract SqlCommand GetInsertCommand(SqlConnection connection);

        //public abstract void Insert(T val);
        
        public virtual int Insert(T val)
        {
            using (SqlCommand command = GetInsertCommand(GetConnection()))
            {
               SetSqlInsertParameters(command, val);
                if (trx != null)
                    command.Transaction = trx;
                return (int)command.ExecuteScalar();
            }
        }
    }
}
