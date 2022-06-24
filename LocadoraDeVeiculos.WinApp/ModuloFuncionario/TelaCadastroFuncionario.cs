using FluentValidation.Results;
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

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        private Funcionario funcionario;
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario GrupoDeVeiculo
        {
            get
            {
                return funcionario;
            }
            set
            {
                funcionario = value;
                txtBoxFuncionarioLogin.Text = funcionario.Login;
                txtboxFuncionarioSenha.Text = funcionario.Senha;
                //dateTimeFuncionarioData. = funcionario.DataAdmissao; //ver como usa o datetime 
                txtBoxFuncionarioID.Text = funcionario.ID.ToString();
            }
        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            if (validador.ApenasLetra(txtBoxFuncionarioLogin.Text))
            {
                funcionario.Login = txtBoxFuncionarioLogin.Text;
                //ver sobre a senha/id/data admissao
               

                var resultadoValidacao = GravarRegistro(funcionario);
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
                "Cadastro de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TelaCadastroGrupoDeVeiculo_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroGrupoDeVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }


    }
}
