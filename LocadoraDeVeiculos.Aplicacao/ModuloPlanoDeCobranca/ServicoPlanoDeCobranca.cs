using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Serilog;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public ValidationResult Inserir(PlanoDeCobranca plano)
        {
            var resultadoValidacao = Validar(plano);

            Log.Logger.Debug("Tentando inserir Plano de cobrança... {@p}", plano);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Inserir(plano);
                Log.Logger.Debug("Plano de cobrança {PlanoNome} inserido com sucesso.", plano.GrupoDeVeiculos.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Plano de cobrança {PlanoNome} - {Motivo}.", plano.GrupoDeVeiculos.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca plano)
        {
            var resultadoValidacao = Validar(plano);

            Log.Logger.Debug("Tentando editar Plano de cobrança... {@p}", plano);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Editar(plano);
                Log.Logger.Debug("Plano de cobrança {PlanoNome} editado com sucesso.", plano.GrupoDeVeiculos.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Plano de cobrança {PlanoNome} - {Motivo}.", plano.GrupoDeVeiculos.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoDeCobranca plano)
        {
            var validador = new ValidadorPlanoDeCobranca();

            Log.Logger.Debug("Validando Plano de Cobranca... {@p}", plano);

            var resultadoValidacao = validador.Validate(plano);

            if (GrupoDuplicado(plano))
                resultadoValidacao.Errors.Add(new ValidationFailure("Grupo", "Grupo duplicado"));

            return resultadoValidacao;
        }

        private bool GrupoDuplicado(PlanoDeCobranca plano)
        {
            var planoEncontrado = repositorioPlanoDeCobranca.SelecionarPlanoPorGrupo(plano.GrupoDeVeiculos.ID);

            return planoEncontrado != null &&
                   planoEncontrado.GrupoDeVeiculos.ID == plano.GrupoDeVeiculos.ID &&
                   planoEncontrado.ID != plano.ID;
        }
    }
}

