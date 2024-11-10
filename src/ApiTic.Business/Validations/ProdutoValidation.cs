using System;
using ApiTic.Business.Models;
using FluentValidation;

namespace ApiTic.Business.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(produto => produto.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(3, 100).WithMessage("O nome do produto deve ter entre 3 e 100 caracteres.");

            RuleFor(produto => produto.Valor)
                .GreaterThan(0).WithMessage("O valor do produto deve ser maior que zero.");

            RuleFor(produto => produto.CategoriaId)
                .NotEmpty().WithMessage("O ID da categoria é obrigatório.")
                .Must(id => id != Guid.Empty).WithMessage("O ID da categoria deve ser um GUID válido.");

            RuleFor(produto => produto.Categoria)
                .NotNull().WithMessage("A categoria do produto deve ser especificada.");
        }
    }
}
