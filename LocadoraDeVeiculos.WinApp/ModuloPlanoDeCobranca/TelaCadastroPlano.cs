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
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using FluentResults;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public partial class TelaCadastroPlano : Form
    {
        private PlanoDeCobranca plano;
        ValidadorRegex validador = new ValidadorRegex();


        public TelaCadastroPlano(List<GrupoDeVeiculo> grupos)
        {
            InitializeComponent();
            CarregarGrupos(grupos);
        }

        public Func<PlanoDeCobranca, Result<PlanoDeCobranca>> GravarRegistro { get; set; }

        private void CarregarGrupos(List<GrupoDeVeiculo> grupos)
        {
            cbBoxGrupos.Items.Clear();

            foreach (var grupo in grupos)
            {
                cbBoxGrupos.Items.Add(grupo);
            }
        }

        public PlanoDeCobranca Plano
        {
            get
            {
                return plano;
            }
            set
            {
                plano = value;
                cbBoxGrupos.SelectedItem = plano.GrupoDeVeiculos;
                txtBoxDiarioValorDia.Text = plano.DiarioValorDia.ToString();
                txtBoxDiarioValorKM.Text = plano.DiarioValorKM.ToString();
                txtBoxLivreValorDia.Text = plano.LivreValorDia.ToString();
                txtBoxControladoValorDia.Text = plano.ControladoValorDia.ToString();
                txtBoxControladoValorKM.Text = plano.ControladoValorKM.ToString();
                txtBoxControladoLimiteKM.Text = plano.ControladoLimiteKM.ToString();
            }
        }

        #region Botoes.

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string diariaValorReplace = txtBoxDiarioValorDia.Text.Replace(",", ".");
            string diariaKMReplace = txtBoxDiarioValorKM.Text.Replace(",", ".");

            if (!validador.ApenasNumerosInteirosOuDecimais(diariaValorReplace) || !validador.ApenasNumerosInteirosOuDecimais(diariaKMReplace))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira apenas números válidos no Plano Diário.");
                DialogResult = DialogResult.None;
                return;
            }

            string livreValorReplace = txtBoxLivreValorDia.Text.Replace(",", ".");

            if (!validador.ApenasNumerosInteirosOuDecimais(livreValorReplace))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira apenas números válidos no Plano Livre.");
                DialogResult = DialogResult.None;
                return;
            }

            string controladoValorReplace = txtBoxControladoValorDia.Text.Replace(",", ".");
            string controladoKMReplace = txtBoxControladoValorKM.Text.Replace(",", ".");
            string controladoLimiteReplace = txtBoxControladoLimiteKM.Text.Replace(",", ".");



            if (!validador.ApenasNumerosInteirosOuDecimais(controladoValorReplace) || !validador.ApenasNumerosInteirosOuDecimais(controladoKMReplace) || !validador.ApenasNumerosInteirosOuDecimais(controladoLimiteReplace))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira apenas números válidos no Plano Controlado.");
                DialogResult = DialogResult.None;
                return;
            }

            plano.GrupoDeVeiculos = (GrupoDeVeiculo)cbBoxGrupos.SelectedItem;
            plano.DiarioValorDia = Convert.ToDouble(diariaValorReplace);
            plano.DiarioValorKM = Convert.ToDouble(diariaKMReplace);
            plano.LivreValorDia = Convert.ToDouble(livreValorReplace);
            plano.ControladoValorDia = Convert.ToDouble(controladoValorReplace);
            plano.ControladoValorKM = Convert.ToDouble(controladoKMReplace);
            plano.ControladoLimiteKM = Convert.ToDouble(controladoLimiteReplace);

            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                      "Cadastro de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }

        }


        #endregion

        #region Rodape.

        private void TelaCadastroPlano_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroPlano_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }


        #endregion

        private void cbBoxGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlPlanos.Enabled = true;
        }
    }
}
