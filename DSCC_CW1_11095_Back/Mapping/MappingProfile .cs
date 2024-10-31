using AutoMapper;
using DSCC_CW1_11095_Back.Dtos;
using DSCC_CW1_11095_Back.Models;

namespace DSCC_CW1_11095_Back.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producer, ProducerDto>();
            CreateMap<ProducerCreateDto, Producer>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
