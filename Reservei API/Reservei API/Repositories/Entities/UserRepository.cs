using Reservei_API.Contexts;
using Reservei_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Reservei_API.Objects.Models.Entities;
namespace Reservei_API.Repositories.Entities
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbCOntext;

        public UserRepository(AppDBContext dbContext)
        {
            _dbCOntext = dbContext;
        }
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _dbCOntext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbCOntext.Users.AsNoTracring().FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<UserModel>Create(UserModel userModel)
        {
            _dbContext.Users.Add(userModel);
            await _dbContext.SaveChangesAsync();

            return userModel;
        }
        public async Task<UserModel> Update(UserModel userModel)
        {
            _dbContext.Entry(userMdoel).State = EntityState.Modified;
            await _dbCOntext.SaveChangesAsync();

            return userModel;
        }

        public async Task<UserModel> Delete(UserModel userModel)
        {
            _dbContext.Users.Remove(userModel);
            await _dbContext.SaveChangesAsync();

            return userModel;
        }
    }
}
