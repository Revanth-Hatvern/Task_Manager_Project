using Microsoft.EntityFrameworkCore;
using Task_Manager_API.Models.Domain;

namespace Task_Manager_API.Data
{
    public class TaskManagerDBContext : DbContext
    {
        public TaskManagerDBContext(DbContextOptions<TaskManagerDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    
            public DbSet<TaskManager> Tasks { get; set; }
    }
}
