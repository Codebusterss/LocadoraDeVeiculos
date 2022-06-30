using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(condutor);

            return resultadoValidacao;
        }
        public ValidationResult Editar(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(condutor);

            return resultadoValidacao;
        }
        private ValidationResult Validar(Condutor condutor)
        {
            var validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            if (NomeDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (condutor.CPF != "")
            {
                if (CPFDuplicado(condutor))
                    resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF duplicado"));
            }

            if (condutor.CNH != "")
            {
                if (CNHInvalida(condutor))
                    resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CHN invalida"));
            }

            if (condutor.CNH != "")
            {
                if (CNHDuplicado(condutor))
                    resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH duplicado"));
            }


            return resultadoValidacao;
        }
        private bool NomeDuplicado(Condutor condutor)
        {
            var clienteEncontrado = repositorioCondutor.SelecionarCondutorPorNome(condutor.Nome);

            return clienteEncontrado != null &&
                   clienteEncontrado.Nome == condutor.Nome &&
                   clienteEncontrado.ID != condutor.ID;
        }

        private bool CPFDuplicado(Condutor condutor)
        {
            var clienteEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return clienteEncontrado != null &&
                   clienteEncontrado.CPF == condutor.CPF &&
                   clienteEncontrado.ID != condutor.ID;
        }
        private bool CNHInvalida(Condutor condutor)
        {
            var clienteEncontrado = repositorioCondutor.SelecionarClientePorCNPJ(condutor.CNH);

            return clienteEncontrado != null &&
                   clienteEncontrado.CNH == condutor.CNH &&
                   clienteEncontrado.ID != condutor.ID;

        }

        private bool CNHDuplicado(Condutor condutor)
        {
            var clienteEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.CNH);

            return clienteEncontrado != null &&
                   clienteEncontrado.CNH == condutor.CNH &&
                   clienteEncontrado.ID != condutor.ID;
        }

    }
}
