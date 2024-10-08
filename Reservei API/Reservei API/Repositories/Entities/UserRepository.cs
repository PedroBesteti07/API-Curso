﻿using Microsoft.EntityFrameworkCore;
using Reservei_API.Contexts;
using Reservei_API.Objects.Contracts;
using Reservei_API.Objects.Models.Entities;
using Reservei_API.Repositories.Interfaces;
namespace Reservei_API.Repositories.Entities
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<UserModel> GetByEmail(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.EmailUser == email);
        }
        public async Task<UserModel> Login(Login login)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.EmailUser == login.Email && u.PasswordUser == login.Password);
        }
        public async Task<UserModel>Create(UserModel userModel)
        {
            _dbContext.Users.Add(userModel);
            await _dbContext.SaveChangesAsync();

            return userModel;
        }
        public async Task<UserModel> Update(UserModel userModel)
        {
            _dbContext.Entry(userModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

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
