using AutoMapper;
using Reservei_API.Objects.Models.Entities;
using Reservei_API.Objects.Models.Entities;
using ReserveiAPI.Objects.DTO_s.Entities;

namespace Reservei_API.Objects.DTOs.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<UserDTO, UserModel>().ReverseMap();
        }

    }
}