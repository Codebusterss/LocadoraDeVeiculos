using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.GrupoDeVeiculos)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.DiarioValorDia)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.DiarioValorKM)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.LivreValorDia)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.ControladoValorDia)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.ControladoLimiteKM)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.ControladoValorKM)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}