using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDeDadosTest
    {
        private Condutor condutor;
        private RepositorioCondutorEmBancoDeDados repositorioCondutorEmBanco;
        private Cliente cliente;
        private RepositorioClienteEmBancoDeDados repositorioClienteEmBanco;

        public RepositorioCondutorEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM CONDUTOR; DBCC CHECKIDENT (CONDUTOR, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM CLIENTE; DBCC CHECKIDENT (CLIENTE, RESEED, 0)");

            condutor = gerarCondutor();
            cliente = gerarCliente();
            condutor.Cliente = cliente;
            repositorioCondutorEmBanco = new RepositorioCondutorEmBancoDeDados();
            repositorioClienteEmBanco = new RepositorioClienteEmBancoDeDados();
        }
        public Condutor gerarCondutor()
        {
            Condutor condutor = new Condutor();
            condutor.Nome = "giovana";
            condutor.CNH = "345-93784";
            condutor.CPF = "089.645.867-34";
            condutor.ValidadeCNH = new DateTime(2022, 01, 09, 09, 15, 00);
            condutor.Endereco = "Rua joao costa";
            condutor.Email = "gigi@gmai.com";

            return condutor;
        }
        public Cliente gerarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Pietro";
            cliente.Email = "Pietro@gmail.com";
            cliente.Telefone = "4002-8922";
            cliente.Endereco = "Lages";
            cliente.CNH = "4563-96785";
            cliente.CPF = "345.768.598-09";

            return cliente;
        }
        [TestMethod]
        public void Deve_inserir_novo_condutor()
        {
            //arrange
            repositorioClienteEmBanco.Inserir(cliente);
            repositorioCondutorEmBanco.Inserir(condutor);

            //action
            var condutorEncontrado = repositorioCondutorEmBanco.SelecionarPorId(condutor.ID);

            //assert

            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(condutor, condutorEncontrado);
        }


        [TestMethod]
        public void Deve_editar_condutores()
        {
            //arrange
            repositorioCondutorEmBanco.Inserir(condutor);
            repositorioClienteEmBanco.Inserir(cliente);
            //action
            condutor.Nome = "rafa";
            condutor.Email = "lalalala@gmail.com";
            repositorioCondutorEmBanco.Editar(condutor);

            //assert
            var condutorEncontrado = repositorioCondutorEmBanco.SelecionarPorId(condutor.ID);
            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(condutor, condutorEncontrado);

        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange
            repositorioCondutorEmBanco.Inserir(condutor);
            repositorioClienteEmBanco.Inserir(cliente);

            //action
            repositorioCondutorEmBanco.Excluir(condutor);

            //assert
            var condutorEncontrado = repositorioCondutorEmBanco.SelecionarPorId(condutor.ID);
            Assert.IsNotNull(condutorEncontrado);
        }
        [TestMethod]
        public void Deve_selecionar_apenas_um_condutor() 
        {
            //arrange
            repositorioCondutorEmBanco.Inserir(condutor);
            repositorioClienteEmBanco.Inserir(cliente);

            //action
            var condutorEncontrado = repositorioCondutorEmBanco.SelecionarPorId(condutor.ID);

            //assert
            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(condutor, condutorEncontrado);
        }
        
    }
}
