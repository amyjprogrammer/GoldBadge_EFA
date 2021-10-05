using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class Badge_Repo
    {
        protected readonly Dictionary<int, Badge> _dictOfBadges = new Dictionary<int, Badge>();
        //int will be the Badge ID or Key
        //Badge- value with the lists of doors

        public bool AddNewBadgeID(Badge content)
        {
            int startingCount = _dictOfBadges.Count;

            _dictOfBadges.Add(content.BadgeID, content);

            bool wasAdded = (_dictOfBadges.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Dictionary<int, Badge> ReadAllBadges()
        {
            return _dictOfBadges;
        }
        public Badge ReadOneBadgeByID(int badgeID)
        {
            foreach (var badgeContent in _dictOfBadges)
            {
                if(badgeContent.Key == badgeID)
                {
                    return badgeContent.Value;
                }
            }
            return null;
        }
        public bool UpdateBadgeByID(int existingBadgeID, Badge newBadgeContent)
        {
            Badge oldInfo = ReadOneBadgeByID(existingBadgeID);

            if(oldInfo != null)
            {
                oldInfo.BadgeID = newBadgeContent.BadgeID;
                oldInfo.DoorName = newBadgeContent.DoorName;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDoorsFromBadge(int badgeID, string doorName)
        {
            Badge badgeInfo = ReadOneBadgeByID(badgeID);
            bool result = badgeInfo.DoorName.Remove(doorName);
            return result;
        }
        public bool AddDoorToBadge(int badgeID, string doorName)
        {
            Badge badgeInfo = ReadOneBadgeByID(badgeID);
            int startingCount = badgeInfo.DoorName.Count;
            badgeInfo.DoorName.Add(doorName);
            bool wasAdded = (badgeInfo.DoorName.Count > startingCount) ? true : false;
            return wasAdded;

        }
        public bool RemoveDoorByID(int badgeID)
        {
            bool success = _dictOfBadges.Remove(badgeID);
            return success;
        }
    }
}
