using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Interface
{
    public interface IMessage
    {
        void SetController(Controller.Faults faults);
        void SendMesage(string Contact, string Message);
    }
}
