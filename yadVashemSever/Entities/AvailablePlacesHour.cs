using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AvailablePlacesHour
    {
        public string StartTime { get; set; }
        public int availablePlaces { get; set; }
        public Boolean IsClose { get; set; }

    }
}
