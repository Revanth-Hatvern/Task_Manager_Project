using Microsoft.AspNetCore.Mvc;
using Task_Manager_API.Data;
using Task_Manager_API.Models.Domain;

namespace Task_Manager_API.Controllers
{
    //https://Localhost:portNumber/api/TaskManager
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : Controller
    {
        private readonly TaskManagerDBContext _dbContext;

        public TaskManagerController(TaskManagerDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllLists()
        {
            var taskManager = _dbContext.Tasks.ToList();
            return Ok(taskManager);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetList([FromRoute] int id) 
        {
            var taskManager=_dbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if(taskManager == null)
            {
                return NotFound();
            }
            return Ok(taskManager);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody]TaskManager task)
        {
            var taskmanager = new TaskManager();

            taskmanager.TaskName=task.TaskName;
            taskmanager.TaskDescription=task.TaskDescription;
            taskmanager.TargetTimeinHours=task.TargetTimeinHours;

           _dbContext.Tasks.Add(taskmanager);

            _dbContext.SaveChanges();

            return Ok("Task Created Sucessfully");

        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult EditTask([FromRoute]int id,[FromBody]TaskManager task) 
        {
            var taskmanager=_dbContext.Tasks.FirstOrDefault(x=>x.Id==id);

            if( taskmanager == null)
            {
                return NotFound();
            }
            
            taskmanager.TaskName = task.TaskName;
            taskmanager.TaskDescription = task.TaskDescription;
            taskmanager.TargetTimeinHours = task.TargetTimeinHours;

            _dbContext.SaveChanges();

            return Ok("Task Edited Sucessfully");

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTask([FromRoute]int id)
        {
            var taskManager= _dbContext.Tasks.FirstOrDefault( x=>x.Id==id);
            if (taskManager == null)
                return NotFound();

            _dbContext.Remove(taskManager);
            _dbContext.SaveChanges();

            return Ok("Task Deleted Sucessfully");

        }
    }
}
