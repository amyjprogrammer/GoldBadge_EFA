using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
	public enum ClaimType { Car = 1, Home, Theft}
    public class Claims
	{
        public Claims() { }
        public Claims(int claimID, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {
                DateTime DateOfClaim = new DateTime();
                DateTime DateOfIncident = new DateTime();
                TimeSpan value = DateOfClaim.Subtract(DateOfIncident);
                if(value.TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
