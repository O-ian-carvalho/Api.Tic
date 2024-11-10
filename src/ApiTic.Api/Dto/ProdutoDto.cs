using System.ComponentModel.DataAnnotations;

namespace ApiTic.Api.Dto
{
    public class ProdutoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Valor { get; set; }

        public string NomeCategoria { get; set; }
    }
}
