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
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }
      

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (_produtoRepository.Buscar(x => x.Nome == produto.Nome).Result.Any())
            {
                Notificar("Já existe um produto com esse nome");
                return;
            }
            await _produtoRepository.Adicionar(produto);
        }

        public async Task AdicionarProdutoPedido(Produto produto, Guid pedidoId)
        {
            produto.PedidoId = pedidoId;
            await _produtoRepository.Atualizar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (_produtoRepository.Buscar(x => x.Nome == produto.Nome && x.Id != produto.Id).Result.Any())
            {
                Notificar("Já existe um produto com esse nome");
                return;
            }

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                Notificar("O produto não existe");
                return;
            }

           
            await _produtoRepository.Remover(id);
        }

        public async Task RemoverProdutoPedido(Produto produto, Guid pedidoId)
        {
            produto.PedidoId = null;
            await _produtoRepository.Atualizar(produto);
        }
    }
}
