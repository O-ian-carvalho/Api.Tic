using ApiTic.Api.Dto;
using ApiTic.Business.Interfaces;
using ApiTic.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiTic.Api.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IClienteService _ClienteService;
        private readonly IMapper _mapper;


        public ClientesController(IClienteService ClienteService, IClienteRepository ClienteRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _ClienteService = ClienteService;
            _mapper = mapper;
            _ClienteRepository = ClienteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteDto>> GetClientes()
        {
            return _mapper.Map<IEnumerable<ClienteDto>>(await _ClienteRepository.ObterTodos());
        }

        // GET: api/Clientes/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteDto>> GetClienteById(Guid id)
        {
            var Cliente = _mapper.Map<ClienteDto>(await _ClienteRepository.ObterPorId(id));
            if (Cliente == null) return NotFound();
            return Cliente;
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClienteDto ClienteDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _ClienteService.Adicionar(_mapper.Map<Cliente>(ClienteDto));
            return CustomResponse(HttpStatusCode.Created,ClienteDto);
        }

        // PUT: api/Clientes/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateCliente(Guid id, ClienteDto ClienteDto)
        {
            if (id != ClienteDto.Id)
            {
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var ClienteAtualizacao = await _ClienteRepository.ObterPorId(id);
            ClienteAtualizacao = _mapper.Map<Cliente>(ClienteDto);

            await _ClienteService.Atualizar(ClienteAtualizacao);


            return CustomResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/Clientes/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCliente(Guid id)
        {
            var Cliente = await GetClienteById(id);
            if (Cliente != null) return NotFound();
            await _ClienteService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
