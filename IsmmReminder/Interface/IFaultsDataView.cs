﻿using IsmmReminder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsmmReminder.Interface
{
    public interface IFaultsDataView
    {
        void SetController(Controller.Faults faults);

        void UpdateDatatable(List<FaultsOrder> orders);

        DataGridViewRowCollection GetDatatable();

        void Insert();
    }
}
