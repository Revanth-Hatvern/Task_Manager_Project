using Microsoft.AspNetCore.Mvc;
using Task_Manager_API.Data;
using Task_Manager_API.Models.Domain;
using Task_Manager_API.Models.DTO;
using Task_Manager_API.Repository;

namespace Task_Manager_API.Controllers
{
    //https://Localhost:portNumber/api/TaskManager
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : Controller
    {

        private readonly ITaskManagerRepository _taskManagerRepository;

        public TaskManagerController(ITaskManagerRepository taskManagerRepository)
        {
            _taskManagerRepository = taskManagerRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllLists()
        {
            var taskManagerdomain = await _taskManagerRepository.GetAllAsync();
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
        public async Task<IActionResult> GetList([FromRoute] int id) 
        {
            var taskManager=await _taskManagerRepository.GetAsyncById(id);
           
            if(taskManager==null)
            {
                return NotFound("No Task Found");
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
        public async Task<IActionResult> CreateTask([FromBody]TaskManagerRequestDto taskManagerRequestDto)
        {

            

            var taskManager = new TaskManager()
            {     
                TaskName= taskManagerRequestDto.TaskName,
                TaskDescription= taskManagerRequestDto.TaskDescription,
                TargetTimeinHours= taskManagerRequestDto.TargetTimeinHours
            };

             await _taskManagerRepository.CreateAsync(taskManager);

            return Ok("Task Created Sucessfully");

        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> EditTask([FromRoute]int id,[FromBody] TaskManagerRequestDto taskManagerRequestDto) 
        {
            var taskmanager = new TaskManager();
        
            taskmanager.TaskName = taskManagerRequestDto.TaskName;
            taskmanager.TaskDescription= taskManagerRequestDto.TaskDescription;
            taskmanager.TargetTimeinHours = taskManagerRequestDto.TargetTimeinHours;

             taskmanager = await _taskManagerRepository.UpdateAsync(id, taskmanager);

            if(taskmanager==null)
             return NotFound();

            return Ok("Task Edited Sucessfully");

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute]int id)
        {
            var deleleTask=await _taskManagerRepository.DeleteAsync(id);

            if(deleleTask==null)
                return NotFound();
            
            return Ok("Task Deleted Sucessfully");

        }
    }
}
