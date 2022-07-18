using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .MinimumLength(3)
                .MaximumLength(60)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty(); 
            RuleFor(x => x.Marca)
                .MinimumLength(3)
                .MaximumLength(60)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty();
            RuleFor(x => x.Placa)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Cor)
                .MinimumLength(3)
                .MaximumLength(60)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.CapacidadeDoTanque)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.KmPercorrido)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Ano)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.TipoCombustivel)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.GrupoDeVeiculo)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Foto)
                .NotNull()
                .NotEmpty();
        }
    }
}
