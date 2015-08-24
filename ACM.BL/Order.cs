using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace ACM.BL
{
    public class Order : EntityBase, ILoggable
    {
        public Order()
        {

        }

        public Order(int orderId)
        {
            this.OrderId = orderId;
        }

        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }
        public List<OrderItem> orderItems { get; private set; }

        public override bool Validate()
        {
            // For isValid to be true the Order date must NOT be null
            bool isValid = !(OrderDate == null);
            return isValid;
        }

        public override string ToString()
        {
            return OrderDate.Value.Date + " (" + OrderId + ")";
        }

        //ILoggable interface from class member
        public string Log()
        {
                var logString =
                    this.OrderId + ": " +
                    "Date: " + this.OrderDate.Value.Date + " " +
                    "Status: " + this.EntityState.ToString();

                return logString;
        }
    }
}
