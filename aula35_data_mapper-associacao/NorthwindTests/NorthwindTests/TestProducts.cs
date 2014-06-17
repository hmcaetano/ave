using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using NorthwindDataMappers;

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
            ProductDataMapper mapper = new ProductDataMapper(c, new SupplierDataMapper(c));
            Assert.AreEqual(77, mapper.GetAll().Count());
            
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

                ProductDataMapper mapper = new ProductDataMapper(c, new SupplierDataMapper(c));
                mapper.Insert(prod, trx);

                Product newProd = mapper.GetById(prod.ProductID, trx);

                Assert.AreEqual(prod.ProductID, newProd.ProductID);
                Assert.AreEqual(prod.UnitPrice, newProd.UnitPrice);
                Assert.AreEqual(prod.UnitsInStock, newProd.UnitsInStock);
                Assert.AreEqual(prod.ProductName, newProd.ProductName);
                
                trx.Rollback();
            }
        }

        [TestMethod]
        public void test_product_price_update()
        {
            using (SqlTransaction trx = c.BeginTransaction())
            {
                ProductDataMapper mapper = new ProductDataMapper(c, new SupplierDataMapper(c));
                Product p = mapper.GetById(7, trx);  // 1. Fetch de um Product da BD
                Assert.AreEqual(30.0m, p.UnitPrice); // 2. confirmamos o estado inicial de product
                
                p.UnitPrice = 78;                    // 3. Act o objecto de domínio
                mapper.Update(p, trx);               // 4. Act a BD em conformidade com o objecto de domínio
                Product newProd = mapper.GetById(7, trx);          // 5. Novo fetch da BD
                Assert.AreEqual(p.UnitPrice, newProd.UnitPrice);   // 6. Confirmar que a BD foi mesmo alterada através do objecto de domínio
                
                trx.Rollback();
            }
        }

    }
}
