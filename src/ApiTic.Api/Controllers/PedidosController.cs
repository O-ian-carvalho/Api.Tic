using ApiTic.Api.Dto;
using ApiTic.Business.Interfaces;
using ApiTic.Business.Models;
using ApiTic.Business.Models.Enums;
using ApiTic.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiTic.Api.Controllers
{
    [Route("api/Pedidos")]
    [ApiController]
    public class PedidosController : MainController
    {
        private readonly IPedidoRepository _PedidoRepository;
        private readonly IProdutoRepository _ProdutoRepository;

        private readonly IPedidoService _PedidoService;
        private readonly IMapper _mapper;


        public PedidosController(IPedidoService PedidoService, IProdutoRepository ProdutoRepository, IPedidoRepository PedidoRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _PedidoService = PedidoService;
            _mapper = mapper;
            _PedidoRepository = PedidoRepository;
            _ProdutoRepository = ProdutoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoDto>> GetPedidos()
        {
            return _mapper.Map<IEnumerable<PedidoDto>>(await _PedidoRepository.ObterTodos());
        }

        // GET: api/Pedidos/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoDto>> GetPedidoById(Guid id)
        {
            var Pedido = _mapper.Map<PedidoDto>(await _PedidoRepository.ObterPorId(id));
            if (Pedido == null) return NotFound();
            return Pedido;
        }

        // POST: api/Pedidos
        [HttpPost]
        public async Task<ActionResult> CreatePedido(PedidoDto PedidoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _PedidoService.Adicionar(_mapper.Map<Pedido>(PedidoDto));
            return CustomResponse(HttpStatusCode.Created,PedidoDto);
        }
        

        // DELETE: api/Pedidos/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeletePedido(Guid id)
        {
            var Pedido = await GetPedidoById(id);
            if (Pedido != null) return NotFound();
            await _PedidoService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpPut("{pedidoId:Guid}/produto/{produtoId:Guid}")]
        public async Task<ActionResult> AddProdutoPedido(Guid pedidoId, Guid produtoId, PedidoDto pedido)
        {
            if (pedidoId != pedido.Id)
            {
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = await _ProdutoRepository.ObterPorId(produtoId);
            pedido.Produtos.Add(_mapper.Map<ProdutoDto>(produto));

            await _PedidoRepository.Atualizar(_mapper.Map<Pedido>(pedido));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpGet("{pedidoId:guid}/produtos")]
        public async Task<IEnumerable<ProdutoDto>> ObterProdutosDoPEdido(Guid pedidoId)
        {
         
            var produtos = await _ProdutoRepository.Buscar(x => x.PedidoId == pedidoId);
            return _mapper.Map<IEnumerable<ProdutoDto>>(produtos);

        }

        [HttpDelete("{pedidoId:Guid}/produto/{produtoId:Guid}")]
        public async Task<ActionResult> RemoveProdutoPedido(Guid pedidoId, Guid produtoId, PedidoDto pedido)
        {
            if (pedidoId != pedido.Id)
            {
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = await _ProdutoRepository.ObterPorId(produtoId);
            pedido.Produtos.Remove(_mapper.Map<ProdutoDto>(produto));

            await _PedidoRepository.Atualizar(_mapper.Map<Pedido>(pedido));

            return CustomResponse(HttpStatusCode.NoContent);
        }

    }
}
