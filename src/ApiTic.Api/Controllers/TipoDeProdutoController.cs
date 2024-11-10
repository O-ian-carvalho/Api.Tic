using ApiTic.Api.Dto;
using ApiTic.Business.Interfaces;
using ApiTic.Business.Models;
using ApiTic.Business.Services;
using ApiTic.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiTic.Api.Controllers
{
    [Route("api/[controller]")]

    public class TipoDeProdutoController : MainController
    {
        private readonly ITipoDeProdutoRepository _TipoDeProdutoRepository;
        private readonly ITipoDeProdutoService _TipoDeProdutoService;
        private readonly IMapper _mapper;


        public TipoDeProdutoController(ITipoDeProdutoService TipoDeProdutoService, ITipoDeProdutoRepository TipoDeProdutoRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _TipoDeProdutoService = TipoDeProdutoService;
            _mapper = mapper;
            _TipoDeProdutoRepository = TipoDeProdutoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoDeProdutoDto>> GetTipoDeProduto()
        {
            return _mapper.Map<IEnumerable<TipoDeProdutoDto>>(await _TipoDeProdutoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TipoDeProdutoDto>> GetTipoDeProdutoById(Guid id)
        {
            var TipoDeProduto = _mapper.Map<TipoDeProdutoDto>(await _TipoDeProdutoRepository.ObterPorId(id));
            if (TipoDeProduto == null) return NotFound();
            return TipoDeProduto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTipoDeProduto(TipoDeProdutoDto TipoDeProdutoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _TipoDeProdutoService.Adicionar(_mapper.Map<TipoDeProduto>(TipoDeProdutoDto));
            return CustomResponse(HttpStatusCode.Created, TipoDeProdutoDto);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateTipoDeProduto(Guid id, TipoDeProdutoDto TipoDeProdutoDto)
        {
            if (id != TipoDeProdutoDto.Id)
            {
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var TipoDeProdutoAtualizacao = await _TipoDeProdutoRepository.ObterPorId(id);
            TipoDeProdutoAtualizacao = _mapper.Map<TipoDeProduto>(TipoDeProdutoDto);

            await _TipoDeProdutoService.Atualizar(TipoDeProdutoAtualizacao);


            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteTipoDeProduto(Guid id)
        {

            var TipoDeProduto = await GetTipoDeProdutoById(id);
            if (TipoDeProduto != null) return NotFound();
            await _TipoDeProdutoService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
