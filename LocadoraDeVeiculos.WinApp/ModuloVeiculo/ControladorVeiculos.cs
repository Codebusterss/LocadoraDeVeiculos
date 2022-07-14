using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorFuncionario : ControladorBase
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;
        private TabelaVeiculoControl tabelaVeiculoControl;
        private readonly ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(IRepositorioVeiculo repositorioVeiculo, ServicoVeiculo servicoVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo();
            tela.veiculo = new Veiculo();
            tela.veiculo = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarVeiculos(GetVeiculo());
        }

        public override void Editar()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um Veiculo primeiro.",
                "Edição de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo();

            tela.veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();

        }

        private void CarregarVeiculos()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            Funcionario veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um Veiculo primeiro.",
                "Exclusão de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Veiculo?",
                "Exclusão de Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioVeiculo.Excluir(VeiculoSelecionado);
                CarregarVeiculos(GetVeiculo());
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolboxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            tabelaVeiculoControl = new TabelaVeiculoControl();

            CarregarVeiculos(GetVeiculo());

            return tabelaVeiculoControl;
        }

        private Veiculo GetVeiculo()
        {
            return Veiculo;
        }

        private void CarregarVeiculos(Veiculo veiculo)
        {
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();

            tabelaVeiculoControl.AtualizarRegistros(veiculos);
            TelaMenuPrincipal.Instancia.AtualizarRodape(mensagem: $"Visualizando {Veiculo.Count} Veiculo.");

        }

        private Funcionario ObtemVeiculoSelecionado()
        {
            var id = tabelaVeiculoControl.ObtemGrupoDeVeiculoSelecionado();

            return repositorioVeiculo.SelecionarPorId(id);
        }

    }
}
