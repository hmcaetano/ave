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

        private string connstr = @"
                    Data Source=HELIOCAETANO-PC;
				    Initial Catalog=Northwind;
                    Integrated Security=True";
            

        [TestMethod]
        public void test_products_query_count()
        {
            using (ProductDataMapper mapper = new ProductDataMapper(connstr, new SupplierDataMapper(connstr)))
            {
                Assert.AreEqual(77, mapper.GetAll().Count());
            }
            
        }

 
        [TestMethod]
        public void test_product_insert()
        {
            using (SupplierDataMapper mapperSup = new SupplierDataMapper(connstr))
            {
                Product prod = new Product();
                prod.ProductName = "Enlatados";
                prod.UnitPrice = 78.9m;
                prod.UnitsInStock = 100;
                prod.Supplier = mapperSup.GetById(7);

                using (ProductDataMapper mapper = new ProductDataMapper(connstr, mapperSup))
                {
                    mapper.BeginTrx();
                    mapper.Insert(prod);

                    Product newProd = mapper.GetById(prod.ProductID);

                    Assert.AreEqual(prod.ProductID, newProd.ProductID);
                    Assert.AreEqual(prod.UnitPrice, newProd.UnitPrice);
                    Assert.AreEqual(prod.UnitsInStock, newProd.UnitsInStock);
                    Assert.AreEqual(prod.ProductName, newProd.ProductName);

                    mapper.Rollback();
                }
            }
        }

        [TestMethod]
        public void test_product_price_update()
        {

            using (ProductDataMapper mapper = new ProductDataMapper(connstr, new SupplierDataMapper(connstr)))
            {
                mapper.BeginTrx();
             
                Product p = mapper.GetById(7);  // 1. Fetch de um Product da BD
                Assert.AreEqual(30.0m, p.UnitPrice); // 2. confirmamos o estado inicial de product
                
                p.UnitPrice = 78;                    // 3. Act o objecto de domínio
                mapper.Update(p);               // 4. Act a BD em conformidade com o objecto de domínio
                Product newProd = mapper.GetById(7);          // 5. Novo fetch da BD
                Assert.AreEqual(p.UnitPrice, newProd.UnitPrice);   // 6. Confirmar que a BD foi mesmo alterada através do objecto de domínio
                
                mapper.Rollback();
            }
        }

    }
}
