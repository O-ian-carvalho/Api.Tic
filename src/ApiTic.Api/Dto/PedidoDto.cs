using ApiTic.Business.Models.Enums;
using ApiTic.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiTic.Api.Dto
{
    public class PedidoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClienteId { get; set; }
        public string? NomeDoCliente { get; set; }
        public EStatusPedido Status { get; set; }
        public List<ProdutoDto>? Produtos { get; set; }
    }
}
