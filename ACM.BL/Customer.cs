//Please note: This application is purely for my own education, to run through coding 
//examples by following tutorials, and to just tinker around with coding.  
//I know it’s bad practice to heavily comment code (code smell), but comments in all of my 
//exercises will largely be left intact as this serves me 2 purposes:
//    I want to retain what my original thought process was at the time
//    I want to be able to look back in 1..5..10 years to see how far I’ve come
//    And I enjoy commenting on things, however redundant this may be . . . 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

#region Project Notes
//Project was given to request a business system to track customer orders
//Extracting keywords from the proposal we come up with several classes
//Class: Customer {Name; Email address; Home address; Work address}
//Class: Product {Product name; Description; Current Price}
//Class: Order {Customer; Order Date; Shipping address}
//Class: Order Item {Product; Quantity; Purchase Price}
//As the program unfolds, these will be broken out further for “low coupling/high cohesion”
//Each class will also need its own functions: Validate(), Retrieve(), and Save()
//Repository Classes: Customer, Product, and Order will have a repository class to store the Retrieve() and Save() functions

//Abstraction - filtering out detail that is relevant 
//Encapsulation – Code embedded into a class that can’t be directly touched by other code

//Layering the application - 
//User Interface: Visible to the user, Logic to control the UI elements (the .exe)
//Business Logic: Logic to perform the business operations (DLL)
//Data Access: Logic to retrieve/save data to/from the database (DLL)
//Common: Common code (DLL)
//DLL – Dynamic Link Libraries: Attach to the program at run time, not build time
//Business Logic layer will be built using VS C# Class Library (.dll)
//Solution – ACM (Acme Customer Management)
//Project – ACM.BL (ACM business layer)

//Creating a "Code tester" seeing as we have no direct way to test a ".dll" project
//Adding a new solution folder to the solution "Tests"
//In "Tests" adding a new "Unit Test Project" called ACM.BLTest
//Add the reference to the ACM.BL
//Add test explorer window and run a test for specified conditions

//Use this test module to test various functions in the program to validate the code
//The testing format is using the Arrange, Actual, and Assertion tests
//This helps to test the logic of the application to see if tests pass/fail

//Signatures: a variables assigned name and its call function/parameters
//Such as: Retrieve(int customerId) or Retrieve()
//Both are different as they are called by:
//c1.Retrieve(5); and c1.Retrieve();
//Meaning Retrieve has 2 overload functions
//Overloading: a function with the same name but multiple different parameters

//Constructors: Whenever a class or struct is created, its constructor is called. 
//A class or struct may have multiple constructors that take different arguments. 
//Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.

//OOP:
//Identifying classes: Represents business entities, defines properties, defines methods (actions/behaviors)
//Separating Responsibilities: Minimize coupling, maximize cohesion, simplifies maintenance, improves testability
//Establishing Relationships: Defines how objects work together to perform operations of the application
//Leveraging Reuse: Involves extraction commonality and building reusable classes/components

//Classes: Abstract vs Concrete
//Most classes in this app are concrete.  Class.EntityBase is an abstract class
//Abstract classes: Serve as template for other classes to inherit properties from
//Abstract classes are useful when you need a class for the purpose of inheritance and polymorphism
//But, it makes no sense to instantiate the class itself, only its subclasses.
//To set up an inheritance class, put a colon (:) and the parent class after the class name
//ie. public class Product : EntityBase

//Reusable code: Creating common code that can be used in many other products
//Efficient way to save time and reuse common code
//Created a new project- Acme.Common to hold our common code (StringHandler)
//Created a new test project- Acme.CommonTest and the StringHandlerTest

//Creating a static function in a static class
//Notice the "this", when creating a static extension method
//This enables the use of much simpler code when writing:
//StringHandler.InsertSpaces(productName);
//This can become:
//productName.InsertSpaces

//Creating interface objects, see: ILoggable interface added to the Acme.Common 

//CustomerRepository: save(?) vs save()
#endregion

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable
    {
        // Constructor
        // Whenever a class or struct is created, its constructor is called. 
        // A class or struct may have multiple constructors that take different arguments. 
        // Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        public Customer()
            : this(0) //Constructor chaining.  this(0) points to the constructor below so either one can be called
        {

        }

        // Parameterized Constructor
        public Customer(int customerId)
        {
            this.CustomerId = customerId;

            // This creates the Address list below to an empty list, instead of a null
            AddressList = new List<Address>();
        }

        #region Global Properties

        // Instead of creating these address seperately, we can create a list
        //public Address WorkAddress { get; set; }
        //public Address HomeAddress { get; set; }
        public List<Address> AddressList { get; set; }

        // Adding in a property type for the type of customer, Govornment/ducator/Residential/Business
        public int CustomerType { get; set; }

        // Adding a static modifier that points to the class itself
        public static int InstanceCount { get; set; }

        // propfull (tab) - Sets up a full property block to set optional code in the get/set blocks
        private string _lastName;
        public string LastName
        {
            get
            {
                // Any code here
                return _lastName;
            }
            set { _lastName = value; }
        }

        // This property get/set can be used if no need to enter optional code in the get/set fields as above
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }

        // propg (tab) used for a property set/get but we dont want to allow a set property here from any external source
        public int CustomerId { get; private set; }

        // We use this property without the set function because we don't ever want this value changed as they are already declared above
        // Testing for a namespace that doens't have a first or last name
        public string FullName
        {
            // Tests for a name that is of only a persons Lastname and no first name provided
            get
            {
                // The fullname will be the last name
                string fullName = LastName;
                // If the FirstName string is not null
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    // If the fullName string is not null
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        // Will result in "fullname, "
                        fullName += ", ";
                    }
                    // fullname = fullname, Firstname
                    // Baggins, Bilbo
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        #endregion

        public override bool Validate()
        {
            // This states: the bool isValid if the LastName isn't blank
            bool isValid = !string.IsNullOrWhiteSpace(LastName);
            // Same as above, different format.
            // This states: If the email address is blank then it isn't valid
            if (string.IsNullOrWhiteSpace(EmailAddress))
                isValid = false;
            return isValid;
        }

        public override string ToString()
        {
            return FullName;
        }

        // Creating a log method to create a changelog
        public string Log()
        {
            var logString =
                this.CustomerId + ": " +
                this.FullName + " " +
                "Email: " + this.EmailAddress + " " +
                "Status: " + this.EntityState.ToString();

            return logString;
        }
    }
}
