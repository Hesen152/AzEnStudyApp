using AutoMapper;

namespace AzEnStudyApp.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Quiz, Dto.QuizViewDto>().ReverseMap();
            
        }
        
    }
}