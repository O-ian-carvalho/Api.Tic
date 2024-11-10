using ApiTic.Business.Models;
using FluentValidation;
using System;

namespace ApiTic.Business.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(pedido => pedido.ClienteId)
                .NotEmpty().WithMessage("O ClienteId é obrigatório.")
                .Must(id => id != Guid.Empty).WithMessage("O ClienteId deve ser um GUID válido.");

            RuleFor(pedido => pedido.Status)
                .IsInEnum().WithMessage("O status do pedido é inválido.");

            RuleFor(pedido => pedido.Produtos)
                .NotEmpty().WithMessage("A lista de produtos não pode estar vazia.");

            RuleFor(pedido => pedido.Cliente)
                .NotNull().WithMessage("O cliente deve ser especificado.");
        }
    }
}
