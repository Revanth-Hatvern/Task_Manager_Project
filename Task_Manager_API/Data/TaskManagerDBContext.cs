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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Task Manager

            var taskManager = new List<TaskManager>()
            {
                new TaskManager()
                {
                    Id=1,
                    TaskName="Study",
                    TaskDescription="Studying for new Job",
                    TargetTimeinHours=3
                },
                new TaskManager()
                {
                    Id=2,
                    TaskName="Running",
                    TaskDescription="",
                    TargetTimeinHours=0.5
                },
                new TaskManager()
                {
                    Id=3,
                    TaskName="Workout",
                    TaskDescription="",
                    TargetTimeinHours=1
                },
                new TaskManager()
                {
                    Id=4,
                    TaskName="Cooking",
                    TaskDescription="Learning Cooking for Birthday",
                    TargetTimeinHours=2
                },
                new TaskManager()
                {
                    Id=5,
                    TaskName="Yoga",
                    TaskDescription="",
                    TargetTimeinHours=0.5
                },
                new TaskManager()
                {
                    Id=6,
                    TaskName="project Completion",
                    TaskDescription="",
                    TargetTimeinHours=2
                }
            };

            //Seed Data to the database
            modelBuilder.Entity<TaskManager>().HasData(taskManager);
        }

    }
}
