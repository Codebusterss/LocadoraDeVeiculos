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
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo
{
    public partial class TelaCadastroGrupoDeVeiculo : Form
    {
        private GrupoDeVeiculo grupoDeVeiculo;
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroGrupoDeVeiculo()
        {
            InitializeComponent();
        }
        public Func<GrupoDeVeiculo, ValidationResult> GravarRegistro { get; set; }

        public GrupoDeVeiculo GrupoDeVeiculo
        {
            get
            {
                return grupoDeVeiculo;
            }
            set
            {
                grupoDeVeiculo = value;
                txtBoxNomeDoGrupo.Text = grupoDeVeiculo.Nome;
            }
        }

        #region Botoes.

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (validador.ApenasLetra(txtBoxNomeDoGrupo.Text))
            {
                grupoDeVeiculo.Nome = txtBoxNomeDoGrupo.Text;

                var resultadoValidacao = GravarRegistro(grupoDeVeiculo);
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

        #endregion

        #region rodape.

        private void TelaCadastroGrupoDeVeiculo_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroGrupoDeVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion
    }
}
