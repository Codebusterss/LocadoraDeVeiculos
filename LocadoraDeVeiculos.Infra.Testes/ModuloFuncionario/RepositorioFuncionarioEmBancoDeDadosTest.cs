using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.Compartilhado;
using FluentAssertions;

namespace LocadoraDeVeiculos.Infra.Testes.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDeDadosTest
    {
        private RepositorioFuncionarioEmBancoDeDados repositorio;
        private DateTime data = new DateTime(2022, 01, 01, 12, 00, 00);

        public RepositorioFuncionarioEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM FUNCIONARIO; DBCC CHECKIDENT (FUNCIONARIO, RESEED, 0)");

            repositorio = new RepositorioFuncionarioEmBancoDeDados();
        }

        private Funcionario NovoFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Luan";
            funcionario.Login = "luan.c22";
            funcionario.Senha = "luan";
            funcionario.Salario = 1200;
            funcionario.Admin = true;
            funcionario.DataAdmissao = data;
            return funcionario;
        }

        [TestMethod]
        public void Deve_inserir_novo_funcionario()
        {
            //arrange
            var funcionario = NovoFuncionario();

            //action
            repositorio.Inserir(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.ID);

            funcionarioEncontrado.Should().NotBeNull();
            funcionarioEncontrado.Should().Be(funcionario);
        }


        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);
            funcionario.Nome = "Jean";

            //action
            repositorio.Editar(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.ID);

            funcionarioEncontrado.Should().NotBeNull();
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);

            //action
            repositorio.Excluir(funcionario);

            //assert
            repositorio.SelecionarPorId(funcionario.ID).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
            //arrange
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);

            //action
            var grupoEncontrado = repositorio.SelecionarPorId(funcionario.ID);

            //assert
            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            //arrange
            var funcionario0 = NovoFuncionario();
            funcionario0.Nome = "Jose";
            funcionario0.Login = "Jose1";

            var funcionario1 = NovoFuncionario();
            funcionario1.Nome = "Luan";
            funcionario1.Login = "Luan1";

            var funcionario2 = NovoFuncionario();
            funcionario2.Nome = "Roberto";
            funcionario2.Login = "Roberto1";

            var repositorio = new RepositorioFuncionarioEmBancoDeDados();
            repositorio.Inserir(funcionario0);
            repositorio.Inserir(funcionario1);
            repositorio.Inserir(funcionario2);

            //action
            var funcionarios = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, funcionarios.Count());

            Assert.AreEqual(funcionario0.Nome, funcionarios[0].Nome);
            Assert.AreEqual(funcionario1.Nome, funcionarios[1].Nome);
            Assert.AreEqual(funcionario2.Nome, funcionarios[2].Nome);
        }

    }
}
