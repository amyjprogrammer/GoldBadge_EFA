using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repository;
using System;

namespace Outings_Repository_Tests
{
    [TestClass]
    public class Outings_Tests
    {
       [TestMethod]
        public void SetEventType_ShouldSetCorrectEnum()
        {
            Outings content = new Outings();
            content.TypeOfEvent = EventType.Concert;

            var expected = EventType.Concert;
            var actual = content.TypeOfEvent;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetNumPeopleAttended_ShouldSetCorrectInt()
        {
            var numOfPeople = new Outings();
            numOfPeople.NumPeopleAttended = 25;

            int expected = 25;
            int actual = numOfPeople.NumPeopleAttended;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetDateOfEvent_ShouldSetCorrectDate()
        {
            DateTime dt = new DateTime(2021, 10, 02);
            var date = new Outings();
            date.DateOfEvent = dt;

            DateTime expected = dt;
            DateTime actual = date.DateOfEvent;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetCostOfEvent_ShouldSetCorrectCostForEvent()
        {
            var cost = new Outings();
            cost.CostOfEvent = 125.25;

            var expected = 125.25;
            var actual = cost.CostOfEvent;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetCostOfPerPerson_ShouldSetCorrectCostPerPerson()
        {
            var outing = new Outings();
            outing.CostOfEvent = 100;
            outing.NumPeopleAttended = 4;
            var costPerPerson = outing.CostOfEvent / outing.NumPeopleAttended;

            var expected = 25;
            var actual = costPerPerson;

            Assert.AreEqual(expected, actual);
        }
    }
}
