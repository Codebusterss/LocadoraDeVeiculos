using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.DataLocacao)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.DataDevolucao)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.StatusLocacao)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Funcionario)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Veiculo)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Plano)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Condutor)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Taxas)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Valor)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
