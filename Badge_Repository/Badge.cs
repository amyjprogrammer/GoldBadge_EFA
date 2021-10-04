using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class Badge
    {
        public Badge() { }
        public Badge(List<string> doorName)
        {
            DoorName = doorName;
        }
        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; }
    }
}
