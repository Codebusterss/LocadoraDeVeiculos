using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentAssertions;
using FluentValidation.TestHelper;

namespace LocadoraDeVeiculos.Dominio.Testes.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTest
    {
        private Funcionario funcionario;
        private ValidadorFuncionario validador;
        private DateTime data = DateTime.Now;

        public FuncionarioTest()
        {
            funcionario = new()
            {
                Nome = "Luan",
                Login = "luan.c22",
                Senha = "luan",
                Salario = 1200,
                Admin = true,
                DataAdmissao = data
            };

            validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nome_nao_deve_ser_nulo()
        {
            // arrange
            funcionario.Nome = null;

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_nao_deve_ter_numeros()
        {
            // arrange
            funcionario.Nome = "123rech";

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Nome);
        }


        [TestMethod]
        public void Nome_nao_deve_ser_vazio()
        {
            // arrange
            funcionario.Nome = "";

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Login_nao_deve_ser_vazio()
        {
            // arrange
            funcionario.Login = "";

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Login_nao_deve_ser_nulo()
        {
            // arrange
            funcionario.Login = null;

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Senha_nao_deve_ser_nulo()
        {
            // arrange
            funcionario.Senha = null;

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void Senha_nao_deve_ser_vazio()
        {
            // arrange
            funcionario.Senha = "";

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void Salario_nao_deve_ser_0_ou_negativo()
        {
            // arrange
            funcionario.Salario = -23;

            // action
            validador = new ValidadorFuncionario();

            // assert
            var resultadoValidacao = validador.TestValidate(funcionario);

            resultadoValidacao.ShouldHaveValidationErrorFor(f => f.Salario);
        }

    }
}
