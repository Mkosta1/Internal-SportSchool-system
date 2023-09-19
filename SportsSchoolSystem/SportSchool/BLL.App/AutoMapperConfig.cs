using AutoMapper;
using Domain.App;

namespace BLL.App;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        //DAL
        CreateMap<BLL.DTO.Competition, Domain.Competition>().ReverseMap();
        
        CreateMap<BLL.DTO.Excercise, Domain.Excercise>().ReverseMap();
        
        CreateMap<BLL.DTO.Location, Domain.Location>().ReverseMap();
        
        CreateMap<BLL.DTO.Message, Message>().ReverseMap();
        
        CreateMap<BLL.DTO.MonthlySubscription, Domain.MonthlySubscription>().ReverseMap();
        
        CreateMap<BLL.DTO.SportsSchool, Domain.SportsSchool>().ReverseMap();
        
        CreateMap<BLL.DTO.Training, Domain.Training>().ReverseMap();
        
        CreateMap<BLL.DTO.UserAtTraining, Domain.UserAtTraining>().ReverseMap();
        
        CreateMap<BLL.DTO.UserGroup, Domain.UserGroup>().ReverseMap();
        
        CreateMap<BLL.DTO.UserInGroup, Domain.UserInGroup>().ReverseMap();
        
        
        CreateMap<BLL.DTO.UserAtCompetition, Domain.UserAtCompetition>().ReverseMap();
        
        
        
    }
}