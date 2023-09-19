using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class MessageMapper : BaseMapper<BLL.DTO.Message, Public.DTO.v1.v1.Message>
{
    public MessageMapper(IMapper mapper) : base(mapper)
    {


    }
}