using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;


namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo
{
    public class ControladorGrupoDeVeiculo : ControladorBase
    {
        private TabelaGrupoDeVeiculoControl tabelaGrupoDeVeiculoControl;
        private readonly ServicoGrupoDeVeiculo servicoGrupoDeVeiculo;

        private readonly RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaEmBancoDeDados();

        public ControladorGrupoDeVeiculo(ServicoGrupoDeVeiculo servicoGrupoDeVeiculo)
        {
            this.servicoGrupoDeVeiculo = servicoGrupoDeVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoDeVeiculo tela = new TelaCadastroGrupoDeVeiculo();
            tela.GrupoDeVeiculo = new GrupoDeVeiculo();
            tela.GravarRegistro = servicoGrupoDeVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Editar()
        {
            var id = tabelaGrupoDeVeiculoControl.ObtemGrupoDeVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro.",
                    "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoDeVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultado.Value;

            var tela = new TelaCadastroGrupoDeVeiculo();

            tela.GrupoDeVeiculo = grupoSelecionado.Clone();

            tela.GravarRegistro = servicoGrupoDeVeiculo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarGrupos();

        }

        public override void Excluir()
        {
            var id = tabelaGrupoDeVeiculoControl.ObtemGrupoDeVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro.",
                    "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoGrupoDeVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o grupo de veículos?", "Exclusão de Grupo de Veículos",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoDeVeiculo.Excluir(grupoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var resultado = servicoGrupoDeVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoDeVeiculo> grupoDeVeiculos = resultado.Value;
                tabelaGrupoDeVeiculoControl.AtualizarRegistros(grupoDeVeiculos);
                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {grupoDeVeiculos.Count} grupos de veículos.");
            }
            else if (resultado.IsFailed)
            {

                MessageBox.Show(resultado.Errors[0].Message, "Tela de Grupos de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
