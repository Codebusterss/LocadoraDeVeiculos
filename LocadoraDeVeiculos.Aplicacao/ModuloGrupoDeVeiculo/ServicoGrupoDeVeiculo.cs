using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog; 
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using FluentValidation.Results;
using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo
{
    public interface IServicoGrupoDeVeiculo
    {
        Result<GrupoDeVeiculo> Editar(GrupoDeVeiculo grupoDeVeiculo);
        Result Excluir(GrupoDeVeiculo grupoDeVeiculo);
        Result<GrupoDeVeiculo> Inserir(GrupoDeVeiculo grupoDeVeiculo);
        Result<GrupoDeVeiculo> SelecionarPorId(Guid id);
        Result<List<GrupoDeVeiculo>> SelecionarTodos();
    }

    public class ServicoGrupoDeVeiculo : IServicoGrupoDeVeiculo
    {
        private IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo;

        public ServicoGrupoDeVeiculo(IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo)
        {
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiculo;
        }

        public Result<GrupoDeVeiculo> Inserir(GrupoDeVeiculo grupo)
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
                repositorioGrupoDeVeiculo.Inserir(grupo);

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

        public Result<GrupoDeVeiculo> Editar(GrupoDeVeiculo grupo)
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
                repositorioGrupoDeVeiculo.Editar(grupo);

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

        public Result Excluir(GrupoDeVeiculo grupoDeVeiculo)
        {
            Log.Logger.Debug("Tentando excluir grupo de veículos... {@g}", grupoDeVeiculo);

            try
            {
                repositorioGrupoDeVeiculo.Excluir(grupoDeVeiculo);

                Log.Logger.Information("Grupo de veículos {GrupoID} excluído com sucesso.", grupoDeVeiculo.ID);

                return Result.Ok();
            }
            catch (NaoPodeExcluirRegistroException ex)
            {
                string msgErro = $"O Grupo de veículos {grupoDeVeiculo.Nome} está relacionado com um plano de cobrança e não pode ser excluído.";

                Log.Logger.Error(ex, msgErro + "{GrupoID}", grupoDeVeiculo.ID);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo de veículos.";

                Log.Logger.Error(ex, msgErro + "{GrupoID}", grupoDeVeiculo.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<GrupoDeVeiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioGrupoDeVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os grupos de veículos.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoDeVeiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioGrupoDeVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o grupo de veículos.";
                Log.Logger.Error(ex, msgErro + "{GrupoID}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(GrupoDeVeiculo grupo)
        {
            var validador = new ValidadorGrupoDeVeiculo();

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

        private bool NomeDuplicado(GrupoDeVeiculo grupoDeVeiculo)
        {
            var grupoEncontrado = repositorioGrupoDeVeiculo.SelecionarGrupoPorNome(grupoDeVeiculo.Nome);

            return grupoEncontrado != null &&
                   grupoEncontrado.Nome == grupoDeVeiculo.Nome &&
                   grupoEncontrado.ID != grupoDeVeiculo.ID;
        }

    }
}

