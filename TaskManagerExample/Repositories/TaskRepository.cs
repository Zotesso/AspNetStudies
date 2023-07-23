using Microsoft.EntityFrameworkCore;
using TaskManagerExample.Data;
using TaskManagerExample.Models;
using TaskManagerExample.Repositories.Interfaces;

namespace TaskManagerExample.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerDBContext _dbContext;
        public TaskRepository(TaskManagerDBContext taskManagerDBContext)
        {
            _dbContext = taskManagerDBContext;   
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> GetById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }
        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel expectedTask = await GetById(id);

            if (expectedTask == null)
            {
                throw new Exception($"Task para o ID: {id} não foi encontrado");
            }

            expectedTask.Name = task.Name;
            expectedTask.Description = task.Description;
            expectedTask.Status = task.Status;
            expectedTask.UserId = task.UserId;

            _dbContext.Tasks.Update(expectedTask);
            await _dbContext.SaveChangesAsync();

            return expectedTask;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel expectedTask = await GetById(id);

            if (expectedTask == null)
            {
                throw new Exception($"Task para o ID: {id} não foi encontrado");
            }

            _dbContext.Tasks.Remove(expectedTask);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
