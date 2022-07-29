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
        Result Excluir(Locacao locacao);
        Result<Locacao> Inserir(Locacao locacao);
        Result<Locacao> SelecionarPorId(Guid id);
        Result<List<Locacao>> SelecionarTodos();
    }

    public class ServicoLocacao : IServicoLocacao
    {
        private RepositorioLocacaoORM repositorioLocacao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoLocacao(RepositorioLocacaoORM repositoriolocacao, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioLocacao = repositoriolocacao;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir locação... {@l}", locacao);

            Result resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a locação {LocacaoID} - {Motivo}",
                       locacao.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(locacao);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locação {LocacaoID} inserida com sucesso.", locacao.ID);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a locação.";

                Log.Logger.Error(ex, msgErro + "{LocacaoID}", locacao.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Debug("Tentando editar locação... {@l}", locacao);

            Result resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a locação {LocacaoID} - {Motivo}",
                       locacao.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);
                contextoPersistencia.GravarDados();


                Log.Logger.Information("locação {LocacaoID} editada com sucesso.", locacao.ID);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a locação.";

                Log.Logger.Error(ex, msgErro + "{LocacaoID}", locacao.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao Locacao)
        {
            Log.Logger.Debug("Tentando excluir locação... {@l}", Locacao);

            try
            {
                repositorioLocacao.Excluir(Locacao);
                contextoPersistencia.GravarDados();


                Log.Logger.Information("Locação {LocacaoID} excluída com sucesso.", Locacao.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a locação.";

                Log.Logger.Error(ex, msgErro + "{LocacaoID}", Locacao.ID);

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
                string msgErro = "Falha no sistema ao tentar selecionar todas as locações.";
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
                string msgErro = "Falha no sistema ao tentar selecionar a locação.";
                Log.Logger.Error(ex, msgErro + "{LocacaoID}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Locacao locacao)
        {
            var validador = new ValidadorLocacao();

            Log.Logger.Debug("Validando locação... {@l}", locacao);

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }
    }
}
