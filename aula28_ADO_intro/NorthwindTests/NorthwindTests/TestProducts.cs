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
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = @"
                    Data Source=DRAGAO\SQLEXPRESS;
				    Initial Catalog=Northwind;
                    Integrated Security=True";
                c.Open();

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
        }
    }
}
