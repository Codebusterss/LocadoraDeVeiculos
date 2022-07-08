using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class ValidadorPlanoDeCobrancaTest
    {
        private readonly PlanoDeCobranca plano;
        private readonly ValidadorPlanoDeCobranca validador;

        public ValidadorPlanoDeCobrancaTest()
        {
            plano = new()
            {
                GrupoDeVeiculos = new()
                {
                    Nome = "Limosine",
                },

                DiarioValorDia = 100,
                DiarioValorKM = 10,
                LivreValorDia = 300,
                ControladoValorDia = 150,
                ControladoLimiteKM = 50,
                ControladoValorKM = 5

            };

            validador = new ValidadorPlanoDeCobranca();
        }

        [TestMethod]
        public void Grupo_Nao_Pode_Ser_Nulo()
        {
            // arrange
            plano.GrupoDeVeiculos = null;

            // action
            var resultado = validador.TestValidate(plano);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.GrupoDeVeiculos);
        }

        [TestMethod]
        public void Valores_nao_podem_ser_0_ou_negativo()
        {
            // arrange
            plano.DiarioValorDia = 0;
            plano.DiarioValorKM = -23;

            // action
            var resultado = validador.TestValidate(plano);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.DiarioValorDia);
            resultado.ShouldHaveValidationErrorFor(f => f.DiarioValorKM);
        }
    }
}