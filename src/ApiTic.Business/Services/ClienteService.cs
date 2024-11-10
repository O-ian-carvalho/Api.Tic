using ApiTic.Business.Interfaces;
using ApiTic.Business.Models;
using ApiTic.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(f => f.Email == cliente.Email).Result.Any())
            {
                Notificar("Já existe um cliente com esse email!");
                return;
            }

            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(p => p.Email == cliente.Email && p.Id != cliente.Id).Result.Any())
            {
                Notificar("Já existe um cliente com este email");
                return;
            }
            await _clienteRepository.Atualizar(cliente);
        }

        public  void Dispose()
        {
             _clienteRepository.Dispose();
        }

        public async Task Remover(Guid id)
        {
            var cliente = await _clienteRepository.ObterClientePedidos(id);
            if(cliente == null)
            {
                Notificar("O cliente que você tentou remover não existe");
                return;
            }

            if(cliente.Pedidos.Any())
            {
                Notificar("Você não pode excluir clientes com pedidos");
                return;
            }
            await _clienteRepository.Remover(id);
        }
    }
}
