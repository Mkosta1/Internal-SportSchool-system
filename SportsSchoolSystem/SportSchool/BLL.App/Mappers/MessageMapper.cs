using AutoMapper;
using DAL.Base;
using Domain.App;

namespace BLL.App.Mappers;

public class MessageMapper : BaseMapper<BLL.DTO.Message, Message>
{
    public MessageMapper(IMapper mapper) : base(mapper)
    {
    
    }
}