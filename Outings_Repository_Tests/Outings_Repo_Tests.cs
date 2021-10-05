using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repository;
using System;
using System.Collections.Generic;

namespace Outings_Repository_Tests
{
    [TestClass]
    public class Outings_Repo_Tests
    {
        private Outings_Repo _repo;
        private Outings _testOuting;

        [TestInitialize]
        public void Arrange()
        {
            DateTime dt = new DateTime(2021, 10, 01);
            _testOuting = new Outings(EventType.Bowling, 25, dt, 100);
            _repo = new Outings_Repo();

            _repo.AddOutingToDirectory(_testOuting);
        }

        [TestMethod]
        public void AddOutingToDirectory_ShouldReturnTrue()
        {
            //Arrange and Act taken care of in Arrange()
            Assert.IsNotNull(_repo);
        }
        [TestMethod]
        public void GetAllOutings_ShouldReturnCorrectList()
        {
            List<Outings> outingsList = _repo.GetAllOutings();

            bool success = outingsList.Contains(_testOuting);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetOneOutingType_ShouldReturnCorrectContent()
        {
            var searchResult = _repo.GetOneOutingType(EventType.Bowling);

            Assert.AreEqual(_testOuting.TypeOfEvent, searchResult.TypeOfEvent);
        }
        [TestMethod]
        public void UpdateOutingInDirectory_ShouldReturnTrue()
        {
            DateTime dt = new DateTime(2021, 10, 01);
            var contentToUpdate = _repo.GetOneOutingType(EventType.Bowling);
            var newContent = new Outings(EventType.Bowling, 20, dt, 120);
            bool updateResult = _repo.UpdateOutingInDirectory(contentToUpdate, newContent);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void TotalCostForOutings_ShouldReturnCorrectAmount()
        {
            var expected = 100;
            var actual = _repo.TotalCostForOutings();

            Assert.AreEqual(expected, actual);
        }

    }
}
