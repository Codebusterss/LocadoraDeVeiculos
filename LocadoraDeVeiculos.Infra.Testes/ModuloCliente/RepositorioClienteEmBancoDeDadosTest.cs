using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentAssertions;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDeDadosTest
    {
        private RepositorioClienteEmBancoDeDados repositorio;

        public RepositorioClienteEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM CLIENTE; DBCC CHECKIDENT (CLIENTE, RESEED, 0)");

            repositorio = new RepositorioClienteEmBancoDeDados();
        }

        private Cliente NovoCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Luan";
            cliente.CNH = "123.123.123-123";
            cliente.CPF = "123.123.123-12";
            cliente.CNPJ = "";
            cliente.Email = "luan@gmail.com";
            cliente.Endereco = "Rua Amorim";
            cliente.Telefone = "(12)91233-1233";
            cliente.PessoaFisica = true;
            return cliente;
        }

        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            //arrange
            var cliente = NovoCliente();

            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.ID);

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }


        [TestMethod]
        public void Deve_editar_cliente()
        {
            //arrange
            var cliente = NovoCliente();
            repositorio.Inserir(cliente);
            cliente.Nome = "Roberto";

            //action
            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.ID);

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange
            var cliente = NovoCliente();
            repositorio.Inserir(cliente);

            //action
            repositorio.Excluir(cliente);

            //assert
            repositorio.SelecionarPorId(cliente.ID).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_cliente()
        {
            //arrange
            var cliente = NovoCliente();
            repositorio.Inserir(cliente);

            //action
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.ID);

            //assert
            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            //arrange
            var cliente1 = NovoCliente();
            cliente1.Nome = "Jose";
            cliente1.CPF = "123.123.123-12";

            var cliente2 = NovoCliente();
            cliente2.Nome = "Luan";
            cliente2.CPF = "321.321.321-32";

            var cliente3 = NovoCliente();
            cliente3.Nome = "Roberto";
            cliente3.CPF = "123.456.789-12";

            var repositorio = new RepositorioClienteEmBancoDeDados();
            repositorio.Inserir(cliente1);
            repositorio.Inserir(cliente2);
            repositorio.Inserir(cliente3);

            //action
            var clientes = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, clientes.Count());

            Assert.AreEqual(cliente1.Nome, clientes[0].Nome);
            Assert.AreEqual(cliente2.Nome, clientes[1].Nome);
            Assert.AreEqual(cliente3.Nome, clientes[2].Nome);
        }

    }
}
