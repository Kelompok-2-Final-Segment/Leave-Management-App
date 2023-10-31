using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories;

public class StaffRepository : GeneralRepository , IStaffRepository
{
    public StaffRepository(string request = "Staff/") : base(request)
    {

    }
    public async Task<ResponseOkHandler<IEnumerable< AvailableLeaveDto>>> GetAvailableLeaves(Guid guid)
    {
        ResponseOkHandler<IEnumerable< AvailableLeaveDto>> entityVM = null;
        using (var response = httpClient.GetAsync(request + urlLeaves + "Available/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<AvailableLeaveDto>>>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseOkHandler<EmployeeDto>> Profile(Guid guid)
    {
        ResponseOkHandler<EmployeeDto> entityVM = null;
        using (var response = httpClient.GetAsync(request  + "Profile/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<EmployeeDto>>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseOkHandler<string>> RequestALeave(CreateLeaveDto createLeaveDto)
    {
            ResponseOkHandler<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(createLeaveDto), Encoding.UTF8, "application/json");

            using (var response = httpClient.PostAsync(request + urlLeaves + "request", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
            }

            return entityVM;
    }
}
