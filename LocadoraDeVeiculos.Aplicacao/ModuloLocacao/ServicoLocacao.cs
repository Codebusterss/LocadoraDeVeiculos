using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.ORM.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloLocacao
{
    public interface IServicoLocacao
    {
        Result<Locacao> Editar(Locacao locacao);
        Result Excluir(Locacao locacao));
        Result<Locacao> Inserir(Locacao locacao));
        Result<Locacao> SelecionarPorId(Guid id);
        Result<List<Locacao>> SelecionarTodos();
    }

    public class ServicoLocacao : IServicoLocacao
    {
        private RepositorioLocacaoORM repositorioLocacao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoLocacao(RepositorioLocacaoORM repositorioGrupo, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioLocacao = repositorioGrupo;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Locacao> Inserir(Locacao grupo)
        {
            Log.Logger.Debug("Tentando inserir grupo de veículos... {@g}", grupo);

            Result resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o grupo de veículos {GrupoID} - {Motivo}",
                       grupo.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(grupo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo de veículos {GrupoID} inserido com sucesso.", grupo.ID);

                return Result.Ok(grupo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o grupo de veículos.";

                Log.Logger.Error(ex, msgErro + "{GrupoID}", grupo.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao grupo)
        {
            Log.Logger.Debug("Tentando editar grupo de veículos... {@g}", grupo);

            Result resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o grupo de veículos {GrupoID} - {Motivo}",
                       grupo.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(grupo);
                contextoPersistencia.GravarDados();


                Log.Logger.Information("Grupo de veículos {GrupoID} editado com sucesso.", grupo.ID);

                return Result.Ok(grupo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o grupo de veículos.";

                Log.Logger.Error(ex, msgErro + "{GrupoID}", grupo.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao Locacao)
        {
            Log.Logger.Debug("Tentando excluir grupo de veículos... {@g}", Locacao);

            try
            {
                repositorioLocacao.Excluir(Locacao);
                contextoPersistencia.GravarDados();


                Log.Logger.Information("Grupo de veículos {GrupoID} excluído com sucesso.", Locacao.ID);

                return Result.Ok();
            }
            catch (NaoPodeExcluirRegistroException ex)
            {
                string msgErro = "";

                if (ex is DbUpdateException || ex is InvalidOperationException)
                {
                    msgErro = $"O grupo de veículos {Locacao.Nome} está relacionado com um veículo ou plano de cobrança e não pode ser excluído";

                    contextoPersistencia.DesfazerAlteracoes();
                }
                else
                {
                    msgErro = "Falha no sistema ao tentar excluir o Grupo de Veículos";
                }

                Log.Logger.Error(ex, msgErro + "{GrupoID}", Locacao.ID);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo de veículos.";

                Log.Logger.Error(ex, msgErro + "{GrupoID}", Locacao.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os grupos de veículos.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o grupo de veículos.";
                Log.Logger.Error(ex, msgErro + "{GrupoID}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Locacao grupo)
        {
            var validador = new ValidadorLocacao();

            Log.Logger.Debug("Validando grupo de veículos... {@g}", grupo);

            var resultadoValidacao = validador.Validate(grupo);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(grupo))
                erros.Add(new Error("Nome duplicado."));

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }

        private bool NomeDuplicado(Locacao Locacao)
        {
            var grupoEncontrado = repositorioLocacao.SelecionarGrupoPorNome(Locacao.Nome);

            return grupoEncontrado != null &&
                   grupoEncontrado.Nome == Locacao.Nome &&
                   grupoEncontrado.ID != Locacao.ID;
        }

    }
}
