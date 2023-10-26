using API.Utilities.Handlers;

namespace Client.Contracts;

public interface IRepository<TEntity, XEntity> where TEntity: class
{
    Task<ResponseOkHandler<IEnumerable<TEntity>>> Get();
    Task<ResponseOkHandler<TEntity>> Get(XEntity id);
    Task<ResponseOkHandler<TEntity>> Post<TPost>(TPost entity);
    Task<ResponseOkHandler<TEntity>> Put(XEntity id, TEntity entity);
    Task<ResponseOkHandler<TEntity>> Delete(XEntity id);
}
