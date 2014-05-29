using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace NorthwindTests
{
    [TestClass]
    public class TestProducts
    {

        private SqlConnection c;

        [TestInitialize]
        public void Setup()
        {
            c = new SqlConnection();
            c.ConnectionString = @"
                    Data Source=DRAGAO\SQLEXPRESS;
				    Initial Catalog=Northwind;
                    Integrated Security=True";
            c.Open();
        }

        [TestCleanup]
        public void TearDown()
        {
            if (c != null)
            {
                c.Dispose();
                c = null;
            }
        }

        [TestMethod]
        public void test_products_query_count()
        {
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM [Northwind].[dbo].[Products]";
                int count = (int)cmd.ExecuteScalar();
                Assert.AreEqual(77, count);
            }
        }

        [TestMethod]
        public void test_products_query_and_count_all()
        {
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT [ProductID], [ProductName], [UnitPrice], [UnitsInStock] FROM [Northwind].[dbo].[Products]";

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    int count = 0;
                    while (dr.Read())
                        count++;

                    Assert.AreEqual(77, count);
                }
            }
        }

        [TestMethod]
        public void test_product_price()
        {
            using (SqlTransaction trx = c.BeginTransaction())
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [ProductName], [UnitPrice] FROM [Northwind].[dbo].[Products] WHERE ProductId = 7";
                    cmd.Transaction = trx;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        Assert.AreEqual(30.0m, dr[1]);
                    }

                    cmd.CommandText = "UPDATE Products SET UnitPrice = 78 WHERE ProductId = 7";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT [ProductName], [UnitPrice] FROM [Northwind].[dbo].[Products] WHERE ProductId = 7";
                    cmd.Transaction = trx;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        Assert.AreEqual(78.0m, dr[1]);
                    }

                }
                trx.Rollback();
            }
        }

    }
}
