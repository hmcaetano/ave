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
        public void test_product_insert()
        {
            Product prod = new Product();
            prod.ProductName = "Enlatados";
            prod.UnitPrice = 78.9m;
            prod.UnitsInStock = 100;

            using (SqlTransaction trx = c.BeginTransaction())
            {
                using (SqlCommand cmdInsert = Product.sqlInsert(c))
                {
                    cmdInsert.Parameters["@ProductName"].Value = prod.ProductName;
                    cmdInsert.Parameters["@UnitPrice"].Value = prod.UnitPrice;
                    cmdInsert.Parameters["@UnitsInStock"].Value = prod.UnitsInStock;
                    cmdInsert.Transaction = trx;
                    prod.ProductID = (int)cmdInsert.ExecuteScalar();
                }

                using (SqlCommand cmdGet = Product.sqlGetById(c))
                {

                    cmdGet.Parameters["@ProductId"].Value = prod.ProductID;
                    cmdGet.Transaction = trx;
                    Product newProd = null;
                    using (SqlDataReader dr = cmdGet.ExecuteReader())
                    {
                        dr.Read();
                        newProd = new Product(dr);
                        Assert.AreEqual(prod.ProductID, newProd.ProductID);
                        Assert.AreEqual(prod.UnitPrice, newProd.UnitPrice);
                        Assert.AreEqual(prod.UnitsInStock, newProd.UnitsInStock);
                        Assert.AreEqual(prod.ProductName, newProd.ProductName);
                    }
                }
                trx.Rollback();
            }
        }

        [TestMethod]
        public void test_product_price_update()
        {
            using (SqlTransaction trx = c.BeginTransaction())
            {
                using (SqlCommand cmd = Product.sqlGetById(c))
                {
                    
                    cmd.Parameters["@ProductId"].Value = 7;
                    cmd.Transaction = trx;
                    Product p = null;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        p = new Product(dr);
                        Assert.AreEqual(30.0m, p.UnitPrice);
                    }

                    p.UnitPrice = 78;
                    using (SqlCommand cmdUpdate = Product.sqlUpdate(c))
                    {
                        cmdUpdate.Transaction = trx;
                        cmdUpdate.Parameters["@ProductName"].Value = p.ProductName;
                        cmdUpdate.Parameters["@UnitPrice"].Value = p.UnitPrice;
                        cmdUpdate.Parameters["@UnitsInStock"].Value = p.UnitsInStock;
                        cmdUpdate.Parameters["@ProductID"].Value = p.ProductID;

                        cmdUpdate.ExecuteNonQuery();
                    }
                    cmd.Parameters["@ProductId"].Value = p.ProductID; // O mesmo cmd com novo Bind
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
