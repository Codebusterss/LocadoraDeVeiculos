using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroCliente : Form
    {
        private Cliente cliente;
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroCliente()
        {
            InitializeComponent();
        }
        public Func<Cliente, Result<Cliente>> GravarRegistro { get; set; }
        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                txtBoxID.Text = cliente.ID.ToString();
                txtBoxEmail.Text = cliente.Email;
                txtBoxEndereco.Text = cliente.Endereco;
                txtBoxNome.Text = cliente.Nome;
                txtBoxTelefone.Text = cliente.Telefone;

                ChecarCPFCNPJ();
            }
        }

        #region Botoes

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            cliente.Nome = txtBoxNome.Text;
            cliente.Email = txtBoxEmail.Text;
            cliente.Telefone = txtBoxTelefone.Text;
            cliente.Endereco = txtBoxEndereco.Text;
            if (rdBtnCPF.Checked == true)
            {
                cliente.PessoaFisica = true;
                cliente.CPF = txtBoxCPFCNPJ.Text;
                cliente.CNPJ = "";
            }
            else
            {
                cliente.PessoaFisica = false;
                cliente.CPF = "";
                cliente.CNPJ = txtBoxCPFCNPJ.Text;
            }

            var resultadoValidacao = GravarRegistro(cliente);


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

        private void rdBtnCPF_CheckedChanged(object sender, EventArgs e)
        {

            txtBoxCPFCNPJ.Mask = "000.000.000-00";
        }

        private void rdBtnCNPJ_CheckedChanged(object sender, EventArgs e)
        {

            txtBoxCPFCNPJ.Mask = "00.000.000/0000-00";
        }

        #endregion

        #region Rodape

        private void TelaCadastroCliente_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion

        #region Metodos

        private void ChecarCPFCNPJ()
        {
            if (cliente.CPF == "" && cliente.CNPJ == "")
            {
                txtBoxCPFCNPJ.Text = "";
            }
            else if (cliente.CPF != "")
            {
                txtBoxCPFCNPJ.Text = cliente.CPF;
                rdBtnCPF.Checked = true;
            }
            else
            {
                txtBoxCPFCNPJ.Text = cliente.CNPJ;
                rdBtnCNPJ.Checked = true;
            }
        }

        #endregion

    }
}
