using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Serilog;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using FluentResults;
using LocadoraDeVeiculos.ORM.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public interface IServicoPlanoDeCobranca
    {
        Result<PlanoDeCobranca> Editar(PlanoDeCobranca tplanoaxa);
        Result Excluir(PlanoDeCobranca plano);
        Result<PlanoDeCobranca> Inserir(PlanoDeCobranca plano);
        Result<PlanoDeCobranca> SelecionarPorId(Guid id);
        Result<List<PlanoDeCobranca>> SelecionarTodos();
    }

    public class ServicoPlanoDeCobranca : IServicoPlanoDeCobranca
    {
        private RepositorioPlanoORM repositorioPlanoDeCobranca;
        private IContextoPersistencia contextoPersistencia;

        public ServicoPlanoDeCobranca(RepositorioPlanoORM repositorioPlano, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioPlanoDeCobranca = repositorioPlano;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando inserir plano de cobrança... {@p}", plano);

            Result resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o plano de cobrança {PlanoID} - {Motivo}",
                       plano.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Inserir(plano);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano de Cobrança {PlanoID} inserido com sucesso.", plano.ID);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o plano de cobrança.";

                Log.Logger.Error(ex, msgErro + "{PlanoID}", plano.ID);

                return Result.Fail(msgErro);
            }
        }
        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando editar plano de cobrança... {@p}", plano);

            Result resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o plano de cobrança {PlanoID} - {Motivo}",
                       plano.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Editar(plano);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano de cobrança {PlanoID} editado com sucesso.", plano.ID);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o plano de cobrança.";

                Log.Logger.Error(ex, msgErro + "{PlanoID}", plano.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando excluir plano de cobrança... {@p}", plano);

            try
            {
                repositorioPlanoDeCobranca.Excluir(plano);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano de cobrança {PlanoID} excluído com sucesso.", plano.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o plano de cobrança.";

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
                string msgErro = "Falha no sistema ao tentar selecionar todos os planos de cobrança.";
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
                string msgErro = "Falha no sistema ao tentar selecionar o plano de cobrança.";
                Log.Logger.Error(ex, msgErro + "{CondutorID}", id);

                return Result.Fail(msgErro);
            }
        }


        private Result Validar(PlanoDeCobranca plano)
        {
            var validador = new ValidadorPlanoDeCobranca();

            Log.Logger.Debug("Validando plano de cobrança... {@p}", plano);

            var resultadoValidacao = validador.Validate(plano);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (GrupoDuplicado(plano))
                erros.Add(new Error("Grupo de Veículos duplicado."));

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

