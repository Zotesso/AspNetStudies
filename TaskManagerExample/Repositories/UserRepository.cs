using Microsoft.EntityFrameworkCore;
using TaskManagerExample.Data;
using TaskManagerExample.Models;
using TaskManagerExample.Repositories.Interfaces;

namespace TaskManagerExample.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerDBContext _dbContext;
        public UserRepository(TaskManagerDBContext taskManagerDBContext)
        {
            _dbContext = taskManagerDBContext;   
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel expectedUser = await GetById(id);

            if (expectedUser == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }

            expectedUser.Name = user.Name;
            expectedUser.Email = user.Email;

            _dbContext.Users.Update(expectedUser);
            await _dbContext.SaveChangesAsync();

            return expectedUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel expectedUser = await GetById(id);

            if (expectedUser == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }

            _dbContext.Users.Remove(expectedUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
