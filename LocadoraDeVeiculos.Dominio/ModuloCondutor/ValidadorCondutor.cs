using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            DateTime hoje = DateTime.Today;
            hoje = hoje.AddHours(23).AddMinutes(59).AddSeconds(59);
            RuleFor(x => x.Nome)
                .MinimumLength(3)
                .MaximumLength(60)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty();
            RuleFor(x => x.Endereco)
                .MinimumLength(5)
                .MaximumLength(60)
                .NotEmpty();
            RuleFor(x => x.Email)
                .MinimumLength(4)
                .MaximumLength(60)
                .Matches(new Regex(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$"))
                .NotEmpty();
            RuleFor(x => x.Telefone)
                .Matches(new Regex(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$"))
                .NotEmpty();
            RuleFor(x => x.CPF)
                .Matches(new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
               .NotEmpty();
            RuleFor(x => x.ValidadeCNH)
               .NotNull().NotEmpty().GreaterThan(DateTime.MinValue).LessThanOrEqualTo(hoje);
            RuleFor(x => x.CNH)
                .Matches(new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{3}$"))
                .NotEmpty();

        }
    }
}
