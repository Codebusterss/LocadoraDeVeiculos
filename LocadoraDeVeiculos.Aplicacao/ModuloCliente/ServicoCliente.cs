﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Serilog;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o cliente {ClienteID} - {Motivo}",
                       cliente.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                Log.Logger.Information("Cliente {ClienteID} inserido com sucesso.", cliente.ID);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente.";

                Log.Logger.Error(ex, msgErro + "{ClienteID}", cliente.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o cliente {ClienteID} - {Motivo}",
                       cliente.ID, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                Log.Logger.Information("Cliente {ClienteID} editado com sucesso.", cliente.ID);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente.";

                Log.Logger.Error(ex, msgErro + "{ClienteID}", cliente.ID);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir cliente... {@g}", cliente);

            try
            {
                repositorioCliente.Excluir(cliente);

                Log.Logger.Information("Cliente {ClienteID} excluído com sucesso.", cliente.ID);

                return Result.Ok();
            }
            catch (NaoPodeExcluirRegistroException ex)
            {
                string msgErro = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído.";

                Log.Logger.Error(ex, msgErro + "{ClienteID}", cliente.ID);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o cliente.";

                Log.Logger.Error(ex, msgErro + "{ClienteID}", cliente.ID);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os clientes.";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }
        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar um cliente.";
                Log.Logger.Error(ex, msgErro + "{ClienteID}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            Log.Logger.Debug("Validando cliente... {@c}", cliente);

            var resultadoValidacao = validador.Validate(cliente);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(cliente))
                erros.Add(new Error("Nome duplicado."));

            if (cliente.CPF != "")
            {
                if (CPFDuplicado(cliente))
                    erros.Add(new Error("CPF duplicado."));
            }
              
            if(cliente.CNPJ != "")
            {
                if (CNPJDuplicado(cliente))
                    erros.Add(new Error("CNPJ duplicado."));
            }


            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }


        private bool NomeDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorNome(cliente.Nome);

            return clienteEncontrado != null &&
                   clienteEncontrado.Nome == cliente.Nome &&
                   clienteEncontrado.ID != cliente.ID;
        }

        private bool CPFDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCPF(cliente.CPF);

            return clienteEncontrado != null &&
                   clienteEncontrado.CPF == cliente.CPF &&
                   clienteEncontrado.ID != cliente.ID;
        }

        private bool CNPJDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCNPJ(cliente.CNPJ);

            return clienteEncontrado != null &&
                   clienteEncontrado.CNPJ == cliente.CNPJ &&
                   clienteEncontrado.ID != cliente.ID;
        }

      

    }
}

