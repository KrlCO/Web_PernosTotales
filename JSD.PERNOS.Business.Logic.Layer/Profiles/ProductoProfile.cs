using AutoMapper;
using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.DTO;


namespace JSD.PERNOS.Business.Logic.Layer.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {

            CreateMap<Producto, ProductoDTO>()
            .ForMember(dest => dest.CategoriaNombre, opt => opt.MapFrom(src => src.CategoriaNombre))
            .ForMember(dest => dest.UnidadMedidaNombre, opt => opt.MapFrom(src => src.UnidadMedidaNombre))
            .ReverseMap();
        }

    }
}
