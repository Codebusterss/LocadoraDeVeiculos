using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using FluentValidation.Results;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(taxa);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (DescricacaoDuplicada(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Descricao", "Descricao duplicada"));

            return resultadoValidacao;
        }

        private bool DescricacaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorDescricao(taxa.Descricao);

            return taxaEncontrada != null &&
                   taxaEncontrada.Descricao == taxa.Descricao &&
                   taxaEncontrada.ID != taxa.ID;
        }
    }
}
