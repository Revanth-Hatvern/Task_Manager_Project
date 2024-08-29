using AutoMapper;
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
        private readonly IMapper _mapper;

        public TaskManagerController(ITaskManagerRepository taskManagerRepository,IMapper mapper)
        {
            _taskManagerRepository = taskManagerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllLists()
        {
            var taskManagerdomain = await _taskManagerRepository.GetAllAsync();
         //   var taskManagerDto = new List<TaskManagerDto>();

            //Map Domain to Dto

          var taskManagerDto=_mapper.Map<List<TaskManagerDto>>(taskManagerdomain);      

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

            //Convert Domain Model to Dto
            //Mapping Domain to Dto

            var taskManagerDto = _mapper.Map<TaskManagerDto>(taskManager);
                     
            return Ok(taskManagerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody]TaskManagerRequestDto taskManagerRequestDto)
        {

            //Map Dto to Domain
            var taskManager = _mapper.Map<TaskManager>(taskManagerRequestDto);
           
             await _taskManagerRepository.CreateAsync(taskManager);

            return Ok("Task Created Sucessfully");

        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> EditTask([FromRoute]int id,[FromBody] TaskManagerRequestDto taskManagerRequestDto) 
        {
            //Map Dto to Domain
            var taskManager = _mapper.Map<TaskManager>(taskManagerRequestDto);
           
            taskManager = await _taskManagerRepository.UpdateAsync(id, taskManager);

            if(taskManager == null)
             return NotFound();

            //   return Ok("Task Edited Sucessfully");

            return Ok(new { Message = "Task Edited Successfully", TaskManager = taskManager });

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
