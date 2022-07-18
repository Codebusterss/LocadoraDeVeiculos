using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Serilog;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentResults;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor) 
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir condutor... {@c}", condutor);

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o condutor {CondutorID} - {Motivo}",
                       condutor.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);

                Log.Logger.Information("Condutor {CondutorID} inserido com sucesso.", condutor.ID);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o condutor.";

                Log.Logger.Error(ex, msgErro + "{CondutorID}", condutor.ID);

                return Result.Fail(msgErro);
            }
        }
        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor... {@c}", condutor);

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o condutor {CondutorID} - {Motivo}",
                       condutor.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                Log.Logger.Information("Condutor {CondutorID} editado com sucesso.", condutor.ID);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o condutor.";

                Log.Logger.Error(ex, msgErro + "{CondutorID}", condutor.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir condutor... {@c}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);

                Log.Logger.Information("Condutor {CondutorID} excluído com sucesso.", condutor.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o condutor.";

                Log.Logger.Error(ex, msgErro + "{CondutorID}", condutor.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o condutor.";
                Log.Logger.Error(ex, msgErro + "{CondutorID}", id);

                return Result.Fail(msgErro);
            }
        }


        private Result Validar(Condutor condutor)
        {
            var validador = new ValidadorCondutor();

            Log.Logger.Debug("Validando condutor... {@c}", condutor);

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(condutor))
                erros.Add(new Error("Nome duplicado."));

            if (CPFDuplicado(condutor))
                erros.Add(new Error("CPF duplicado."));

            if (CNHDuplicado(condutor))
                erros.Add(new Error("CNH duplicado."));

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorNome(condutor.Nome);

            return condutorEncontrado != null &&
                   condutorEncontrado.Nome == condutor.Nome &&
                   condutorEncontrado.ID != condutor.ID;
        }

        private bool CPFDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return condutorEncontrado != null &&
                   condutorEncontrado.CPF == condutor.CPF &&
                   condutorEncontrado.ID != condutor.ID;
        }
       

        private bool CNHDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.CNH);

            return condutorEncontrado != null &&
                   condutorEncontrado.CNH == condutor.CNH &&
                   condutorEncontrado.ID != condutor.ID;
        }

    }
}
