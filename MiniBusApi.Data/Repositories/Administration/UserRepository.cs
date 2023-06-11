using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;

namespace MiniBusManagement.Data.Repositories.Administration
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public async Task<int> DeleteUser(int userID)
        {
            return 500;
        }

        public Task<IEnumerable<User>> GetUser()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByID(int userID)
        {
            UserDBEntity? user = await _db.Users.AsNoTracking()
                .Include(c => c.Company)
                .Include(r  => r.Roles).ThenInclude(a => a.Company)
                .FirstOrDefaultAsync(m => m.Id == userID);

            if (user == null)
            {
                User userDomain = new();
                return userDomain;
            }
            else
            {
                User userDomain = _mapper.Map<User>(user);
                return userDomain;
            }
        }

        public Task<int> InsertUser(User user)
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
