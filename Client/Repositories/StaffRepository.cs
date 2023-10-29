﻿using API.DTOs.Employees;
using Client.Contracts;

namespace Client.Repositories;

public class StaffRepository : GeneralRepository<EmployeeDto, Guid>, IStaffRepository
{
    public StaffRepository(string request = "") : base(request)
    {

    }
}
