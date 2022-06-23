using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo
{
    public class ValidadorGrupoDeVeiculo : AbstractValidator<GrupoDeVeiculo>
    {
        public ValidadorGrupoDeVeiculo()
        {
            RuleFor(x => x.Nome)
              .NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
