using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaMenuPrincipal : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        private Funcionario funcionarioLogado;

        public TelaMenuPrincipal(Funcionario funcionarioLogado)
        {
            InitializeComponent();
            Instancia = this;
            lblStatusRodape.Text = string.Empty;
            this.funcionarioLogado = funcionarioLogado;
            InicializarControladores();
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
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void gruposDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

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
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            }           
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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


        private void InicializarControladores()
        {
            var repositorioGrupoDeVeiculos = new RepositorioGrupoDeVeiculosEmBancoDeDados();
            var repositorioCliente = new RepositorioClienteEmBancoDeDados();
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDeDados();
            var repositorioTaxa = new RepositorioTaxaEmBancoDeDados();
            var repositorioPlano = new RepositorioPlanoDeCobrancaEmBancoDeDados();
            var repositorioCondutor = new RepositorioCondutorEmBancoDeDados();
            var repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();

            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoGrupoDeVeiculos = new ServicoGrupoDeVeiculo(repositorioGrupoDeVeiculos);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoPlano = new ServicoPlanoDeCobranca(repositorioPlano);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Grupos de Veículos", new ControladorGrupoDeVeiculo(servicoGrupoDeVeiculos));
            controladores.Add("Clientes", new ControladorCliente(servicoCliente));
            controladores.Add("Funcionários", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("Taxas", new ControladorTaxa(servicoTaxa));
            controladores.Add("Planos de Cobrança", new ControladorPlanoDeCobranca(servicoPlano, repositorioGrupoDeVeiculos));
            controladores.Add("Condutores", new ControladorCondutor(servicoCondutor, repositorioCliente));
            controladores.Add("Veículos", new ControladorVeiculos(servicoVeiculo, repositorioGrupoDeVeiculos));
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

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