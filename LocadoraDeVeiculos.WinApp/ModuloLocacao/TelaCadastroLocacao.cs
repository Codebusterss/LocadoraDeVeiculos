using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacao : Form
    {

        private Locacao locacao;
        List<PlanoDeCobranca> planos = new List<PlanoDeCobranca>();
        List<Taxa> taxas = new List<Taxa>();
        Funcionario funcionarioLogado = new Funcionario();        
        public TelaCadastroLocacao(List<Cliente> clientes, List<Condutor> condutores, List<Veiculo> veiculos, List<Taxa> taxas, List<PlanoDeCobranca> planos, List<Funcionario> funcionarios)
        {
            InitializeComponent();
            CarregarClientes(clientes);
            CarregarCondutores(condutores);
            CarregarVeiculos(veiculos);
            CarregarTaxas(taxas);
            CarregarFuncionarios(funcionarios);
            CarregarPlanos();
            this.planos = planos;
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                locacao = value;
                cbBoxFuncionarios.SelectedItem = locacao.Funcionario;
                cbBoxCliente.SelectedItem = locacao.Cliente;
                cbBoxCondutor.SelectedItem = locacao.Condutor;
                cbBoxVeiculo.SelectedItem = locacao.Veiculo;
                if(dateTimeDataLocacao.Value < DateTime.MinValue && dateTimeDataLocacao.Value > DateTime.MaxValue)
                {
                    dateTimeDataLocacao.Value = locacao.DataLocacao;
                    dateTimeDataDevolucao.Value = locacao.DataDevolucao;
                }          
                txtBoxValorTotal.Text = locacao.Valor.ToString();
                ChecarSeguro();
            }
        }

        #region Metodos

        private void CarregarFuncionarios(List<Funcionario> funcionarios)
        {
            cbBoxFuncionarios.Items.Clear();

            foreach (var item in funcionarios)
            {
                cbBoxFuncionarios.Items.Add(item);
            }
        }

        private void CarregarTaxas(List<Taxa> taxas)
        {
            cbBoxTaxas.Items.Clear();

            foreach (var item in taxas)
            {
                cbBoxTaxas.Items.Add(item);
            }
        }

        private void CarregarVeiculos(List<Veiculo> veiculos)
        {
            cbBoxVeiculo.Items.Clear();

            foreach (var item in veiculos)
            {
                cbBoxVeiculo.Items.Add(item);
            }
        }

        private void CarregarCondutores(List<Condutor> condutores)
        {
            cbBoxCondutor.Items.Clear();

            foreach (var item in condutores)
            {
                cbBoxCondutor.Items.Add(item);
            }
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cbBoxCliente.Items.Clear();

            foreach (var item in clientes)
            {
                cbBoxCliente.Items.Add(item);
            }
        }

        private void CarregarPlanos()
        {
            cbBoxPlanoCobranca.Items.Clear();

            cbBoxPlanoCobranca.Items.Add("Diário - Plano Diário");
            cbBoxPlanoCobranca.Items.Add("Diário - Plano Por KM");
            cbBoxPlanoCobranca.Items.Add("Livre - Plano Diário");
            cbBoxPlanoCobranca.Items.Add("Controlado - Plano Por KM");
            cbBoxPlanoCobranca.Items.Add("Controlado - Limite de KM");
            cbBoxPlanoCobranca.Items.Add("Controlado - Plano Diário");
        }

        private void ChecarSeguro()
        {
            if (locacao.Seguro == "Individual")
            {
                rdBtnIndividual.Checked = true;
            }

            if (locacao.Seguro == "Terceiros")
            {
                rdBtnTerceiros.Checked = true;
            }

            if (locacao.Seguro == "Total")
            {
                rdBtnTotal.Checked = true;
            }
        }

        private void RegistrarSeguro()
        {
            if (rdBtnIndividual.Checked == true)
            {
                locacao.Seguro = "Individual";
            }

            if (rdBtnTerceiros.Checked == true)
            {
                locacao.Seguro = "Terceiros";
            }

            if (rdBtnTotal.Checked == true)
            {
                locacao.Seguro = "Total";
            }
        }

        private void VerificarCliente()
        {
            Cliente clienteSelecionado = (Cliente)cbBoxCliente.SelectedItem;
            Condutor condutorSelecionado = (Condutor)cbBoxCondutor.SelectedItem;

            if (condutorSelecionado.Cliente.ID != clienteSelecionado.ID)
            {
                MessageBox.Show("Condutor está relacionado ao cliente errado!",
                      "Cadastro de Locações", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private double PegarValorPlano(Veiculo veiculo)
        {
            double valor = 0;
            double valorMultiplica = 0;
            DateTime locacaoDia = Convert.ToDateTime(dateTimeDataLocacao.Value);
            DateTime devolucaoDia = Convert.ToDateTime(dateTimeDataDevolucao.Value);
            double qtdDias = (devolucaoDia - locacaoDia).TotalDays;

            foreach (PlanoDeCobranca plano in planos)
            {
                if(plano.GrupoDeVeiculos.ID == veiculo.GrupoDeVeiculo.ID)
                {
                    locacao.Plano = null;
                    locacao.Plano = plano;
                }
            }

            if(cbBoxPlanoCobranca.Text == "Diário - Plano Diário")
            {
                valor = locacao.Plano.DiarioValorDia * qtdDias;
            }
            else if(cbBoxPlanoCobranca.Text == "Diário - Plano Por KM")
            {
                valorMultiplica = Convert.ToDouble(txtBoxKMveiculo.Text);
                valor = locacao.Plano.DiarioValorKM * valorMultiplica;
            }
            else if (cbBoxPlanoCobranca.Text == "Livre - Plano Diário")
            {
                valor = locacao.Plano.LivreValorDia * qtdDias;
            }
            else if (cbBoxPlanoCobranca.Text == "Controlado - Plano Por KM")
            {
                valorMultiplica = Convert.ToDouble(txtBoxKMveiculo.Text);
                valor = locacao.Plano.ControladoValorKM * valorMultiplica;
            }
            else if (cbBoxPlanoCobranca.Text == "Controlado - Limite de KM")
            {
                valorMultiplica = Convert.ToDouble(txtBoxKMveiculo.Text);
                valor = locacao.Plano.ControladoLimiteKM * valorMultiplica;
            }
            else if (cbBoxPlanoCobranca.Text == "Controlado - Plano Diário")
            {
                valor = locacao.Plano.ControladoValorDia * qtdDias;
            }

            return valor;
        }

        #endregion

        #region Botoes

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double valor = 0;
            double valorTaxa = 0;

            if (cbBoxPlanoCobranca.Text == "")
            {
                MessageBox.Show("Selecione um plano primeiro!",
                      "Cadastro de Locações", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else if (cbBoxVeiculo.Text == "")
            {
                MessageBox.Show("Selecione um veículo primeiro!",
                      "Cadastro de Locações", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            foreach (var item in taxas)
            {
                valorTaxa = +item.Valor;
            }
            
            Veiculo veiculoSelecionado = (Veiculo)cbBoxVeiculo.SelectedItem;
            valor = PegarValorPlano(veiculoSelecionado) + valorTaxa;
            txtBoxValorTotal.Text = "R$ " + Math.Round(valor).ToString();
            locacao.Valor = Math.Round(valor);
        }

        private void cbBoxPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxPlanoCobranca.Text == "Diário - Plano Por KM")
            {
                txtBoxKMveiculo.Enabled = true;
            }
            if (cbBoxPlanoCobranca.Text == "Controlado - Plano Por KM")
            {
                txtBoxKMveiculo.Enabled = true;
            }
            if (cbBoxPlanoCobranca.Text == "Controlado - Limite de KM")
            {
                txtBoxKMveiculo.Enabled = true;
            }
        }

        private void btnAddTaxa_Click(object sender, EventArgs e)
        {
            lstBoxTaxa.Items.Add(cbBoxTaxas.SelectedItem);
            taxas.Add((Taxa)cbBoxTaxas.SelectedItem);
            cbBoxTaxas.SelectedIndex = -1;
        }

        private void dateTimeDataLocacao_ValueChanged(object sender, EventArgs e)
        {
            DateTime dataLocacao = Convert.ToDateTime(dateTimeDataLocacao.Value);
            DateTime dataMinima = dataLocacao.AddDays(-1);

            if (dataLocacao < dataMinima)
            {
                MessageBox.Show("Data de Locação não pode ser menor que a data atual!",
                      "Cadastro de Locações", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            locacao.Funcionario = (Funcionario)cbBoxFuncionarios.SelectedItem;
            locacao.Veiculo = (Veiculo)cbBoxVeiculo.SelectedItem;
            VerificarCliente();
            locacao.Cliente = (Cliente)cbBoxCliente.SelectedItem;  
            locacao.Condutor = (Condutor)cbBoxCondutor.SelectedItem;
            locacao.DataLocacao = dateTimeDataLocacao.Value;
            locacao.DataDevolucao = dateTimeDataDevolucao.Value;
            locacao.StatusLocacao = "Ativa";
            locacao.Taxas = taxas;
            RegistrarSeguro();

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Cadastro de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void cbBoxTaxas_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTaxa.Enabled = true;
        }

        #endregion

        #region Rodape

        private void TelaCadastroLocacao_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroLocacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion

    }
}
