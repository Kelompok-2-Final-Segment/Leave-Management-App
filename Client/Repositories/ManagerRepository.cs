using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.DTOs.Managers;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

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
    }
}
