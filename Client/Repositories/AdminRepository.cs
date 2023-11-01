using API.DTOs.Accounts;
using API.DTOs.Departments;
using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.DTOs.LeaveTypes;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Client.Repositories;

public class AdminRepository : IAdminRepository
{
    private HttpClient httpClient;

    public AdminRepository()
    {
        this.httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7064/api/")
        };
    }

    public async Task<ResponseOkHandler<string>> DeleteEmployee(Guid guid)
    {
        ResponseOkHandler<string> entityVM = null;

        using (var response = httpClient.DeleteAsync("Admin/Employees/Delete/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>> GetAllEmployee()
    {
        ResponseOkHandler<IEnumerable<EmployeeDetailsDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Employees/"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<EmployeeDetailsDto>> GetEmployeeByGuid(Guid guid)
    {
        ResponseOkHandler<EmployeeDetailsDto> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Employees/" + guid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<EmployeeDetailsDto>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<string>> RegisterEmployee(RegisterDto entity)
    {
        ResponseOkHandler<string> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

        using (var response = httpClient.PostAsync("Admin/Employees/Register", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
        }

        return entityVM;
    }

    // LEAVE REPOSITORY

    public async Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetAllLeave()
    {
        ResponseOkHandler<IEnumerable<LeaveDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Leaves/Histories"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveDto>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetRejectedLeave()
    {
        ResponseOkHandler<IEnumerable<LeaveDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Leaves/Rejected"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveDto>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetApprovedLeave()
    {
        ResponseOkHandler<IEnumerable<LeaveDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Leaves/Approved"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveDto>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetPendingLeave()
    {
        ResponseOkHandler<IEnumerable<LeaveDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Leaves/Pending"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveDto>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<LeaveDetailAdminDto>> GetLeaveDetail(Guid guid)
    {
        ResponseOkHandler<LeaveDetailAdminDto> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Leaves/Details/" + guid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<LeaveDetailAdminDto>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<string>> UpdateLeaveStatus(EditLeaveDto entity)
    {
        ResponseOkHandler<string> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

        using (var response = httpClient.PutAsync("Admin/Leaves/Edit", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<LeaveStatisticDto>> GetStatistic()
    {
        ResponseOkHandler<LeaveStatisticDto> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Leaves/Statistics"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<LeaveStatisticDto>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<IEnumerable<DepartmentDto>>> GetAllDepartment()
    {
        ResponseOkHandler<IEnumerable<DepartmentDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/Departments"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<DepartmentDto>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<string>> UpdateEmployee(EditEmployeeDto entity)
    {
        ResponseOkHandler<string> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

        using (var response = httpClient.PutAsync("Admin/Employees/Edit", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
        }

        return entityVM;
    }
}
