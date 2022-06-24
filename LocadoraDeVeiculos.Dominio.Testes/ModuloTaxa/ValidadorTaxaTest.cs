using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Testes.ModuloTaxa
{
    [TestClass]
    public class ValidadorTaxaTest
    {
        private Taxa taxa;
        private ValidadorTaxa validadorTaxa;

        public ValidadorTaxaTest()
        {
            taxa = new()
            {
                Descricao = "GPS",
                Valor = 150,
                Tipo = "Fixo"
            };

            validadorTaxa = new ValidadorTaxa();
        }

        [TestMethod]
        public void Descricao_nao_pode_ser_vazia()
        {
            // arrange
            taxa.Descricao = null;

            // action
            validadorTaxa = new ValidadorTaxa();

            // assert
            var resultadoValidacao = validadorTaxa.TestValidate(taxa);

            resultadoValidacao.ShouldHaveValidationErrorFor(t => t.Descricao);
        }

        [TestMethod]
        public void Descricao_deve_ter_3_caracteres()
        {
            // arrange
            taxa.Descricao = "gp";

            // action
            validadorTaxa = new ValidadorTaxa();

            // assert
            var resultadoValidacao = validadorTaxa.TestValidate(taxa);

            resultadoValidacao.ShouldHaveValidationErrorFor(t => t.Descricao);
        }

        [TestMethod]
        public void Valor_nao_pode_ser_0_ou_negativo()
        {
            // arrange
            taxa.Valor = -23;

            // action
            validadorTaxa = new ValidadorTaxa();

            // assert
            var resultadoValidacao = validadorTaxa.TestValidate(taxa);

            resultadoValidacao.ShouldHaveValidationErrorFor(t => t.Valor);
        }
    }
}
