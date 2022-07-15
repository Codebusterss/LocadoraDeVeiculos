using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.Testes.Compartilhado;



using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaEmBancoDeDadosTest : BaseIntegrationTest
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;
        private RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlano;
        private PlanoDeCobranca plano;
        private GrupoDeVeiculo grupo;

        public RepositorioPlanoDeCobrancaEmBancoDeDadosTest():base()
        {
            plano = GerarPlano();
            grupo = GerarGrupo();
            plano.GrupoDeVeiculos = grupo;
            repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
            repositorioPlano = new RepositorioPlanoDeCobrancaEmBancoDeDados();
        }

        private GrupoDeVeiculo GerarGrupo()
        {
            GrupoDeVeiculo grupo = new GrupoDeVeiculo();
            grupo.Nome = "Teto Solar";

            return grupo;
        }

        private PlanoDeCobranca GerarPlano()
        {
            PlanoDeCobranca plano = new PlanoDeCobranca();

            plano.DiarioValorDia = 1;
            plano.DiarioValorKM = 1;
            plano.LivreValorDia = 1;
            plano.ControladoValorDia = 1;
            plano.ControladoLimiteKM = 1;
            plano.ControladoValorKM = 1;

            return plano;
        }

        [TestMethod]
        public void Deve_inserir_um_plano()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioPlano.Inserir(plano);

            //action
            var planoEncontrado = repositorioPlano.SelecionarPorId(plano.ID);

            //assert
            planoEncontrado.Should().NotBeNull();
            planoEncontrado.Should().Be(plano);
        }

        [TestMethod]
        public void Deve_editar_informacoes_plano()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioPlano.Inserir(plano);

            //action 
            plano.GrupoDeVeiculos = grupo;
            plano.DiarioValorDia = 10;
            plano.DiarioValorKM = 10;
            plano.LivreValorDia = 10;
            plano.ControladoValorDia = 10;
            plano.ControladoLimiteKM = 10;
            plano.ControladoValorKM = 10;

            repositorioPlano.Editar(plano);

            //assert
            var planoEncontrado = repositorioPlano.SelecionarPorId(plano.ID);

            planoEncontrado.Should().NotBeNull();
            planoEncontrado.Should().Be(plano);
        }

        [TestMethod]
        public void Deve_excluir_plano()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioPlano.Inserir(plano);

            //action           
            repositorioPlano.Excluir(plano);

            //assert
            repositorioPlano.SelecionarPorId(plano.ID)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_plano()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            repositorioPlano.Inserir(plano);

            //action
            var planoEncontrado = repositorioPlano.SelecionarPorId(plano.ID);

            //assert
            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(plano, planoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_planos()
        {
            //arrange
            repositorioGrupo.Inserir(grupo);
            GrupoDeVeiculo grupo2 = GerarGrupo();
            repositorioGrupo.Inserir(grupo2);
            var p0 = new PlanoDeCobranca(grupo, 1, 1, 1, 1, 1, 1);
            var p1 = new PlanoDeCobranca(grupo2, 2, 2, 2, 2, 2, 2);
            repositorioPlano.Inserir(p0);
            repositorioPlano.Inserir(p1);


            //action
            var planos = repositorioPlano.SelecionarTodos();

            //assert
            Assert.AreEqual(2, planos.Count);

            Assert.AreEqual(p0.DiarioValorDia, planos[0].DiarioValorDia);
            Assert.AreEqual(p1.DiarioValorDia, planos[1].DiarioValorDia);
        }
    }
}