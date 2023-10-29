using API.DTOs.Accounts;
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
            BaseAddress = new Uri("https://localhost:7064/api/Admin/")
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


        using (var response = await httpClient.GetAsync("Employees/"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<EmployeeDetailsDto>> GetEmployeeByGuid(Guid guid)
    {
        ResponseOkHandler<EmployeeDetailsDto> entityVM = null;


        using (var response = await httpClient.GetAsync("Employees/" + guid))
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

        using (var response = httpClient.PostAsync("Employees/Register", content).Result)
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


        using (var response = await httpClient.GetAsync("Leaves/"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveDto>>>(apiResponse);
        }

        return entityVM;
    }
}
