using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;

public class GeneralRepository 
{
    protected readonly string request;
    protected HttpClient httpClient;

    public GeneralRepository(string request)
    {
        this.request = request;
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7064/api/")
        };
    }

}
