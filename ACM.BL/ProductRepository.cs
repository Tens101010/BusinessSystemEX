using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        // Retrieve one product
        public Product Retrieve(int productId)
        {
            // Create the instance of the product class
            // Pass in the requested Id
            Product product = new Product(productId);

            Object myObject = new Object();
            if (productId == 7)
            {
                Console.WriteLine("Objectwww: " + myObject.ToString());
                Console.WriteLine("Productwww: " + product.ToString());
            }

            // Temporary hard codded values to return
            // a populated product
            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted Size";
                product.CurrentPrice = 15.96M;
            }
            return product;
        }

        public bool Save(Product product)
        {
            var success = true;
            if (product.HasChanges && product.IsValid)
            {
                if (product.IsNew)
                {
                    //Call an insert stored procedure
                }
                else
                {
                    //Call an Update Stored Procedure
                }
            }
            return success;
        }
    }
}
