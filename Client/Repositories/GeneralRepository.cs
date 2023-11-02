using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;

namespace Client.Repositories;

public class GeneralRepository
{
    protected readonly string request;
    protected HttpClient httpClient;
    protected readonly string urlEmployees = "Employees/";
    protected readonly string urlLeaves = "Leaves/";

    public GeneralRepository(string request)
    {
        this.request = request;
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7064/api/"),

        };


    }

}
