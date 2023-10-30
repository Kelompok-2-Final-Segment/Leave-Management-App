﻿using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.DTOs.LeaveTypes;
using API.Utilities.Handlers;

namespace Client.Contracts;

public interface IAdminRepository
{
    // Employee Repository
    Task<ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>> GetAllEmployee();
    Task<ResponseOkHandler<EmployeeDetailsDto>> GetEmployeeByGuid(Guid guid);
    Task<ResponseOkHandler<string>> RegisterEmployee(RegisterDto entity);
    Task<ResponseOkHandler<string>> DeleteEmployee(Guid guid);

    // Leave Repository
    Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetAllLeave();
    Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetRejectedLeave();
    Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetApprovedLeave();
}