using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentAssertions;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloGrupoDeVeiculo
{
    [TestClass]
    public class RepositorioGrupoDeVeiculoEmBancoDeDadosTest
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorio;

        public RepositorioGrupoDeVeiculoEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM GRUPODEVEICULOS; DBCC CHECKIDENT (GRUPODEVEICULOS, RESEED, 0)");

            repositorio = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        }

        private GrupoDeVeiculo NovoGrupodeVeiculo()
        {
            GrupoDeVeiculo grupo = new GrupoDeVeiculo();
            grupo.Nome = "Uber";
            return grupo;
        }

        [TestMethod]
        public void Deve_inserir_novo_grupo_de_veiculo()
        {
            //arrange
            var grupoDeVeiculo = NovoGrupodeVeiculo();

            //action
            repositorio.Inserir(grupoDeVeiculo);

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupoDeVeiculo.ID);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupoDeVeiculo);
        }


        [TestMethod]
        public void Deve_editar_grupo_de_veiculo()
        {
            //arrange
            var grupoDeVeiculo = NovoGrupodeVeiculo();
            repositorio.Inserir(grupoDeVeiculo);
            grupoDeVeiculo.Nome = "Economico";

            //action
            repositorio.Editar(grupoDeVeiculo);

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupoDeVeiculo.ID);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupoDeVeiculo);
        }

        [TestMethod]
        public void Deve_excluir_grupo_de_veiculo()
        {
            //arrange
            var grupoDeVeiculo = NovoGrupodeVeiculo();
            repositorio.Inserir(grupoDeVeiculo);

            //action
            repositorio.Excluir(grupoDeVeiculo);

            //assert
            repositorio.SelecionarPorId(grupoDeVeiculo.ID).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_grupo()
        {
            //arrange
            var grupoDeVeiculo = NovoGrupodeVeiculo();
            repositorio.Inserir(grupoDeVeiculo);

            //action
            var grupoEncontrado = repositorio.SelecionarPorId(grupoDeVeiculo.ID);

            //assert
            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupoDeVeiculo);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupos()
        {
            //arrange
            var grupoDeVeiculo0 = NovoGrupodeVeiculo();
            grupoDeVeiculo0.Nome = "Uber";
            var grupoDeVeiculo1 = NovoGrupodeVeiculo();
            grupoDeVeiculo1.Nome = "Economico";
            var grupoDeVeiculo2 = NovoGrupodeVeiculo();
            grupoDeVeiculo2.Nome = "SUV";

            var repositorio = new RepositorioGrupoDeVeiculosEmBancoDeDados();
            repositorio.Inserir(grupoDeVeiculo0);
            repositorio.Inserir(grupoDeVeiculo1);
            repositorio.Inserir(grupoDeVeiculo2);

            //action
            var grupos = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, grupos.Count());
            
            Assert.AreEqual(grupoDeVeiculo0.Nome, grupos[0].Nome);
            Assert.AreEqual(grupoDeVeiculo1.Nome, grupos[1].Nome);
            Assert.AreEqual(grupoDeVeiculo2.Nome, grupos[2].Nome);
        }

    }
}
