using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace NorthwindTests
{
    [TestClass]
    public class TestProducts
    {
        [TestMethod]
        public void test_products_count_all()
        {

            SqlConnection c = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                c = new SqlConnection();
                c.ConnectionString = @"
                Data Source=DRAGAO\SQLEXPRESS;
				Initial Catalog=Northwind;
                Integrated Security=True";
                c.Open();

                cmd = c.CreateCommand();
                cmd.CommandText = "SELECT [ProductID], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products]";

                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                    count++;

                Assert.AreEqual(77, count);
            }
            finally
            {
                dr.Dispose();
                cmd.Dispose();
                c.Dispose();
            }
        }
    }
}
