using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    public class Outings_Repo
    {
        /* 1. AddOutingToDirectory()
         2. UpdateOutingInDirectory()
         3. GetAllOutings()
         4. GetOneOutingType()- by Type
         5. TotalCostForOutings()*/

        protected readonly List<Outings> _outingsRepo = new List<Outings>();
        public bool AddOutingToDirectory(Outings outingInfo)
        {
            int startingCount = _outingsRepo.Count;
            _outingsRepo.Add(outingInfo);
            bool addResult = (_outingsRepo.Count > startingCount) ? true : false;
            return addResult;
        }
        public List<Outings> GetAllOutings()
        {
            return _outingsRepo;
        }
        public Outings GetOneOutingType(EventType type)
        {
            foreach (var eventInfo in _outingsRepo)
            {
                if (eventInfo.TypeOfEvent == type)
                {
                    return eventInfo;
                }
            }
            return null;
        }
        public bool UpdateOutingInDirectory(Outings existingInfo, Outings newInfo)
        {
            if (existingInfo != null)
            {
                existingInfo.TypeOfEvent = newInfo.TypeOfEvent;
                existingInfo.NumPeopleAttended = newInfo.NumPeopleAttended;
                existingInfo.CostOfEvent = newInfo.CostOfEvent;
                existingInfo.DateOfEvent = newInfo.DateOfEvent;
                return true;
            }
            else
            {
                return false;
            }
        }
        public double TotalCostForOutings()
        {
            double count = 0;
            foreach (var outing in _outingsRepo)
            {
                count = count + outing.CostOfEvent;
            }
            return count;
        }
    }
}
