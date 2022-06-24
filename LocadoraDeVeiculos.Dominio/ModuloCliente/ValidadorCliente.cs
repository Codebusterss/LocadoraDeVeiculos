using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
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
                .Matches(new Regex(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$"));
            RuleFor(x => x.Telefone)
                .Matches(new Regex(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$"));

            When(x => x.PessoaFisica == true, () => {
                RuleFor(x => x.CPF)
                .Matches(new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$"));
            });

            When(x => x.PessoaFisica == false, () =>
            {
                RuleFor(x => x.CNPJ)
                .Matches(new Regex(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/"));
            });
        }
    }
}
