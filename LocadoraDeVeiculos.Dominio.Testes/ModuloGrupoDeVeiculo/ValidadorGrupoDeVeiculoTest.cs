using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.TestHelper;

namespace LocadoraDeVeiculos.Dominio.Testes.ModuloGrupoDeVeiculo
{
    [TestClass]
    public class ValidadorGrupoDeVeiculoTest
    {
        private GrupoDeVeiculo grupoDeVeiculo;
        private ValidadorGrupoDeVeiculo validador;

        public ValidadorGrupoDeVeiculoTest()
        {
            grupoDeVeiculo = new()
            {
                Nome = "SUV"
            };

            validador = new ValidadorGrupoDeVeiculo();
        }

        [TestMethod]
        public void Nome_nao_deve_ser_nulo()
        {
            // arrange
            grupoDeVeiculo.Nome = null;

            // action
            validador = new ValidadorGrupoDeVeiculo();

            // assert
            var resultadoValidacao = validador.TestValidate(grupoDeVeiculo);

            resultadoValidacao.ShouldHaveValidationErrorFor(g => g.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ser_Valido()
        {
            // arrange
            grupoDeVeiculo.Nome = "123@rodriguin";

            // action
            var resultadoValidacao = validador.TestValidate(grupoDeVeiculo);

            // assert
            resultadoValidacao.ShouldHaveValidationErrorFor(g => g.Nome);
        }
    }
}
