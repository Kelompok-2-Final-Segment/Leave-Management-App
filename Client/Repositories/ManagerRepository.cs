using Client.Contracts;

namespace Client.Repositories
{
    public class ManagerRepository : GeneralRepository, IManagerRepository
    {
        public ManagerRepository(string request) : base(request)
        {
        }
    }
}
