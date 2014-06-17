using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public abstract class AbstractDatatMapper<T>:IDataMapper<T>
    {
        private readonly String connStr;
        private SqlConnection c;
        protected SqlTransaction trx;
        
        public AbstractDatatMapper(string connStr){
            this.connStr = connStr;
        }

        protected SqlConnection getConnection()
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
            trx = getConnection().BeginTransaction();
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

        public abstract IEnumerable<T> GetAll();

        public abstract void Update(T val);

        public abstract void Delete(T val);

        public abstract void Insert(T val);
    }
}
