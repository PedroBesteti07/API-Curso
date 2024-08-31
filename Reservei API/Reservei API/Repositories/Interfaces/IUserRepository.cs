using Reservei_API.Objects.Contracts;
using Reservei_API.Objects.Models.Entities;

namespace Reservei_API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAll();

        Task<UserModel> GetById(int id);

        Task<UserModel> GetByEmail(string email);

        Task<UserModel> Login(Login login);

        Task<UserModel> Create(UserModel userModel);

        Task<UserModel> Update(UserModel userModel);

        Task<UserModel> Delete(UserModel userModel);
        
    }
}
