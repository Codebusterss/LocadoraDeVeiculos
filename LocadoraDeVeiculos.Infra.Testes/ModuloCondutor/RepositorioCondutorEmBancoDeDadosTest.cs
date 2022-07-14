using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.Testes.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDeDadosTest : BaseIntegrationTest
    {
        private Condutor condutor;
        private RepositorioCondutorEmBancoDeDados repositorioCondutorEmBanco;
        private Cliente cliente;
        private RepositorioClienteEmBancoDeDados repositorioClienteEmBanco;
        private DateTime data = new DateTime(2022, 01, 01, 12, 00, 00);


        public RepositorioCondutorEmBancoDeDadosTest()
        {
          
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
            condutor.ValidadeCNH = data;
            condutor.Endereco = "Rua joao costa";
            condutor.Email = "gigi@gmai.com";
            condutor.Telefone = "(43)98683-1923";

            return condutor;
        }
        public Cliente gerarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Pietro";
            cliente.Email = "Pietro@gmail.com";
            cliente.CNPJ = "";
            cliente.Telefone = "(43)97683-1923";
            cliente.Endereco = "Lages";
            cliente.CNH = "4563-96785";
            cliente.CPF = "345.768.598-09";

            return cliente;
        }
        [TestMethod]
        public void Deve_inserir_novo_condutor()
        {

            //action
            repositorioClienteEmBanco.Inserir(cliente);
            repositorioCondutorEmBanco.Inserir(condutor);
            

            //assert
            var condutorEncontrado = repositorioCondutorEmBanco.SelecionarPorId(condutor.ID);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }


        [TestMethod]
        public void Deve_editar_condutores()
        {
            //arrange
            repositorioClienteEmBanco.Inserir(cliente);
            repositorioCondutorEmBanco.Inserir(condutor);

            //action 
            condutor.Cliente = cliente;
            condutor.Nome = "julia";
            condutor.Email = "julia@gmail.com";
            condutor.Endereco = "Lages";
            condutor.CPF = "567.959.123-49";
            condutor.ValidadeCNH = data;
            condutor.CNH = "97655643291";
            condutor.Telefone = "(51) 12345-1234";

            repositorioCondutorEmBanco.Editar(condutor);
            

            //assert
            var condutorEncontrado = repositorioCondutorEmBanco.SelecionarPorId(condutor.ID);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);

        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange
            repositorioClienteEmBanco.Inserir(cliente);
            repositorioCondutorEmBanco.Inserir(condutor);
           
            //action
            repositorioCondutorEmBanco.Excluir(condutor);

            //assert
            var condutorEncontrado = repositorioCondutorEmBanco.SelecionarPorId(condutor.ID);
            Assert.IsNull(condutorEncontrado);
        }
        [TestMethod]
        public void Deve_selecionar_apenas_um_condutor() 
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
   

    }
}
