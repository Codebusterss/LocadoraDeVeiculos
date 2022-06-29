using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            if (NomeDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (cliente.CPF != "")
            {
                if (CPFDuplicado(cliente))
                    resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF duplicado"));
            }

            if (cliente.CNPJ != "")
            {
                if (CNPJDuplicado(cliente))
                    resultadoValidacao.Errors.Add(new ValidationFailure("CNPJ", "CNPJ duplicado"));
            }

            if (cliente.CNH != "")
            {
                if (CNHDuplicado(cliente))
                    resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH duplicado"));
            }


            return resultadoValidacao;
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

        private bool CNHDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCNH(cliente.CNH);

            return clienteEncontrado != null &&
                   clienteEncontrado.CNH == cliente.CNH &&
                   clienteEncontrado.ID != cliente.ID;
        }

    }
}

