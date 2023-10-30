﻿using API.DTOs.Departments;
using API.DTOs.Leaves;
using System.Collections;

namespace Client.Models;

public class AdminDashboardModels
{
    public LeaveStatisticDto? Statistic { get; set; }
    public IEnumerable<LeaveDto> LeaveHistory { get; set; }
    public IEnumerable<DepartmentDto> Departments { get; set; }
}
