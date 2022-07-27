using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Serilog;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using FluentResults;
using LocadoraDeVeiculos.ORM.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Aplicacao.ModuloFuncionario
{
    public interface IServicoFuncionario
    {
        Result<Funcionario> Editar(Funcionario funcionario);
        Result Excluir(Funcionario funcionario);
        Result<Funcionario> Inserir(Funcionario funcionario);
        Result<Funcionario> SelecionarPorId(Guid id);
        Result<List<Funcionario>> SelecionarTodos();
    }

    public class ServicoFuncionario : IServicoFuncionario
    {
        private RepositorioFuncionarioORM repositorioFuncionario;
        private IContextoPersistencia contextoPersistencia;

        public ServicoFuncionario(RepositorioFuncionarioORM repositorioFuncionario, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Funcionario> Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionário... {@f}", funcionario);

            Result resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o funcionário {FuncionarioID} - {Motivo}",
                       funcionario.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Inserir(funcionario);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Funcionário {FuncionarioID} inserido com sucesso.", funcionario.ID);

                return Result.Ok(funcionario);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o funcionário.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioID}", funcionario.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar funcionário... {@f}", funcionario);

            Result resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o funcionário {FuncionarioID} - {Motivo}",
                       funcionario.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Editar(funcionario);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Funcionário {FuncionarioID} editado com sucesso.", funcionario.ID);

                return Result.Ok(funcionario);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o funcionário.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioID}", funcionario.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando excluir funcionário... {@f}", funcionario);

            try
            {
                repositorioFuncionario.Excluir(funcionario);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Funcionário {FuncionarioID} excluído com sucesso.", funcionario.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o funcionário.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioID}", funcionario.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result < List<Funcionario> > SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os funcionários.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o funcionário.";
                Log.Logger.Error(ex, msgErro + "{FuncionarioID}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            Log.Logger.Debug("Validando funcionário... {@f}", funcionario);

            var resultadoValidacao = validador.Validate(funcionario);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(funcionario))
                erros.Add(new Error("Nome duplicado."));

            if (LoginDuplicado(funcionario))
                erros.Add(new Error("Login duplicado."));

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.ID != funcionario.ID;
        }

        private bool LoginDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorLogin(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == funcionario.Login &&
                   funcionarioEncontrado.ID != funcionario.ID;
        }
    }
}
