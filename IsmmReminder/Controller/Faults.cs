using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace IsmmReminder.Controller
{
    public class Faults
    {
        public Timer _timer=null;
        
        public void StartMonitor()
        {
            if(_timer==null)
            {
                _timer = new Timer();
            }

            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = 60 * 1000;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
        }

        public void StopMonitor()
        {
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }
    }
}
