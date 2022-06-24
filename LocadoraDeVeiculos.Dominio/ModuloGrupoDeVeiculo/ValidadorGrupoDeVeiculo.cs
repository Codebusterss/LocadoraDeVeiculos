using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo
{
    public class ValidadorGrupoDeVeiculo : AbstractValidator<GrupoDeVeiculo>
    {
        public ValidadorGrupoDeVeiculo()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(3)
                .MaximumLength(60)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty();
        }
    }
}
