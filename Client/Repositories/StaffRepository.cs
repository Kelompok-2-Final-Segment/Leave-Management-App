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
    public async Task<ResponseOkHandler<IEnumerable< LeaveDto>>> GetHistoryLeaves(Guid guid)
    {
        ResponseOkHandler<IEnumerable< LeaveDto>> entityVM = null;
        using (var response = httpClient.GetAsync(request + urlLeaves + "Histories/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveDto>>>(apiResponse);
        }
        return entityVM;
    }
    public async Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetPendingLeaves(Guid guid)
    {
        ResponseOkHandler<IEnumerable<LeaveDto>> entityVM = null;
        using (var response = httpClient.GetAsync(request + urlLeaves + "Pending/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveDto>>>(apiResponse);
        }
        return entityVM;
    }


    public async Task<ResponseOkHandler<LeaveDetailAdminDto>> GetLeaveDetail(Guid guid)
    {
        ResponseOkHandler<LeaveDetailAdminDto> entityVM = null;


        using (var response = await httpClient.GetAsync(request + urlLeaves + "Details/ " + guid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<LeaveDetailAdminDto>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<LeaveStatisticStaffDto>> GetStatisticLeaves(Guid guid)
    {
        ResponseOkHandler<LeaveStatisticStaffDto> entityVM = null;
        using (var response = httpClient.GetAsync(request + urlLeaves + "Statistics/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<LeaveStatisticStaffDto>>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseOkHandler<EmployeeDetailsDto>> Profile(Guid guid)
    {
        ResponseOkHandler<EmployeeDetailsDto> entityVM = null;
        using (var response = httpClient.GetAsync(request  + "Profile/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<EmployeeDetailsDto>>(apiResponse);
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

    public async Task<ResponseOkHandler<string>> CancelRequestLeave(Guid guid)
    {
        ResponseOkHandler<string> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(guid), Encoding.UTF8, "application/json");

        using (var response = httpClient.PutAsync(request + urlLeaves , content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
        }

        return entityVM;
    }
}
