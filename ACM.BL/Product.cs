using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {

        }

        public Product(int productId)
        {
            this.ProductId = productId;
        }

        // Decimal? = the allowance of an nullable value such as $0.00 makes this valid
        // having no price isn't valid
        public Decimal? CurrentPrice { get; set; }

        public int ProductId { get; private set; }

        public string ProductDescription { get; set; }

        // Using the Acme.Common code reference (and using statement)
        // See StringHandler.cs for code referenced here
        private String _ProductName;

        public String ProductName
        {
            get { return _ProductName.InsertSpaces(); }
            set { _ProductName = value; }
        }

        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;
            return isValid;
        }

        public override string ToString()
        {
            return ProductName;
        }

        // Creating a log method to create a changelog
        public string Log()
        {
            var logString =
                this.ProductId + ": " +
                this.ProductName + " " +
                "Detail: " + this.ProductDescription + " " +
                "Status: " + this.EntityState.ToString();

            return logString;
        }
    }
}
