using AutoMapper;

namespace Public.DTO.v1;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap< BLL.DTO.Competition, Public.DTO.v1.v1.Competition>().ReverseMap();

        CreateMap<BLL.DTO.Excercise, Public.DTO.v1.v1.Excercise>().ReverseMap();
        
        CreateMap<BLL.DTO.Location, Public.DTO.v1.v1.Location>().ReverseMap();
        
        CreateMap<BLL.DTO.Message, Public.DTO.v1.v1.Message>().ReverseMap();
        
        CreateMap<BLL.DTO.MonthlySubscription, Public.DTO.v1.v1.MonthlySubscription>().ReverseMap();
        
        CreateMap<BLL.DTO.SportsSchool, Public.DTO.v1.v1.SportsSchool>().ReverseMap();
        
        CreateMap<BLL.DTO.Training, Public.DTO.v1.v1.Training>().ReverseMap();
        
        CreateMap<BLL.DTO.UserAtTraining, Public.DTO.v1.v1.UserAtTraining>().ReverseMap();
        
        CreateMap<BLL.DTO.UserGroup, Public.DTO.v1.v1.UserGroup>().ReverseMap();
        
        CreateMap<BLL.DTO.UserInGroup, Public.DTO.v1.v1.UserInGroup>().ReverseMap();

        CreateMap<BLL.DTO.UserAtCompetition, Public.DTO.v1.v1.UserAtCompetition>().ReverseMap();
        
        
        
        //add others aswell
    }
}