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
    [TestClass]
    public class ValidadorCondutorTest
    {
        private readonly ValidadorCondutor validador;

        private Condutor? condutor;
      
        public ValidadorCondutorTest()
        {
            validador = new();
        }
        private Condutor GerarCondutor()
        {
            return new Condutor
            {
                Nome = "Joao",
                CPF = "222.341.161-01",
                Telefone = "(23)97575-7575",
                Email = "joao@gmail.com",
                Endereco = "Lages",
                ValidadeCNH = DateTime.Now.Date,
                CNH = "7543780987",
                
            };
        }



        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            //arrange
            condutor = GerarCondutor();

            condutor.Telefone = "";

            //action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);

            //assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Telefone);
        }

        [TestMethod]
        public void Email_nao_deve_ser_nulo()
        {
            // arrange
            condutor = GerarCondutor();
            condutor.Email = null;

            // action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Email);
        }
        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            //arrange
            condutor = GerarCondutor();

            condutor.Nome = "@1d7u8d0a";

            //action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);

            //assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Nome);
        }


        [TestMethod]
        public void Endereco_nao_deve_ser_nulo()
        {
            // arrange
            condutor = GerarCondutor();
            condutor.Endereco = "";

            // action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);

            // assert

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Endereco);
        }
        [TestMethod]
        public void Telefone_nao_deve_ser_nulo()
        {
            // arrange
            condutor = GerarCondutor();
            condutor.Telefone = "";

            // action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Telefone);
        }
        [TestMethod]
        public void Nome_Deve_Ter_No_Minimo_3_letras()
        {
            // arrange
            condutor = GerarCondutor();
            condutor.Nome = "lu";

            // action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);


            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Nome);
        }
        [TestMethod]
        public void Cnh_deve_ser_valida()
        {
            //arrange
            condutor = GerarCondutor();

            condutor.CNH = "1678";

            //action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);

            //assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNH);
        }
        [TestMethod]
        public void Cpf_deve_ser_valido()
        {
            //arrange
            condutor = GerarCondutor();

            condutor.CPF = "6584";

            //action
            TestValidationResult<Condutor> resultadoValidacao = validador.TestValidate(condutor);

            //assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CPF);
        }


    }
}
