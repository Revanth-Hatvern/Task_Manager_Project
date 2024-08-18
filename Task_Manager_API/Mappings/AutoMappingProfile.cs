using AutoMapper;
using Task_Manager_API.Models.Domain;
using Task_Manager_API.Models.DTO;

namespace Task_Manager_API.Mappings
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<TaskManager, TaskManagerDto>().ReverseMap();

            CreateMap<TaskManager,TaskManagerRequestDto>().ReverseMap();
        }
       


    }
}
