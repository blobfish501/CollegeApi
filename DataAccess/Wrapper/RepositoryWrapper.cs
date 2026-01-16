using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CollegeApiContext _repoContext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(CollegeApiContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}