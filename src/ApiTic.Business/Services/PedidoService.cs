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
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task Adicionar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidation(), pedido)) return;

            if(_pedidoRepository.Buscar(x => x.ClienteId == pedido.ClienteId && x.Status == Models.Enums.EStatusPedido.EmAndamento).Result.Any())
            {
                Notificar("Esse usuario tem um pedido em andamento");
                return;
            }
            await _pedidoRepository.Adicionar(pedido);
        }

     
     
        public async Task FinalizarPedido(Pedido pedido)
        {
            pedido.Status = Models.Enums.EStatusPedido.Concluido;
            await _pedidoRepository.Atualizar(pedido);
        }

        public async Task Remover(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id);

            if(pedido == null)
            {
                Notificar("O pedido não existe");
                return;
            }

            if(pedido.Produtos.Any())
            {
                Notificar("Esse pedido contem produtos");
                return;
            }
            await _pedidoRepository.Remover(id);
        }

       
    }
}
