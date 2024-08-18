using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Task_Manager_API.Data;
using Task_Manager_API.Models.Domain;

namespace Task_Manager_API.Repository
{
    public class SQLTaskManagerRepository : ITaskManagerRepository
    {
        private readonly TaskManagerDBContext _dbContext;
        public SQLTaskManagerRepository(TaskManagerDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<TaskManager>> GetAllAsync()
        {
           return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskManager?> GetAsyncById(int id)
        {
            var existingTask= await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTask==null)
            {
                return null;
            }
            return existingTask;
        }

        public async Task CreateAsync(TaskManager taskManager)
        {
           await _dbContext.AddAsync(taskManager);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TaskManager>? DeleteAsync(int id)
        {
            var existingTask= await _dbContext.Tasks.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingTask == null)
            {
                return null;                               ///throw new Exception($"Task with ID {id} not found."); //exception
            }
            _dbContext.Tasks.Remove(existingTask);
            await _dbContext.SaveChangesAsync();
            return existingTask;
        }

      

        public async Task<TaskManager>? UpdateAsync(int id, TaskManager taskManager)
        {
            var existingTask=await _dbContext.Tasks.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingTask==null)
            {
                return null;                  // throw new Exception($"Task with ID {id} not found."); //exception
            }

            existingTask.TaskName = taskManager.TaskName;
            existingTask.TaskDescription= taskManager.TaskDescription;
            existingTask.TargetTimeinHours = taskManager.TargetTimeinHours;

            await _dbContext.SaveChangesAsync();
            return existingTask;

        }
    }
}
