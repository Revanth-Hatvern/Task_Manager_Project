using Microsoft.AspNetCore.Mvc;
using Task_Manager_API.Data;
using Task_Manager_API.Models.Domain;
using Task_Manager_API.Models.DTO;

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
            var taskManagerdomain = _dbContext.Tasks.ToList();

            var taskManagerDto = new List<TaskManagerDto>();

            foreach(var taskManager in taskManagerdomain)
            {
                taskManagerDto.Add(new TaskManagerDto()
                {
                    Id= taskManager.Id,
                    TaskName=taskManager.TaskName,
                    TaskDescription=taskManager.TaskDescription,
                    TargetTimeinHours=taskManager.TargetTimeinHours
                });
            }


            return Ok(taskManagerDto);
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

            var taskManagerDto = new TaskManagerDto()
            { 
                Id = taskManager.Id,
                TaskName=taskManager.TaskName,
                TaskDescription=taskManager.TaskDescription,
                TargetTimeinHours = taskManager.TargetTimeinHours
                 
            };

            
            return Ok(taskManagerDto);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody]TaskManagerRequestDto taskManagerRequestDto)
        {
            var taskManager = new TaskManager()
            {     
                TaskName= taskManagerRequestDto.TaskName,
                TaskDescription= taskManagerRequestDto.TaskDescription,
                TargetTimeinHours= taskManagerRequestDto.TargetTimeinHours
            };

     
           _dbContext.Tasks.Add(taskManager);

            _dbContext.SaveChanges();

            return Ok("Task Created Sucessfully");

        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult EditTask([FromRoute]int id,[FromBody] TaskManagerRequestDto taskManagerRequestDto) 
        {
            var taskmanager=_dbContext.Tasks.FirstOrDefault(x=>x.Id==id);

            if( taskmanager == null)
            {
                return NotFound();
            }

            taskmanager.TaskName = taskManagerRequestDto.TaskName;
            taskmanager.TaskDescription= taskManagerRequestDto.TaskDescription;
            taskmanager.TargetTimeinHours = taskManagerRequestDto.TargetTimeinHours;

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
