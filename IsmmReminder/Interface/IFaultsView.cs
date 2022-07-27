using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Interface
{
    public interface IFaultsBrowserView
    {
        void SetController(Controller.Faults faults);
        Dictionary<string, string> GetCookie();

        void RefreshPage();
    }
}
