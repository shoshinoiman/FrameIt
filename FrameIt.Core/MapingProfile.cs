using AutoMapper;
using FrameIt.Core.Dto;
using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FrameIt.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()).ReverseMap();

            CreateMap<UpdateUserDto, User>().ReverseMap();

            CreateMap<Collage, CollageDto>().ReverseMap();

            CreateMap<ImageItem, ImageItemDto>().ReverseMap();
        }
    }
}
