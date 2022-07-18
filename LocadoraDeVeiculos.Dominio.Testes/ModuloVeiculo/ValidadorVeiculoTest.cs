using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Dominio.Testes.ModuloVeiculo
{
    [TestClass]
    public class ValidadorVeiculoTest
    {
        private readonly Veiculo veiculo;
        private readonly ValidadorVeiculo validador;

        public ValidadorVeiculoTest()
        {
            veiculo = new()
            {
                GrupoDeVeiculo = new()
                {
                    Nome = "SUV",
                },

                Marca = "Nissan",
                Modelo = "Kicks",
                Placa = "QIV-4123",
                Ano = 2018,
                Cor = "Branco",
                TipoCombustivel = "Gasolina",
                CapacidadeDoTanque = 50,
                KmPercorrido = 30000,
            };

            validador = new ValidadorVeiculo();
        }

        [TestMethod]
        public void Modelo_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Modelo = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Modelo);
        }

        [TestMethod]
        public void Modelo_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Modelo = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Modelo);
        }

        [TestMethod]
        public void Modelo_Deve_Ter_No_Minimo_2_Caracteres()
        {
            //arrange
            veiculo.Modelo = "a";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Modelo);
        }

        [TestMethod]
        public void Marca_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Marca = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Marca);
        }

        [TestMethod]
        public void Marca_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Marca = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Marca);
        }

        [TestMethod]
        public void Fabricante_Deve_Ter_No_Minimo_2_Caracteres()
        {
            //arrange
            veiculo.Marca = "a";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Marca);
        }

        [TestMethod]
        public void Cor_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Cor = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cor);
        }

        [TestMethod]
        public void Cor_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Cor = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cor);
        }

        [TestMethod]
        public void Cor_Deve_Ter_No_Minimo_2_Caracteres()
        {
            //arrange
            veiculo.Cor = "a";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cor);
        }

        [TestMethod]
        public void Placa_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Placa = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Placa);
        }

        [TestMethod]
        public void Placa_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Placa = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Placa);
        }

        [TestMethod]
        public void TipoCombustivel_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.TipoCombustivel = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.TipoCombustivel);
        }

        [TestMethod]
        public void TipoCombustivel_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.TipoCombustivel = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.TipoCombustivel);
        }

        [TestMethod]
        public void CapacidadeTanque_Deve_Ser_Maior_Que_0()
        {
            //arrange
            veiculo.CapacidadeDoTanque = 0;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.CapacidadeDoTanque);
        }

        [TestMethod]
        public void GrupoVeiculos_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.GrupoDeVeiculo = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.GrupoDeVeiculo);
        }

        [TestMethod]
        public void Foto_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Foto = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Foto);
        }
    }
}
