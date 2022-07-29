using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TabelaLocacaoControl tabelaLocacaoControl;
        private readonly IServicoLocacao servicoLocacao;
        private readonly IServicoCliente servicoCliente;
        private readonly IServicoTaxa servicoTaxa;
        private readonly IServicoCondutor servicoCondutor;
        private readonly IServicoVeiculo servicoVeiculo;
        private readonly IServicoPlanoDeCobranca servicoPlano;
        private readonly IServicoFuncionario servicoFuncionario;


        Funcionario funcionarioLogado = new Funcionario();



        public ControladorLocacao(IServicoLocacao servicoLocacao, IServicoCliente servicoCliente, IServicoTaxa servicoTaxa, IServicoCondutor servicoCondutor, IServicoVeiculo servicoVeiculo, IServicoPlanoDeCobranca servicoPlano, IServicoFuncionario servicoFuncionario)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoCliente = servicoCliente;
            this.servicoTaxa = servicoTaxa;
            this.servicoCondutor = servicoCondutor;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoPlano = servicoPlano;
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            var clientes = servicoCliente.SelecionarTodos();
            var condutores = servicoCondutor.SelecionarTodos();
            var veiculos = servicoVeiculo.SelecionarTodos();
            var taxas = servicoTaxa.SelecionarTodos();
            var planos = servicoPlano.SelecionarTodos();
            var funcionarios = servicoFuncionario.SelecionarTodos();

            TelaCadastroLocacao tela = new TelaCadastroLocacao(clientes.Value, condutores.Value, veiculos.Value, taxas.Value, planos.Value, funcionarios.Value);
            tela.Locacao = new Locacao();
            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarLocacoes();
        }

        public override void Editar()
        {
            var id = tabelaLocacaoControl.ObtemLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro.",
                "Edição de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Edição de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultadoSelecao.Value;

            var clientes = servicoCliente.SelecionarTodos();
            var condutores = servicoCondutor.SelecionarTodos();
            var veiculos = servicoVeiculo.SelecionarTodos();
            var taxas = servicoTaxa.SelecionarTodos();
            var planos = servicoPlano.SelecionarTodos();
            var funcionarios = servicoFuncionario.SelecionarTodos();


            TelaCadastroLocacao tela = new TelaCadastroLocacao(clientes.Value, condutores.Value, veiculos.Value, taxas.Value, planos.Value, funcionarios.Value);

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacoes();

        }

        public override void Excluir()
        {
            var id = tabelaLocacaoControl.ObtemLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro.",
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?", "Exclusão de Locações",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(grupoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            tabelaLocacaoControl = new TabelaLocacaoControl();

            CarregarLocacoes();

            return tabelaLocacaoControl;
        }

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> Locacaos = resultado.Value;
                tabelaLocacaoControl.AtualizarRegistros(Locacaos);
                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {Locacaos.Count} locações.");
            }
            else if (resultado.IsFailed)
            {

                MessageBox.Show(resultado.Errors[0].Message, "Tela de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
