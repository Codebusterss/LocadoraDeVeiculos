using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculos : ControladorBase
    {
        private readonly IServicoGrupoDeVeiculo servicoGrupo;
        private TabelaVeiculoControl tabelaVeiculoControl;
        private readonly IServicoVeiculo servicoVeiculo;

        public ControladorVeiculos(IServicoVeiculo servicoVeiculo, IServicoGrupoDeVeiculo servicoGrupo)
        {
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupo = servicoGrupo;
        }

        public override void Inserir()
        {
            var grupos = servicoGrupo.SelecionarTodos();

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(grupos.Value);
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarPlanos();
        }

        public override void Editar()
        {
            var grupos = servicoGrupo.SelecionarTodos();
            var id = tabelaVeiculoControl.ObtemVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro.",
                    "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultado.Value;

            var tela = new TelaCadastroVeiculo(grupos.Value);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanos();

        }

        public override void Excluir()
        {
            var id = tabelaVeiculoControl.ObtemVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro.",
                    "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o veículo?", "Exclusão de Veículo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            tabelaVeiculoControl = new TabelaVeiculoControl();

            CarregarPlanos();

            return tabelaVeiculoControl;
        }

        private void CarregarPlanos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;
                tabelaVeiculoControl.AtualizarRegistros(veiculos);
                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veículos.");
            }
            else if (resultado.IsFailed)
            {

                MessageBox.Show(resultado.Errors[0].Message, "Tela de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
