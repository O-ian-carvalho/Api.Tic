using ApiTic.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiTic.Api.Dto
{
    public class TipoDeProdutoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Titulo { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
