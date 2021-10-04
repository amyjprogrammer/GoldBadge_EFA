using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
	public enum EventType { Golf, Bowling, Amusement_Park, Concert }
    public class Outings
    {
        public Outings() { }
        public Outings(EventType type, int numPeopleAttended, DateTime dateOfEvent, double costOfEvent)
        {
            TypeOfEvent = type;
            NumPeopleAttended = numPeopleAttended;
            DateOfEvent = dateOfEvent;
            CostOfEvent = costOfEvent;
        }

        public EventType TypeOfEvent { get; set; }
        public int NumPeopleAttended { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostOfEvent { get; set; }
        public double CostPerPersonForEvent 
        {
            get
            {
                return CostOfEvent / NumPeopleAttended;
            }  
        }
    }
}
