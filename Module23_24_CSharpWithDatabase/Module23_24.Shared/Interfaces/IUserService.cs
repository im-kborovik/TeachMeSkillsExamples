using System.Collections.Generic;
using System.Threading.Tasks;
using Module23_24.Shared.Models;

namespace Module23_24.Shared.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<UserModel>> GetUsers();

        Task<UserModel> CreateUser(UserModel model);

        Task<UserModel> UpdateUser(UserModel model);

        Task DeleteUser(int userId);
    }
}