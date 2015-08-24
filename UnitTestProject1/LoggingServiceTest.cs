﻿using System;
using System.Collections.Generic;
using Acme.Common;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.CommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteFileTest()
        {
            //Arrange
            var changedItems = new List<ILoggable>();

            var customer = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = null
            };

            //Method1
            changedItems.Add((ILoggable)customer);

            var product = new Product(2)
            {
                ProductName = "Rake",
                ProductDescription = "Garden Rake with Steel Head",
                CurrentPrice = 6M
            };

            //Method2
            changedItems.Add(product as ILoggable);

            //Actual
            LoggingService.WriteToFile(changedItems);

            //Assert
            //Nothing here to assert
        }
    }
}