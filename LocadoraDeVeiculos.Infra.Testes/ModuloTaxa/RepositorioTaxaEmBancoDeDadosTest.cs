using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmBancoDeDadosTest
    {
        private Taxa taxa;
        private RepositorioTaxaEmBancoDeDados repositorio;

        public RepositorioTaxaEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TAXA; DBCC CHECKIDENT (TAXA, RESEED, 0)");
            
            taxa = NovaTaxa();
            repositorio = new RepositorioTaxaEmBancoDeDados();
           
        }
        public Taxa NovaTaxa()
        {
            Taxa taxas = new Taxa();
            taxas.Valor = 240;
            taxas.Descricao = "Cadeirinha de bebê, gps...";
            taxas.Tipo = "Fixo";
            return taxas;
        }
        [TestMethod]
        public void Deve_inserir_nova_taxa()
        {
            //arrange
            var taxa = NovaTaxa();

            //action
            repositorio.Inserir(taxa);

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.ID);

            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_editar_taxa()
        {
            //arrange
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);
            taxa.Tipo = "Diaria";
            taxa.Descricao = "Frigobar";

            //action
            repositorio.Editar(taxa);

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(taxa.ID);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_excluir_grupo_de_veiculo()
        {
            //arrange
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);

            //action
            repositorio.Excluir(taxa);

            //assert
            repositorio.SelecionarPorId(taxa.ID).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_grupo()
        {
            //arrange
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);

            //action
            var grupoEncontrado = repositorio.SelecionarPorId(taxa.ID);

            //assert
            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupos()
        {
            //arrange
            var taxa0 = NovaTaxa();
            taxa0.Descricao = "Limpeza";
            var taxa1 = NovaTaxa();
            taxa1.Descricao = "Gasolina";
            var taxa2 = NovaTaxa();
            taxa2.Descricao = "Bluetooth";

            var repositorio = new RepositorioTaxaEmBancoDeDados();
            repositorio.Inserir(taxa0);
            repositorio.Inserir(taxa1);
            repositorio.Inserir(taxa2);

            //action
            var taxas = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, taxas.Count());

            Assert.AreEqual(taxa0.Descricao, taxas[0].Descricao);
            Assert.AreEqual(taxa1.Descricao, taxas[1].Descricao);
            Assert.AreEqual(taxa2.Descricao, taxas[2].Descricao);
        }

    }
}
