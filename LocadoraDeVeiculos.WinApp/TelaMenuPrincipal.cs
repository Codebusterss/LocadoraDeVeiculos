using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaMenuPrincipal : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;

        public TelaMenuPrincipal()
        {
            InitializeComponent();
            Instancia = this;
            lblStatusRodape.Text = string.Empty;
            InicializarControladores();
        }

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

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Grupos de Ve�culos", new ControladorGrupoDeVeiculo(repositorioGrupoDeVeiculos));
        }
        

        #region botoes.

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

        #region itens do menu.

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void gruposDeVe�culosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }

        private void funcion�riosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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