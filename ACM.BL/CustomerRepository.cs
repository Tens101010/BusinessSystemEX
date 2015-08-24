using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        private AddressRepository addressRepository { get; set; }

        // Default constructor to add an instance of the address repository
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }

        public Customer Retrieve(int customerId)
        {
            // Create the instance of the Customer Class
            // customerId is a reference to the one in the Customer class
            // the reference points to the "private set" method
            Customer customer = new Customer(customerId);

            // Create an address list for that customer
            // since RetrieveByCustomerId is an IEnumeral, use .ToList() to convert to list item
            customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();

            // Temporary hard coded values to return a populated customer
            if (customerId == 1)
            {
                customer.EmailAddress = "fbaggins@hobbiton.me";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
            }
            return customer;
        }

        public List<Customer> Retrieve()
        {
            // returns a list of customers
            return new List<Customer>();
        }

        public bool Save(Customer customer)
        {
            // Code that saves the defined customer
            var success = true;
            if (customer.HasChanges && customer.IsValid)
            {
                if (customer.IsNew)
                {
                    //Call an insert function for a new customer
                }
                else
                {
                    //Call an update function
                }
            }
            return success;
        }
    }
}
