using AutoMapper;
using DemoValidationDataAutomapper.Application.Models.Product;
using Domain.Entities;

namespace DemoValidationDataAutomapper.Application.Mapping
{
    /// <summary>
    /// Perfil de mapeo para la clase Product. 
    /// Define las conversiones entre los modelos de solicitud y la entidad Product.
    /// </summary>
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Cuando todas las propiedades son iguales
            CreateMap<ProductRequestModel, ProductEntity>()
            // Para ignorar una propiedad
                .ForMember(dest => dest.Id, opt => opt.Ignore())
            // Pasara de ProductEntity a ProductRequestModel
                .ReverseMap();
            CreateMap<ProductRequestModelOption, ProductEntity>()
            .ReverseMap()
            //Cuando las propiedades no son iguales            
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
