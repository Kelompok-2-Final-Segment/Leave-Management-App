using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;

public class GeneralRepository<TEntity, XId> : IRepository<TEntity, XId> where TEntity : class
{
    private readonly string request;
    protected HttpClient httpClient;

    public GeneralRepository(string request)
    {
        this.request = request;
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7007/api/")
        };
    }

    public Task<ResponseOkHandler<TEntity>> Delete(XId id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseOkHandler<IEnumerable<TEntity>>> Get()
    {
        ResponseOkHandler<IEnumerable<TEntity>> entityVM = null;

        using (var response = await httpClient.GetAsync(request))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<IEnumerable<TEntity>>>(apiResponse);
        }

        return entityVM;
    }

    public Task<ResponseOkHandler<TEntity>> Get(XId id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseOkHandler<TEntity>> Post<TPost>(TPost entity)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseOkHandler<TEntity>> Put(XId id, TEntity entity)
    {
        throw new NotImplementedException();
    }
}
