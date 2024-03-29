﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Serilog;
using FluentValidation.Results;
using FluentResults;
using LocadoraDeVeiculos.ORM.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxa
{
    public interface IServicoTaxa
    {
        Result<Taxa> Editar(Taxa taxa);
        Result Excluir(Taxa taxa);
        Result<Taxa> Inserir(Taxa taxa);
        Result<Taxa> SelecionarPorId(Guid id);
        Result<List<Taxa>> SelecionarTodos();
    }

    public class ServicoTaxa : IServicoTaxa
    {
        private RepositorioTaxaORM repositorioTaxa;
        private IContextoPersistencia contextoPersistencia;

        public ServicoTaxa(RepositorioTaxaORM repositorioTaxa, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a taxa {TaxaID} - {Motivo}",
                       taxa.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Inserir(taxa);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaID} inserido com sucesso.", taxa.ID);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a taxa.";

                Log.Logger.Error(ex, msgErro + "{TaxaID}", taxa.ID);

                return Result.Fail(msgErro);
            }
        }
        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... {@t}", taxa);

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a taxa {TaxaID} - {Motivo}",
                       taxa.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Editar(taxa);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaID} editado com sucesso.", taxa.ID);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a taxa.";

                Log.Logger.Error(ex, msgErro + "{TaxaID}", taxa.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir taxa... {@t}", taxa);

            try
            {
                repositorioTaxa.Excluir(taxa);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaID} excluído com sucesso.", taxa.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a taxa.";

                Log.Logger.Error(ex, msgErro + "{TaxaID}", taxa.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos as taxas.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a taxa.";
                Log.Logger.Error(ex, msgErro + "{TaxaID}", id);

                return Result.Fail(msgErro);
            }
        }


        private Result Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            Log.Logger.Debug("Validando taxa... {@t}", taxa);

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (DescricacaoDuplicada(taxa))
                erros.Add(new Error("Descrição duplicada."));

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
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
