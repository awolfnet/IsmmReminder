using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Model
{
    public class FaultsOrder
    {
        public string fault_number { set; get; }
        public string responded_date { set; get; }
        public string site_visited_date { set; get; }
        public string ra_acknowledged_date { set; get; }
        public string work_started_date { set; get; }
        public string work_completed_date { set; get; }
        public string user_acknowledge_date { set; get; }
    }
}
