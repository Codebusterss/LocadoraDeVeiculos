using FluentResults;
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
        private DateTime dataBase = new DateTime(0001, 01, 01, 00, 00, 00);
        private DateTime dataAtual = DateTime.Now;
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get
            {
                return funcionario;
            }
            set
            {
                funcionario = value;
                txtBoxNome.Text = funcionario.Nome;
                txtBoxFuncionarioLogin.Text = funcionario.Login;
                txtboxFuncionarioSenha.Text = funcionario.Senha;
                txtBoxSalario.Text = funcionario.Salario.ToString();
                if (funcionario.DataAdmissao != dataBase)
                {
                    dateTimeFuncionarioData.Text = funcionario.DataAdmissao.ToString();
                }
                else
                {
                    dateTimeFuncionarioData.Text = dataAtual.ToString();
                }
                txtBoxFuncionarioID.Text = funcionario.ID.ToString();
                if(funcionario.Admin == true)
                {
                    checkBoxFuncionarioAdmin.Checked = true;
                }
            }
        }

        #region botoes.

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            if (validador.ApenasLetra(txtBoxNome.Text))
            {
                funcionario.Nome = txtBoxNome.Text;
                funcionario.Login = txtBoxFuncionarioLogin.Text;
                funcionario.Senha = txtboxFuncionarioSenha.Text;
                funcionario.Salario = converterSalario();
                funcionario.DataAdmissao = Convert.ToDateTime(dateTimeFuncionarioData.Text);
                if (checkBoxFuncionarioAdmin.Checked == true)
                {
                    funcionario.Admin = true;
                }
                else
                {
                    funcionario.Admin = false;
                }


                var resultadoValidacao = GravarRegistro(funcionario);
                if (resultadoValidacao.IsFailed)
                {
                    string erro = resultadoValidacao.Errors[0].Message;

                    if(erro.StartsWith("Falha no sistema"))
                    {
                      MessageBox.Show(erro,
                        "Cadastro de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                        DialogResult = DialogResult.None;
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira apenas letras no campo 'Nome'",
                "Cadastro de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }

        }

        #endregion

        #region rodape.

        private void TelaCadastroFuncionario_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion


        private float converterSalario()
        {
            float valorFinal = 0;

            bool estaValido = float.TryParse(txtBoxSalario.Text, out valorFinal);

            if(estaValido == false)
            {
                MessageBox.Show("Insira apenas números no campo 'Salário'",
                "Cadastro de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return valorFinal;
            }
            else
            {
                return valorFinal;
            }

        }
    }
}
