using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using FluentValidation.Results;
using FluentResults;
using Serilog;
using LocadoraDeVeiculos.ORM.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo
{
    public interface IServicoVeiculo
    {
        Result<Veiculo> Editar(Veiculo veiculo);
        Result Excluir(Veiculo veiculo);
        Result<Veiculo> Inserir(Veiculo veiculo);
        Result<Veiculo> SelecionarPorId(Guid id);
        Result<List<Veiculo>> SelecionarTodos();
    }

    public class ServicoVeiculo : IServicoVeiculo
    {
        private RepositorioVeiculoORM repositorioVeiculo;
        private IContextoPersistencia contextoPersistencia;

        public ServicoVeiculo(RepositorioVeiculoORM repositorioVeiculo, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir veículo... {@v}", veiculo);

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o veículo {VeiculoID} - {Motivo}",
                       veiculo.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Inserir(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veículo {VeiculoID} inserido com sucesso.", veiculo.ID);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o veículo.";

                Log.Logger.Error(ex, msgErro + "{VeiculoID}", veiculo.ID);

                return Result.Fail(msgErro);
            }
        }
        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo... {@v}", veiculo);

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o veículo {VeiculoID} - {Motivo}",
                       veiculo.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Editar(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veículo {VeiculoID} editado com sucesso.", veiculo.ID);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o veículo.";

                Log.Logger.Error(ex, msgErro + "{VeiculoID}", veiculo.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir veículo... {@v}", veiculo);

            try
            {
                repositorioVeiculo.Excluir(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veículo {VeiculoID} excluído com sucesso.", veiculo.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o veículo.";

                Log.Logger.Error(ex, msgErro + "{VeiculoID}", veiculo.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os veículos.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o veículo.";
                Log.Logger.Error(ex, msgErro + "{VeiculoID}", id);

                return Result.Fail(msgErro);
            }
        }


        private Result Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            Log.Logger.Debug("Validando veículo... {@v}", veiculo);

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (PlacaDuplicada(veiculo))
                erros.Add(new Error("Placa duplicada."));

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == veiculo.Placa &&
                   veiculoEncontrado.ID != veiculo.ID;
        }
    }
}
