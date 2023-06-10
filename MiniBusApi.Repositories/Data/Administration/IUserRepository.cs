using MiniBusManagement.Domain.Models.Administration;


namespace MiniBusManagement.Repositories.Data.Administration
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> GetUserByID(int userID);
        Task<int> InsertUser(User user);
        Task<int> DeleteUser(int userID);
        Task<int> UpdateUser(User user);
        void Save();
    }
}
