﻿using EventBus.Messages.EventObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class AssignEmployeesEvent : IntegrationBaseEvent
    {
        public List<EmployeeEO> Employees { get; set; }
    }
}
