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
                    cmd.CommandText = Product.sqlGetById(7);
                    cmd.Transaction = trx;
                    Product p = null;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        p = new Product(dr);
                        Assert.AreEqual(30.0m, p.UnitPrice);
                    }

                    p.UnitPrice = 78;
                    cmd.CommandText = Product.sqlUpdate(p);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = Product.sqlGetById(p.ProductID);
                    cmd.Transaction = trx;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        p = new Product(dr);
                        Assert.AreEqual(78.0m, p.UnitPrice);
                    }

                }
                trx.Rollback();
            }
        }

    }
}
