using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Valor)
          .NotNull().NotEmpty().GreaterThanOrEqualTo(0);

            RuleFor(x => x.Tipo)
            .NotNull().NotEmpty();

            RuleFor(x => x.Descricao)
            .NotNull().NotEmpty().MinimumLength(3);
        }
    }
}

