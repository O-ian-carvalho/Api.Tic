using FluentValidation;
using ApiTic.Business.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Validations
{
    public class TipoDeProdutoValidation : AbstractValidator<TipoDeProduto>
    {
        public TipoDeProdutoValidation()
        {
            RuleFor(c => c.Titulo).NotEmpty().WithMessage("O titulo do {PropertyName} não pode ser vazio");
        }
    }
}
