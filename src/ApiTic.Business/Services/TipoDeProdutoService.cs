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
    public class TipoDeProdutoService : BaseService, ITipoDeProdutoService
    {
        private readonly ITipoDeProdutoRepository _tipoDeProdutoRepository;
        public TipoDeProdutoService(INotificador notificador, ITipoDeProdutoRepository tipoDeProdutoRepository) : base(notificador)
        {
            _tipoDeProdutoRepository = tipoDeProdutoRepository;
        }

        public async Task Adicionar(TipoDeProduto tipoDeProduto)
        {
            if (!ExecutarValidacao(new TipoDeProdutoValidation(), tipoDeProduto)) return;

            if (_tipoDeProdutoRepository.Buscar(f => f.Titulo == tipoDeProduto.Titulo).Result.Any())
            {
                Notificar("Já existe uma categoria com esse nome!");
                return;
            }

            await _tipoDeProdutoRepository.Adicionar(tipoDeProduto);
        }

        public async Task Atualizar(TipoDeProduto tipoDeProduto)
        {
            if (!ExecutarValidacao(new TipoDeProdutoValidation(), tipoDeProduto)) return;

            if (_tipoDeProdutoRepository.Buscar(p => p.Titulo == tipoDeProduto.Titulo && p.Id != tipoDeProduto.Id).Result.Any())
            {
                Notificar("Já existe um cliente com este email");
                return;
            }
            await _tipoDeProdutoRepository.Atualizar(tipoDeProduto);
        }

        public async Task Remover(Guid id)
        {
            var tipo = await _tipoDeProdutoRepository.ObterTipoDeProdutoProdutos(id);
            if (tipo == null)
            {
                Notificar("O cliente que você tentou remover não existe");
                return;
            }

            if (tipo.Produtos.Any())
            {
                Notificar("Você não pode excluir clientes com pedidos");
                return;
            }
            await _tipoDeProdutoRepository.Remover(id);
        }
    }
}
