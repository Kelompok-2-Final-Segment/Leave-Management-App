using API.DTOs.LeaveTypes;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;

public class LeaveTypeRepository : ILeaveTypeRepository
{
    private HttpClient httpClient;

    public LeaveTypeRepository()
    {
        this.httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7064/api/")
        };
    }

    public async Task<ResponseOkHandler<IEnumerable<LeaveTypeDto>>> GetAllLeaveType()
    {
        ResponseOkHandler<IEnumerable<LeaveTypeDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("LeaveTypes/"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveTypeDto>>>(apiResponse);
        }

        return entityVM;
    }
}
