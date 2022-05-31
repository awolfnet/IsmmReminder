﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Util
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTimeSeconds(this DateTime datetime)
        {
            return (long)datetime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
        
    }
}
