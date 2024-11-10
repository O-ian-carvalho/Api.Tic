using ApiTic.Api.Dto;
using ApiTic.Business.Interfaces;
using ApiTic.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiTic.Api.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;


        public ProdutosController(IProdutoService produtoService, IProdutoRepository produtoRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _produtoService = produtoService;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDto>> GetProdutos()
        {
            return  _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepository.ObterProdutosTipo());
        }

        // GET: api/produtos/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDto>> GetProdutoById(Guid id)
        {
            var produto = _mapper.Map<ProdutoDto>(await _produtoRepository.ObterPorId(id));
            if (produto == null) return NotFound();
            return produto;
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult> CreateProduto(ProdutoDto produtoDto)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoDto));
            return CustomResponse(HttpStatusCode.Created,produtoDto);
        }

        // PUT: api/produtos/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateProduto(Guid id, ProdutoDto produtoDto)
        {
           if(id != produtoDto.Id)
            {
                return CustomResponse(HttpStatusCode.Ambiguous);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produtoAtualizacao = await _produtoRepository.ObterPorId(id);
            produtoAtualizacao = _mapper.Map<Produto>(produtoAtualizacao);

            await _produtoService.Atualizar(produtoAtualizacao);
            

            return CustomResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/produtos/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteProduto(Guid id)
        {
            var produto = await GetProdutoById(id);
            if (produto != null) return NotFound();
            await _produtoService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }

       
    }
}
