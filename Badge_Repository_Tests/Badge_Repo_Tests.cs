using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badge_Repository_Tests
{
    [TestClass]
    public class Badge_Repo_Tests
    {
        //fields
        private Badge_Repo _badgeRepo;
        private Badge _testBadge;

        [TestInitialize]
        public void Arrange()
        {
            _testBadge = new Badge(new List<string> { "A1", "A5", "B2", "B4" });
            _badgeRepo = new Badge_Repo();
        }

        [TestMethod]
        public void AddNewBadgeID_ShouldShowCorrectBoolean()
        {
            //Arrange handled in testinitialize..so much easier
            bool success =_badgeRepo.AddNewBadgeID(_testBadge);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void ReadAllBadges_ShouldReturnCorrectCollectList()
        {
            _badgeRepo.AddNewBadgeID(_testBadge);
            
            var badgeList = _badgeRepo.ReadAllBadges();

            bool success = badgeList.ContainsValue(_testBadge);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void ReadOneBadgeByID_ShouldReturnCorrectContent()
        {
            _badgeRepo.AddNewBadgeID(_testBadge);

            var searchResult = _badgeRepo.ReadOneBadgeByID(_testBadge.BadgeID);

            Assert.AreEqual(searchResult.BadgeID, _testBadge.BadgeID);
        }
        [TestMethod]
        public void UpdateBadgeByID_ShouldReturnTrue()
        {
            _badgeRepo.AddNewBadgeID(_testBadge);
            
            var newContent = new Badge(new List<string> { "A1", "A2", "B1", "B2" });

            bool updateResult = _badgeRepo.UpdateBadgeByID(_testBadge.BadgeID, newContent);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteDoorsFromBadge_ShouldReturnTrue()
        {
            _badgeRepo.AddNewBadgeID(_testBadge);

            var removeDoor = "B4";

            bool removeResult = _badgeRepo.DeleteDoorsFromBadge(_testBadge.BadgeID, removeDoor);
            Assert.IsTrue(removeResult);
        }
        [TestMethod]
        public void AddDoorToBadge_ShouldReturnTrue()
        {
            _badgeRepo.AddNewBadgeID(_testBadge);
            var addDoor = "B3";
            bool addResult = _badgeRepo.AddDoorToBadge(_testBadge.BadgeID, addDoor);
            Assert.IsTrue(addResult);
        }
    }
}
