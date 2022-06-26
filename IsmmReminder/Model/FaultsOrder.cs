using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Model
{
    public class FaultsOrder
    {
        /// <summary>
        /// Order id
        /// </summary>
        public string id { set; get; }
        /// <summary>
        /// FID
        /// </summary>
        public string fault_number { set; get; }

        /// <summary>
        /// Reported Date
        /// </summary>
        public string created_at { set; get; }

        /// <summary>
        /// Fault Acknowledged Date
        /// </summary>
        public string responded_date { set; get; }

        /// <summary>
        /// Responded on Site Date
        /// </summary>
        public string site_visited_date { set; get; }

        /// <summary>
        /// RA Conducted Date
        /// </summary>
        public string ra_acknowledged_date { set; get; }

        /// <summary>
        /// Work Started Date
        /// </summary>
        public string work_started_date { set; get; }

        /// <summary>
        /// Work Completed Date
        /// </summary>
        public string work_completed_date { set; get; }
    }
}
