using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Testes.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDeDadosTest : BaseIntegrationTest
    {
        private RepositorioVeiculoEmBancoDeDados repositorioVeiculo;
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;
        private Veiculo veiculo;
        private GrupoDeVeiculo grupo;

        public RepositorioVeiculoEmBancoDeDadosTest()
        {
            grupo = GerarGrupo();
            veiculo = GerarVeiculo();
            veiculo.GrupoDeVeiculo = grupo;
            repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
            repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
        }

        private GrupoDeVeiculo GerarGrupo()
        {
            GrupoDeVeiculo grupo = new GrupoDeVeiculo();
            grupo.Nome = "SUV";

            return grupo;
        }

        private Veiculo GerarVeiculo()
        {
            Veiculo veiculo = new Veiculo();

            veiculo.Marca = "Nissan";
            veiculo.Modelo = "Kicks";
            veiculo.Placa = "QIV-3213";
            veiculo.Cor = "Vermelho";
            veiculo.CapacidadeDoTanque = 50;
            veiculo.KmPercorrido = 300000;
            veiculo.Ano = 2018;
            veiculo.TipoCombustivel = "Gasolina";

            return veiculo;
        }

        [TestMethod]
        public void Deve_inserir_um_veiculo()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            //action
            var veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.ID);

            //assert
            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_editar_informacoes_veiculo()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            //action
            veiculo.Modelo = "GTR";
            veiculo.Marca = "Nissan";
            veiculo.Ano = 2012;
            veiculo.Placa = "SDA-1234";
            veiculo.KmPercorrido = 31000;
            veiculo.TipoCombustivel = "Gasolina";
            veiculo.CapacidadeDoTanque = 95;

            repositorioVeiculo.Editar(veiculo);

            //assert
            var veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.ID);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_excluir_grupo()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            //action
            repositorioVeiculo.Excluir(veiculo);

            //assert
            repositorioVeiculo.SelecionarPorId(veiculo.ID)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_veiculo()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioVeiculo.Inserir(veiculo);

            //action
            var veiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.ID);

            //assert
            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo, veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_veiculos()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            var v0 = new Veiculo("Nissan", "Kicks", "QIV-3213", "Vermelho", 50, 300000, 2018, "Gasolina", grupo);
            var v1 = new Veiculo("Nissan", "GTR", "PLD-3213", "Branco", 50, 300000, 2012, "Gasolina", grupo);
            var v2 = new Veiculo("Eclipse", "Lancer", "DAW-3213", "Azul", 50, 300000, 2010, "Gasolina", grupo);

            var repositorio = new RepositorioVeiculoEmBancoDeDados();

            repositorio.Inserir(v0);
            repositorio.Inserir(v1);
            repositorio.Inserir(v2);

            //action
            var veiculos = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(v0.Placa, veiculos[0].Placa);
            Assert.AreEqual(v1.Placa, veiculos[1].Placa);
            Assert.AreEqual(v2.Placa, veiculos[2].Placa);
            Assert.AreEqual(3, veiculos.Count);
        }
    }
}
