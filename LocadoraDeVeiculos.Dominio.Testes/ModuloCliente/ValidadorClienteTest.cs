using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.TestHelper;

namespace LocadoraDeVeiculos.Dominio.Testes.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private Cliente cliente;
        private ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            cliente = new()
            {
                Nome = "Luan",
                CNH = "123.123.123-123",
                CPF = "123.123.123-12",
                Email = "luan@gmail.com",
                Endereco = "Rua Amorim",
                Telefone = "(12)91233-1233",
                PessoaFisica = true,
            };

            validador = new ValidadorCliente();
        }

        [TestMethod]
        public void Nome_nao_deve_ser_nulo()
        {
            // arrange
            cliente.Nome = null;

            // action
            validador = new ValidadorCliente();

            // assert
            var resultadoValidacao = validador.TestValidate(cliente);

            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ser_Valido()
        {
            // arrange
            cliente.Nome = "123@rodriguin";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ter_3_letras()
        {
            // arrange
            cliente.Nome = "lu";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Nome);
        }

        [TestMethod]
        public void Endereco_deve_ter_5_letras()
        {
            // arrange
            cliente.Endereco = "rua ";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Endereco);
        }

        [TestMethod]
        public void Endereco_nao_deve_ser_nulo()
        {
            // arrange
            cliente.Endereco = null;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Endereco);
        }

        [TestMethod]
        public void Email_nao_deve_ser_nulo()
        {
            // arrange
            cliente.Email = null;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [TestMethod]
        public void Email_deve_seguir_o_padrao()
        {
            // arrange
            cliente.Email = "luanemailtestesemarrobaepontocom";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [TestMethod]
        public void Telefone_nao_deve_ser_nulo()
        {
            // arrange
            cliente.Telefone = null;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_seguir_o_padrao()
        {
            // arrange - 1 digito a mais
            cliente.Telefone = "129123312331";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_seguir_o_padrao2()
        {
            // arrange - 2 digito a menos
            cliente.Telefone = "129123312";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.Telefone);
        }

        [TestMethod]
        public void CPF_nao_deve_ser_nulo()
        {
            // arrange
            cliente.CPF = null;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CPF);
        }

        [TestMethod]
        public void CPF_deve_seguir_o_padrao()
        {
            // arrange - 1 digito a mais
            cliente.CPF = "123123123123";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CPF);
        }

        [TestMethod]
        public void CPF_deve_seguir_o_padrao2()
        {
            // arrange - 1 digito a menos
            cliente.CPF = "1231231231";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CPF);
        }

        [TestMethod]
        public void CNH_nao_deve_ser_nulo()
        {
            // arrange
            cliente.CNH = null;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNH);
        }

        [TestMethod]
        public void CNH_deve_seguir_o_padrao()
        {
        // arrange  - 1 digito a mais
        cliente.CNH = "1234567891234";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNH);
        }

        [TestMethod]
        public void CNH_deve_seguir_o_padrao2()
        {
            // arrange  - 1 digito a menos
            cliente.CNH = "12345678912";

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNH);
        }

        [TestMethod]
        public void CNPJ_nao_deve_ser_nulo()
        {
            // arrange
            cliente.CNPJ = null;
            cliente.CNH = "";
            cliente.CPF = "";
            cliente.PessoaFisica = false;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNPJ);
        }

        [TestMethod]
        public void CNPJ_deve_seguir_o_padrao()
        {
            // arrange - 1 digito a mais
            cliente.CNPJ = "12345678912345";
            cliente.CNH = "";
            cliente.CPF = "";
            cliente.PessoaFisica = false;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNPJ);
        }

        [TestMethod]
        public void CNPJ_deve_seguir_o_padrao2()
        {
            // arrange - 1 digito a menos
            cliente.CNPJ = "123456789123";
            cliente.CNH = "";
            cliente.CPF = "";
            cliente.PessoaFisica = false;

            // action
            var resultadoValidacao = validador.TestValidate(cliente);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(c => c.CNPJ);
        }


    }
}
