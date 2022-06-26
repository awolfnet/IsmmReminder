using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Model
{
    public class FaultsMessage
    {
        public string Destination { set; get; }
        public DateTime DeliverTime { set; get; }
        public string Message { set; get; }
    }
}
