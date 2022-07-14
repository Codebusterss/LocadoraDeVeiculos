using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Serilog;
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


            Log.Logger.Debug("Tentando inserir Taxa... {@t}", taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Debug("Taxa {TaxaDesc} inserido com sucesso.", taxa.Descricao);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Taxa {TaxaDesc} - {Motivo}.", taxa.Descricao, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            Log.Logger.Debug("Tentando editar Taxa... {@t}", taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Debug("Taxa {TaxaDesc} editada com sucesso.", taxa.Descricao);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxa {TaxaDesc} - {Motivo}.", taxa.Descricao, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            Log.Logger.Debug("Validando Taxa... {@t}", taxa);

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
