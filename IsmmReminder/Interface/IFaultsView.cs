using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Interface
{
    public interface IFaultsView
    {
        void SetController(Controller.Faults faults);
        Dictionary<string, string> GetCookie();
        
    }
}
