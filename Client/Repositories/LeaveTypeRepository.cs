using API.DTOs.LeaveTypes;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;
using System.Text;

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

    public async Task<ResponseOkHandler<string>> Create(CreateLeaveTypeDto entity)
    {
        ResponseOkHandler<string> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

        using (var response = httpClient.PostAsync("Admin/LeaveTypes", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<string>> Delete(Guid guid)
    {
        ResponseOkHandler<string> entityVM = null;

        using (var response = httpClient.DeleteAsync("Admin/LeaveTypes/" + guid).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseOkHandler<IEnumerable<LeaveTypeDto>>> GetAll()
    {
        ResponseOkHandler<IEnumerable<LeaveTypeDto>> entityVM = null;


        using (var response = await httpClient.GetAsync("Admin/LeaveTypes/"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<LeaveTypeDto>>>(apiResponse);
        }

        return entityVM;
    }
}
