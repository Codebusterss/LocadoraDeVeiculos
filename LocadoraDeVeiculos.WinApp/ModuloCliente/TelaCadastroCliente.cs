using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

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

        #region Botoes.

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (validador.ApenasLetra(txtBoxNome.Text))
            {
                cliente.Nome = txtBoxNome.Text;
                cliente.Email = txtBoxEmail.Text;
                cliente.Telefone = txtBoxTelefone.Text;
                cliente.Endereco = txtBoxEndereco.Text;
                if(rdBtnCPF.Checked == true)
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
                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Insira apenas letras no campo 'Nome'",
                "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdBtnCPF_CheckedChanged(object sender, EventArgs e)
        { 
            txtBoxCPFCNPJ.Enabled = true;
        }

        private void rdBtnCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            cliente.PessoaFisica = false;
            txtBoxCPFCNPJ.Enabled = true;
        }

        #endregion

        #region rodape.

        private void TelaCadastroCliente_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion

        private void ChecarCPFCNPJ()
        {
            if(cliente.CPF == "" && cliente.CNPJ == "")
            {
                txtBoxCPFCNPJ.Text = "";
            }
            else if(cliente.CPF != "")
            {
                txtBoxCPFCNPJ.Text = cliente.CPF;
            }
            else
            {
                txtBoxCPFCNPJ.Text = cliente.CNPJ;
            }
        }
        
    }
}
