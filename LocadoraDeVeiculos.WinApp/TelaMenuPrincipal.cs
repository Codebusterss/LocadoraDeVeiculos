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
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;

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
                MessageBox.Show("Selecione um cadastro antes de adicionar!", "Cadastro n�o selecionado",
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
                MessageBox.Show("Selecione um cadastro antes de editar!", "Cadastro n�o selecionado",
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
                MessageBox.Show("Selecione um cadastro antes de excluir!", "Cadastro n�o selecionado",
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

        private void gruposDeVe�culosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGrupoDeVeiculo>());

        }

        private void funcion�riosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(funcionarioLogado.Admin == false)
            {
                MessageBox.Show("Voc� n�o tem permiss�o suficiente para verificar os funcion�rios.",
                    "Usu�rio sem permiss�o.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void planosDeCobran�aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();

            List<GrupoDeVeiculo> grupos = repositorioGrupo.SelecionarTodos();
            if (grupos.Count == 0)
            {
                MessageBox.Show("Cadastre um grupo de ve�culos antes de cadastrar um plano de cobran�a!",
                   "Sem grupos cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlanoDeCobranca>());
            }
        }

        private void ve�culosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();

            List<GrupoDeVeiculo> grupos = repositorioGrupo.SelecionarTodos();
            if (grupos.Count == 0)
            {
                MessageBox.Show("Cadastre um grupo de ve�culos antes de cadastrar um ve�culo!",
                   "Sem grupos cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculos>());
            }
        }

        private void loca��esToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var repositorioCondutores = new RepositorioCondutorEmBancoDeDados();
            var repositorioTaxas  = new RepositorioTaxaEmBancoDeDados();
            var repositorioVeiculos = new RepositorioVeiculoEmBancoDeDados();
            var repositorioPlanos = new RepositorioPlanoDeCobrancaEmBancoDeDados();
            var repositorioCliente = new RepositorioClienteEmBancoDeDados();


            List<Cliente> clientes = repositorioCliente.SelecionarTodos();
            List<Taxa> taxas = repositorioTaxas.SelecionarTodos();
            List<PlanoDeCobranca> planos = repositorioPlanos.SelecionarTodos();
            List<Veiculo> veiculos = repositorioVeiculos.SelecionarTodos();
            List<Condutor> condutor = repositorioCondutores.SelecionarTodos();
            if (clientes.Count == 0)
            {
                MessageBox.Show("Cadastre um cliente antes de cadastrar uma loca��o!",
                   "Sem clientes cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (taxas.Count == 0)
            {
                MessageBox.Show("Cadastre pelo menos uma taxa antes de cadastrar um loca��o!",
                   "Sem taxas cadastradas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (planos.Count == 0)
            {
                MessageBox.Show("Cadastre um plano de cobran�a antes de cadastrar um loca��o!",
                   "Sem planos cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (veiculos.Count == 0)
            {
                MessageBox.Show("Cadastre um ve�culo antes de cadastrar um loca��o!",
                   "Sem ve�culos cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (condutor.Count == 0)
            {
                MessageBox.Show("Cadastre um condutor antes de cadastrar um loca��o!",
                   "Sem condutores cadastrados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorLocacao>());

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