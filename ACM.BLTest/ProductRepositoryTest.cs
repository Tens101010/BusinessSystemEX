using System;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void ProductRepositoryRetrieveTest()
        {
            //Blindly testing around
            Product product = new Product(7);
            Object myObject = new Object();
            Console.WriteLine("Peep " + myObject.ToString());
            Console.WriteLine("Bloop " + product.ToString());
            var productRepository = new ProductRepository();
            Console.WriteLine("Nerp " + productRepository);
            var actual = productRepository.Retrieve(7);
        }
    }
}