using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(3)
                .MaximumLength(60)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Login)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Senha)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.DataAdmissao)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Salario)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);

        }
    }
}