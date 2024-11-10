using ApiTic.Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio")
                .Length(3,100).WithMessage("O Campo {PropertyName} Precia estar entre {MinLenght} e {MaxLenght}");

            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio")
               .EmailAddress().WithMessage("O e-mail deve estar em um formato válido.");

            RuleFor(c => c.NumeroContato)
                 .NotEmpty().WithMessage("O número de telefone é obrigatório.")
                 .Matches(@"^\+?\d{1,3} \(\d{2}\) \d{4,5}-\d{4}$")
                 .WithMessage("O número de telefone deve estar no formato correto, por exemplo: +55 (11) 91234-5678.");

        }
    }
}
