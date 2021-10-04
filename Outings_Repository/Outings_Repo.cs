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
    }
}
