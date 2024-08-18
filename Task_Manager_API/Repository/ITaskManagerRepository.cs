using Microsoft.EntityFrameworkCore;
using Task_Manager_API.Models.Domain;

namespace Task_Manager_API.Repository
{
    public interface ITaskManagerRepository
    {
        Task<List<TaskManager>> GetAllAsync();

        Task<TaskManager?> GetAsyncById(int id);

        Task<TaskManager>?  UpdateAsync(int id,TaskManager taskManager);

        Task<TaskManager>? DeleteAsync(int id);

        Task CreateAsync(TaskManager taskManager);

    

    }
}
