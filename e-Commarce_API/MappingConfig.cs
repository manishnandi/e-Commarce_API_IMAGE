using AutoMapper;
using e_Commarce_API.Models;
using e_Commarce_API.Models.Dto;

namespace e_Commarce_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
