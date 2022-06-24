using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmBancoDeDadosTest
    {
        private Taxa taxas;
        private RepositorioTaxaEmBancoDeDados repositorioTaxa;

        public RepositorioTaxaEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TAXA; DBCC CHECKIDENT (TAXA, RESEED, 0)");
            
            taxas = gerarTaxa();
            repositorioTaxa = new RepositorioTaxaEmBancoDeDados();
           
        }
        public Taxa gerarTaxa()
        {
            Taxa taxas = new Taxa();
            taxas.Valor = 240;
            taxas.Descricao = "Cadeirinha de bebê, gps...";
            taxas.Tipo = "CNPJ";
            return taxas;
        }
        [TestMethod]
        public void Deve_inserir_novo_taxa()
        {
            //action
            
            repositorioTaxa.Inserir(taxas);

            //assert
            var taxaEncontrada = repositorioTaxa.SelecionarPorID(taxas.ID);

            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(taxas, taxaEncontrada);
        }
        [TestMethod]
        public void Deve_editar_informacoes_taxa()
        {
            //arrange                      
            
            repositorioTaxa.Inserir(taxas);

            //action
            taxas.Tipo = "CPF";
            taxas.Descricao = "Carro com 6 lugares";
            taxas.Valor = 34; ;
            repositorioTaxa.Editar(taxas);

            //assert
            var taxaEncontrada = repositorioTaxa.SelecionarPorID(taxas.ID);
             
            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(taxas, taxaEncontrada);
        }
        [TestMethod]
        public void Deve_excluir_medicamento()
        {
            //arrange           
            repositorioTaxa.Inserir(taxas);

            //action           
            repositorioTaxa.Excluir(taxas);

            //assert
            var taxaEncontrada = repositorioTaxa.SelecionarPorID(taxas.ID);
            Assert.IsNull(taxaEncontrada);
        }
    
    }
}
