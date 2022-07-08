using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private readonly IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoDeVeiculos;
        private TabelaPlanoControl tabelaPlanoControl;
        private readonly ServicoPlanoDeCobranca servicoPlano;

        public ControladorPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, ServicoPlanoDeCobranca servicoPlano, RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoDeVeiculos)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.servicoPlano = servicoPlano;
            this.repositorioGrupoDeVeiculos = repositorioGrupoDeVeiculos;
        }

        public override void Inserir()
        {
            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();

            TelaCadastroPlano tela = new TelaCadastroPlano(grupos);
            tela.Plano = new PlanoDeCobranca();
            tela.GravarRegistro = servicoPlano.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarPlanos();
        }

        public override void Editar()
        {
            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();

            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro.",
                "Edição de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPlano tela = new TelaCadastroPlano(grupos);

            tela.Plano = planoSelecionado;

            tela.GravarRegistro = servicoPlano.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanos();

        }

        public override void Excluir()
        {
            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro.",
                "Exclusão de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o plano?",
                "Exclusão de Planos de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPlanoDeCobranca.Excluir(planoSelecionado);
                CarregarPlanos();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolboxPlanoDeCobranca();
        }

        public override UserControl ObtemListagem()
        {
            tabelaPlanoControl = new TabelaPlanoControl();

            CarregarPlanos();

            return tabelaPlanoControl;
        }

        private void CarregarPlanos()
        {
            List<PlanoDeCobranca> planos = repositorioPlanoDeCobranca.SelecionarTodos();

            tabelaPlanoControl.AtualizarRegistros(planos);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {planos.Count} Planos de Cobrança.");

        }

        private PlanoDeCobranca ObtemPlanoSelecionado()
        {
            var ID = tabelaPlanoControl.ObtemPlanoSelecionado();

            return repositorioPlanoDeCobranca.SelecionarPorId(ID);
        }

    }
}