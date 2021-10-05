using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class Claims_Repo
    {
        //field
        protected readonly Queue<Claims> _claimsDirectory = new Queue<Claims>();

        //Create
        public bool AddNewClaimToDirectory(Claims content)
        {
            int startingCount = _claimsDirectory.Count;

            _claimsDirectory.Enqueue(content);

            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Queue<Claims> GetAllClaimsFromDirectory()
        {
            return _claimsDirectory;
        }
        public Claims GetOneClaimFromDirectory(int specificClaimNum)
        {
            foreach (Claims claimsContent in _claimsDirectory)
            {
                if(claimsContent.ClaimID == specificClaimNum)
                {
                    return claimsContent;
                }
            }
            return null;
        }
        //update
        public bool UpdateClaimInDirectory(Claims existingContent, Claims newContent)
        {
            if(existingContent != null)
            {
                existingContent.ClaimID = newContent.ClaimID;
                existingContent.TypeOfClaim = newContent.TypeOfClaim;
                existingContent.ClaimAmount = newContent.ClaimAmount;
                existingContent.Description = newContent.Description;
                existingContent.DateOfClaim = newContent.DateOfClaim;
                existingContent.DateOfIncident = newContent.DateOfIncident;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteAllClaimsFromDirectory()
        {
            _claimsDirectory.Clear();
            bool removeResult = _claimsDirectory.Count == 0;
            return removeResult;
        }

    }
}
