using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GeneralController<TDto, TCdto, TRepository> 
    {
        private readonly TRepository _repository;
        public GeneralController(TRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<TDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TDto? GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public TDto? Create(TCdto dto)
        {
            throw new NotImplementedException();
        }

        public bool Update(TDto dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TDto dto)
        {
            throw new NotImplementedException();
        }

    }
}
