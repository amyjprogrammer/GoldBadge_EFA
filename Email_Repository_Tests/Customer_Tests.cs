using Email_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Email_Repository_Tests
{
    [TestClass]
    public class Customer_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]//tells the system to expect an exception
        public void InvalidFirstNameNoChar_ShouldThrowFormatException()
        {
            var test = new Customer();
            test.FirstName = "";//making sure it has at least one character
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]//tells the system to expect an exception
        public void InvalidFirstNameSymbol_ShouldThrowFormatException()
        {
            var test = new Customer();
            test.FirstName = "$#";//making sure it is letters
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]//tells the system to expect an exception
        public void InvalidLastNameNoChar_ShouldThrowFormatException()
        {
            var test = new Customer();
            test.LastName = "";//making sure it has at least one character
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void MyTestMethodInvalidLastNameSymbol_ShouldThrowFormatException()
        {
            var test = new Customer();
            test.LastName = "^&";//making sure it is letters
        }
        [TestMethod]
        public void SetFullName_ShouldReturnCorrectName()
        {
            var test = new Customer("Bob", "Smith", CustomerType.Current);

            string expected = "Bob Smith";
            string actual = test.FullName;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetCustomerID_ShouldReturnCorrectValue()
        {
            var testID = new Customer();
            testID.CustomerID = 1;

            int expected = 1;
            int actual = testID.CustomerID;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetCustomerType_ShouldReturnCorrectType()
        {
            var testCustomerType = new Customer("It", "Addams", CustomerType.Past);

            var expected = CustomerType.Past;
            var actual = testCustomerType.TypeOfCustomer;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EmailMessage_ShouldReturnCorrectMessageForType()
        {
            var testEmail = new Customer("The", "Shining", CustomerType.Potential);

            var expected = "We currently have the lowest rates on Helicopter Insurance!";
            var actual = testEmail.EmailMessage;

            Assert.AreEqual(expected, actual);
        }
    }
}
