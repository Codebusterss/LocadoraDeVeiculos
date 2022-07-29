using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCliente;
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

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutor : Form
    {
        private Cliente clienteSelecionado;
        private Condutor condutor;
        ValidadorRegex validador = new ValidadorRegex();
        private RepositorioClienteEmBancoDeDados repositorioClienteEmBanco = new RepositorioClienteEmBancoDeDados();
        public TelaCadastroCondutor(List<Cliente> clientes)
        {
            InitializeComponent();
            CarregarCondutor(clientes);

        }

        public Func<Condutor, Result<Condutor>> GravarRegistro { get; set; }

        public Condutor Condutor
        {
            get
            {
                return condutor;
            }
            set
            {
                condutor = value;
                textBoxCondID.Text = condutor.ID.ToString();
                textBoxCondEmail.Text = condutor.Email;
                textBoxCondEndereco.Text = condutor.Endereco;
                textBoxCondNome.Text = condutor.Nome;
                textBoxTelefone.Text = condutor.Telefone;
                comboBoxCondCliente.SelectedItem = condutor.Cliente;
                checkBoxClienteCondutor.Checked = condutor.CondutorCliente;
                textBoxCondCPF.Text = condutor.CPF;
                textBoxCondCNH.Text = condutor.CNH;
                if (condutor.ValidadeCNH.Equals(DateTime.MinValue))
                {
                    dateTimePickerCondValidade.Value = DateTime.Now;
                }
                else
                {
                    dateTimePickerCondValidade.Value = condutor.ValidadeCNH;
                }

            }
        }

        #region Botoes

        private void button1_Click(object sender, EventArgs e)
        {

            condutor.Cliente = comboBoxCondCliente.SelectedItem as Cliente;

            if (comboBoxCondCliente.SelectedIndex == -1)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Selecione um cliente primeiro");
                DialogResult = DialogResult.None;

                return;
            }



            condutor.Nome = textBoxCondNome.Text;
            condutor.Email = textBoxCondEmail.Text;
            condutor.Telefone = textBoxTelefone.Text;
            condutor.Endereco = textBoxCondEndereco.Text;
            condutor.CPF = textBoxCondCPF.Text;
            condutor.CNH = textBoxCondCNH.Text;
            condutor.ValidadeCNH = DateTime.Parse(dateTimePickerCondValidade.Text);


            var resultadoValidacao = GravarRegistro(condutor);


            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                      "Cadastro de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }



        }

        private void checkBoxClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {

            List<Cliente> clientes = repositorioClienteEmBanco.SelecionarTodos();

            string arrumar = "";


            if (comboBoxCondCliente.Text == "")
            {
                MessageBox.Show("Selecione um cliente primeiro.",
                  "Cadastro de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (Cliente cliente in clientes)
                {
                    if (comboBoxCondCliente.Text == cliente.Nome)
                    {
                        clienteSelecionado = cliente;
                    }
                }
            }

            if (clienteSelecionado.PessoaFisica == false)
            {
                MessageBox.Show("Condutor não pode ser uma empresa.",
                "Cadastro de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (Cliente cliente in clientes)
                {
                    if (comboBoxCondCliente.Text == cliente.Nome)
                    {
                        textBoxCondNome.Text = cliente.Nome;
                        textBoxCondEmail.Text = cliente.Email;
                        arrumar = cliente.Telefone.Replace("(", "").Replace(")", "").Replace("-", "");
                        textBoxTelefone.Text = arrumar;
                        textBoxCondEndereco.Text = cliente.Endereco;
                        arrumar = cliente.CPF.Replace(".", "").Replace("-", "");
                        textBoxCondCPF.Text = arrumar;
                    }
                }
            }
        }

        private void comboBoxCondCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxClienteCondutor.Enabled = true;
        }

        #endregion

        #region Rodape

        private void TelaCadastroCondutor_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCondutor_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion

        #region Metodos

        private void CarregarCondutor(List<Cliente> clientes)
        {
            comboBoxCondCliente.Items.Clear();

            foreach (var cliente in clientes)
            {
                comboBoxCondCliente.Items.Add(cliente);
            }
        }

        #endregion

    }
}
