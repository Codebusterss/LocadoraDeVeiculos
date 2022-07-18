using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaMenuPrincipal : Form
    {
        private ControladorBase controlador;
        private IServiceLocator serviceLocator;
        private Funcionario funcionarioLogado;

        public TelaMenuPrincipal(Funcionario funcionarioLogado, IServiceLocator serviceLocator)
        {
            InitializeComponent();
            this.serviceLocator = serviceLocator;
            Instancia = this;
            lblStatusRodape.Text = string.Empty;
            this.funcionarioLogado = funcionarioLogado;
        }

        #region Botoes

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione um cadastro antes de adicionar!", "Cadastro não selecionado",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                controlador.Inserir();
            }        
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione um cadastro antes de editar!", "Cadastro não selecionado",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                controlador.Editar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione um cadastro antes de excluir!", "Cadastro não selecionado",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                controlador.Excluir();
            }
        }

        #endregion

        #region Itens do menu

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
        }

        private void gruposDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGrupoDeVeiculo>());

        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(funcionarioLogado.Admin == false)
            {
                MessageBox.Show("Você não tem permissão suficiente para verificar os funcionários.",
                    "Usuário sem permissão.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorFuncionario>());
            }           
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorTaxa>());
        }

        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var repositorioCliente = new RepositorioClienteEmBancoDeDados();


            List<Cliente> clientes = repositorioCliente.SelecionarTodos();
            if(clientes.Count == 0)
            {
                MessageBox.Show("Cadastre um cliente antes de cadastrar um condutor!",
                   "Sem clientes cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCondutor>());
            }

                       
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();

            List<GrupoDeVeiculo> grupos = repositorioGrupo.SelecionarTodos();
            if (grupos.Count == 0)
            {
                MessageBox.Show("Cadastre um grupo de veículos antes de cadastrar um plano de cobrança!",
                   "Sem clientes cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlanoDeCobranca>());
            }
        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();

            List<GrupoDeVeiculo> grupos = repositorioGrupo.SelecionarTodos();
            if (grupos.Count == 0)
            {
                MessageBox.Show("Cadastre um grupo de veículos antes de cadastrar um veículo!",
                   "Sem clientes cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculos>());
            }
        }

        #endregion

        #region Eventos.

        private void TelaMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Metodos

        public static TelaMenuPrincipal Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            lblStatusRodape.Text = mensagem;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();



            if (configuracao != null)
            {

                toolStrip1.Visible = true;

                lblTitulo.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }

        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Visible = configuracao.InserirHabilitado;
            btnEditar.Visible = configuracao.EditarHabilitado;
            btnExcluir.Visible = configuracao.ExcluirHabilitado;

        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        #endregion

    }
}