using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Testes.ModuloCondutor
{
    public class ValidadorCondutorTest
    {

        private readonly Condutor condutor;
        private readonly ValidadorCondutor validador;

        public ValidadorCondutorTest()
        {
            condutor = new()
            {
                Cliente = new()
                {
                    Nome = "Limosine",
                },

                Endereco = "Rua Santo Espirito",
                Email = "Livia@gmail.com", //luan perguntar
               

            };

            validador = new ValidadorCondutor();
        }

        [TestMethod]
        public void Cliente_Nao_Pode_Ser_Nulo()
        {
            // arrange
            condutor.Cliente = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cliente);
        }
        [TestMethod]
        public void CPF_nao_deve_ser_nulo()
        {
            // arrange
            condutor.CPF = null;

            // action
            var resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CPF);
        }
        [TestMethod]
        public void Email_nao_deve_ser_nulo()
        {
            // arrange
            condutor.Email = null;

            // action
            var resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Email);
        }


        [TestMethod]
        public void Endereco_nao_deve_ser_nulo()
        {
            // arrange
            condutor.Endereco = null;

            // action
            var resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Endereco);
        }
        [TestMethod]
        public void Telefone_nao_deve_ser_nulo()
        {
            // arrange
            condutor.Telefone = null;

            // action
            var resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Telefone);
        }
        [TestMethod]
        public void Nome_Deve_Ter_No_Minimo_3_letras()
        {
            // arrange
            condutor.Nome = "lu";

            // action
            var resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Nome);
        }
        [TestMethod]
        public void CNH_deve_seguir_o_padrao()
        {
            // arrange  - 1 digito a mais
            condutor.CNH = "1234769891034";

            // action
            var resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNH);
        }

        [TestMethod]
        public void CNH_deve_seguir_o_padrao2()
        {
            // arrange  - 1 digito a menos
            condutor.CNH = "12345638982";

            // action
            var resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNH);
        }



    }
}
