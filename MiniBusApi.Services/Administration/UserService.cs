using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Data.Administration;

namespace MiniBusManagement.Services.Administration
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> DeleteUser(int userID, string loggedUser, DateTime currentDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUser(string loggedUser, DateTime currentDate)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByID(int userID, string loggedUser, DateTime currentDate)
        {
            User user = await _userRepository.GetUserByID(userID);
            return user;
        }

        public Task<int> InsertUser(User user, string loggedUser, DateTime currentDate)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUser(int userID, MiniBus user, string loggedUser, DateTime currentDate)
        {
            throw new NotImplementedException();
        }
    }
}
