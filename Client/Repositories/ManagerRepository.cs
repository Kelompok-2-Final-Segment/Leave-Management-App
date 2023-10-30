using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.DTOs.Managers;
using API.Utilities.Handlers;
using Client.Contracts;
using Client.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class ManagerRepository : GeneralRepository, IManagerRepository
    {
        public ManagerRepository(string request = "Manager/") : base(request)
        {
            
        }

        public async Task<ResponseOkHandler<DashboardManagerDto>> GetDashboardDetails(Guid guid)
        {
            ResponseOkHandler<DashboardManagerDto> entityVM = null;
            using (var response = httpClient.GetAsync(request + "Dashboard/" + guid).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<DashboardManagerDto>>(apiResponse);
            }
            return entityVM;
        }
        public async Task<ResponseOkHandler<LeaveDetailManagerDto>> GetLeaveDetails(Guid guid)
        {
            ResponseOkHandler<LeaveDetailManagerDto> entityVM = null;
            using (var response = httpClient.GetAsync(request + urlLeaves + "Details/" + guid).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<LeaveDetailManagerDto>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetHistoryLeaves(Guid guid)
        {
            ResponseOkHandler<IEnumerable<LeaveDto>> entityVM = null;
            using (var response = httpClient.GetAsync(request + urlLeaves + "Histories/"+ guid).Result)
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

        public async Task<ResponseOkHandler<IEnumerable<EmployeeDto>>> GetStaffs(Guid guid)
        {
            ResponseOkHandler<IEnumerable<EmployeeDto>> entityVM = null;
            using (var response = httpClient.GetAsync(request + "Staffs/" + guid).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<EmployeeDto>>>(apiResponse);
            }
            return entityVM;
        }    
        public async Task<ResponseOkHandler<EmployeeDetailsDto>> GetStaff(Guid guid)
        {
            ResponseOkHandler<EmployeeDetailsDto> entityVM = null;
            using (var response = httpClient.GetAsync(request + "Staffs/" + guid).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<EmployeeDetailsDto>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseOkHandler<LeaveStatisticDto>> GetStatisticLeaves(Guid guid)
        {
            ResponseOkHandler<LeaveStatisticDto> entityVM = null;
            using (var response = httpClient.GetAsync(request + "Dashboard/" + guid).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<LeaveStatisticDto>>(apiResponse);
            }
            return entityVM;
        }
        public async Task<ResponseOkHandler<string>> EditLeave(EditLeaveDto editLeaveDto)
        {
            ResponseOkHandler<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(editLeaveDto), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request + urlLeaves+ "Edit/", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
            }
            return entityVM;
        }
    }
}
