using System.ComponentModel.DataAnnotations;

namespace ApiTic.Api.Dto
{
    public class ClienteDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Email { get; set; }
        public string? NumeroContato { get; set; }
        public DateOnly DataDeNascimento { get; set; }
    }
}
