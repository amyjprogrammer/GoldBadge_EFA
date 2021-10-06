using Email_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Email_Repository_Tests
{
    [TestClass]
    public class Customer_Repo_Tests
    {
        private Customer_Repo _repo;
        private Customer _testCustomer;

        [TestInitialize]
        public void Arrange()
        {
            _testCustomer = new Customer("Jane", "Doe", CustomerType.Current);

            _repo = new Customer_Repo();

            _repo.AddACustomer(_testCustomer);
        }
        [TestMethod]
        public void AddACustomer_ShouldReturnTrue()
        {
            Assert.IsNotNull(_repo);
        }
        [TestMethod]
        public void ReviewAllCustomers_ShouldReturnCorrectList()
        {
            List<Customer> customerList = _repo.ReviewAllCustomers();

            bool success = customerList.Contains(_testCustomer);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetOneCustomerByID_ShouldReturnCorrectContent()
        {
            var searchResult = _repo.GetOneCustomerByID(_testCustomer.CustomerID);

            Assert.AreEqual(_testCustomer.FirstName, searchResult.FirstName);
        }
        [TestMethod]
        public void UpdateAllCustomerInfo_ShouldReturnTrue()
        {
            var newContent = new Customer("Jake", "Doe", CustomerType.Past);

            bool updateResult = _repo.UpdateAllCustomerInfo(_testCustomer, newContent);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void UpdateCustomerFirstName_ShouldReturnTrue()
        {
            var newContent = new Customer("Jake", "Doe", CustomerType.Past);

            bool updateResult = _repo.UpdateCustomerFirstName(_testCustomer, newContent.FirstName);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void UpdateCustomerLastName_ShouldReturnTrue()
        {
            var newContent = new Customer("Jake", "Doe", CustomerType.Past);

            bool updateResult = _repo.UpdateCustomerLastName(_testCustomer, newContent.LastName);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void UpdateCustomerType_ShouldReturnTrue()
        {
            var newContent = new Customer("Jake", "Doe", CustomerType.Past);

            bool updateResult = _repo.UpdateCustomerType(_testCustomer, newContent.TypeOfCustomer);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void RemoveCustomerByID_ShouldReturnTrue()
        {
            var contentToDelete = _repo.GetOneCustomerByID(_testCustomer.CustomerID);

            bool success = _repo.RemoveCustomerByID(contentToDelete);

            Assert.IsTrue(success);
        }

    }
}
