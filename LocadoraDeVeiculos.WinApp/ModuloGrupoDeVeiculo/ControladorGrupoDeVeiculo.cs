using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo
{
    public class ControladorGrupoDeVeiculo : ControladorBase
    {
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoDeVeiculo;
        private TabelaGrupoDeVeiculoControl tabelaGrupoDeVeiculoControl;

        public ControladorGrupoDeVeiculo(RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoDeVeiculo)
        {
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoDeVeiculo tela = new TelaCadastroGrupoDeVeiculo();
            tela.GrupoDeVeiculo = new GrupoDeVeiculo();
            tela.GravarRegistro = repositorioGrupoDeVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Editar()
        {
            GrupoDeVeiculo grupoSelecionado = ObtemGrupoSelecionado();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro",
                "Edição de Grupos de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoDeVeiculo tela = new TelaCadastroGrupoDeVeiculo();

            tela.GrupoDeVeiculo = grupoSelecionado;

            tela.GravarRegistro = repositorioGrupoDeVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupos();

        }

        public override void Excluir()
        {
            GrupoDeVeiculo grupoSelecionado = ObtemGrupoSelecionado();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro",
                "Exclusão de Grupos de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o grupo de veículos?",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupoDeVeiculo.Excluir(grupoSelecionado);
                CarregarGrupos();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoDeVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            tabelaGrupoDeVeiculoControl = new TabelaGrupoDeVeiculoControl();

            CarregarGrupos();

            return tabelaGrupoDeVeiculoControl;
        }

        private void CarregarGrupos()
        {
            List<GrupoDeVeiculo> disciplinas = repositorioGrupoDeVeiculo.SelecionarTodos();

            tabelaGrupoDeVeiculoControl.AtualizarRegistros(disciplinas);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando Grupos de Veículos");

        }

        private GrupoDeVeiculo ObtemGrupoSelecionado()
        {
            var id = tabelaGrupoDeVeiculoControl.ObtemGrupoDeVeiculoSelecionado();

            return repositorioGrupoDeVeiculo.SelecionarPorId(id);
        }

    }
}
