using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Model
{
    class FaultsResponse
    {

        /// <summary>
        /// 
        /// </summary>
        public int draw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int recordsTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int recordsFiltered { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string queries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string input { get; set; }


    }
}
