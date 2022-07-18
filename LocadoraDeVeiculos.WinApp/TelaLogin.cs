using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaLogin : Form
    {
        private RepositorioFuncionarioEmBancoDeDados repositorioFuncionario;
        public Funcionario funcionarioLogado;


        public TelaLogin()
        {
            InitializeComponent();
            CarregarRepositorio();
        }

        private void CarregarRepositorio()
        {
            repositorioFuncionario = new RepositorioFuncionarioEmBancoDeDados();
        }

        private void ChecarFuncionario()
        {
            var funcionariosRegistrados = repositorioFuncionario.SelecionarTodos();

            int j = funcionariosRegistrados.Count() - 1;

            if(funcionariosRegistrados.Count() == 0)
            {
                MessageBox.Show("Não existem funcionários cadastrados, fale com o administrador do sistema.",
                    "Sem funcionários cadastrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < funcionariosRegistrados.Count; i++)
            {
                Funcionario funcionario = funcionariosRegistrados[i];

                if (funcionario.Login == txtBoxLogin.Text && funcionario.Senha == txtBoxSenha.Text)
                {
                    funcionarioLogado = funcionario;
                    var serviceLocatorAutofac = new ServiceLocatorComAutofac();
                    TelaMenuPrincipal tela = new TelaMenuPrincipal(funcionarioLogado, serviceLocatorAutofac);
                    tela.Show();                 
                    // solução temporária, verificar como melhorar.
                    this.Hide();
                    break;
                }

                if(i == j)
                {
                    MessageBox.Show("Usuário ou senha incorretos.",
                    "Funcionário não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Botoes.

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ChecarFuncionario();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion
    }
}
