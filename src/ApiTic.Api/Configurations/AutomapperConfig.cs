using ApiTic.Api.Dto;
using ApiTic.Business.Models;
using AutoMapper;

namespace ApiTic.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<TipoDeProduto, TipoDeProdutoDto>().ReverseMap();

            CreateMap<ProdutoDto, Produto>();
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Titulo));

            CreateMap<PedidoDto, Pedido>();
            CreateMap<Pedido, PedidoDto>()
                 .ForMember(dest => dest.NomeDoCliente, opt => opt.MapFrom(src => src.Cliente.Nome));
        }
    }
}
