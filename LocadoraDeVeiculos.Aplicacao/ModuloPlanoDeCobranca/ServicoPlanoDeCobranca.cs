using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Serilog;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using FluentResults;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando inserir Plano de Cobranca... {@p}", plano);

            Result resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Plano de Cobranca {PlanoID} - {Motivo}",
                       plano.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Inserir(plano);

                Log.Logger.Information("Plano de Cobranca {PlanoID} inserido com sucesso", plano.ID);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Plano de Cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoID}", plano.ID);

                return Result.Fail(msgErro);
            }
        }
        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando editar Plano de Cobranca... {@p}", plano);

            Result resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Plano de Cobranca {PlanoID} - {Motivo}",
                       plano.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Editar(plano);

                Log.Logger.Information("Plano de Cobranca {PlanoID} editado com sucesso", plano.ID);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Plano de Cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoID}", plano.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando excluir Plano de Cobranca... {@p}", plano);

            try
            {
                repositorioPlanoDeCobranca.Excluir(plano);

                Log.Logger.Information("Plano de Cobranca {PlanoID} excluído com sucesso", plano.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Plano de Cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoID}", plano.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Planos de Cobranca.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoDeCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Plano de Cobranca.";
                Log.Logger.Error(ex, msgErro + "{CondutorID}", id);

                return Result.Fail(msgErro);
            }
        }


        private Result Validar(PlanoDeCobranca plano)
        {
            var validador = new ValidadorPlanoDeCobranca();

            Log.Logger.Debug("Validando Plano de Cobranca... {@p}", plano);

            var resultadoValidacao = validador.Validate(plano);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (GrupoDuplicado(plano))
                erros.Add(new Error("Grupo de Veículos duplicado"));

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
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

