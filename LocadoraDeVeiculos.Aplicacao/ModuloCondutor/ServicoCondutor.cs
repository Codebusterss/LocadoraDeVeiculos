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
                if (CNHDuplicado(condutor))
                    resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH duplicado"));
            }


            return resultadoValidacao;
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
