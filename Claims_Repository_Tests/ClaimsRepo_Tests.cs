using Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Claims_Repository_Tests
{
    [TestClass]
    public class ClaimsRepo_Tests
    {
        [TestMethod]
        public void AddNewClaimToDirectory_ShouldReturnCorrectBoolean()
        {
            Claims content = new Claims();
            Claims_Repo repository = new Claims_Repo();

            bool success = repository.AddNewClaimToDirectory(content);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetAllClaimsFromDirectory_ShouldRetunrCorrectCollectList()
        {
            DateTime dateOfClaim = new DateTime(2021, 04,28);
            DateTime dateOfIncident = new DateTime(2021, 04, 27);
            Claims newClaim = new Claims(1, ClaimType.Car, "Wreck", 4000, dateOfIncident, dateOfClaim);
            Claims_Repo repo = new Claims_Repo();

            repo.AddNewClaimToDirectory(newClaim);

            Queue<Claims> claimsList = repo.GetAllClaimsFromDirectory();

            bool success = claimsList.Contains(newClaim);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void UpdateClaimInDirectory_ShouldReturnTrue()
        {
            DateTime dateOfClaim = new DateTime(2021, 04, 28);
            DateTime dateOfIncident = new DateTime(2021, 04, 27);
            Claims oldClaim = new Claims(1, ClaimType.Car, "Wreck", 4000, dateOfIncident, dateOfClaim);
            Claims_Repo repo = new Claims_Repo();

            repo.AddNewClaimToDirectory(oldClaim);

            Claims newClaim = new Claims(1, ClaimType.Car, "Wreck on 465", 4000, dateOfIncident, dateOfClaim);

            bool updateResult = repo.UpdateClaimInDirectory(oldClaim, newClaim);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void GetOneClaimFromDirectory_ShouldReturnCorrectClaim()
        {
            DateTime dateOfClaim = new DateTime(2021, 04, 28);
            DateTime dateOfIncident = new DateTime(2021, 04, 27);
            Claims newClaim = new Claims(1, ClaimType.Car, "Wreck", 4000, dateOfIncident, dateOfClaim);
            Claims_Repo repo = new Claims_Repo();

            repo.AddNewClaimToDirectory(newClaim);

            Claims searchResult = repo.GetOneClaimFromDirectory(1);

            Assert.AreEqual(newClaim.ClaimAmount, searchResult.ClaimAmount);
        }
    }
}
