using MiniBusManagement.Domain.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Services.Administration
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUser(string loggedUser, DateTime currentDate);
        Task<User> GetUserByID(int userID, string loggedUser, DateTime currentDate);
        Task<int> InsertUser(User user, string loggedUser, DateTime currentDate);
        Task<int> DeleteUser(int userID, string loggedUser, DateTime currentDate);
        Task<int> UpdateUser(int userID, MiniBus user, string loggedUser, DateTime currentDate);
    }
}
