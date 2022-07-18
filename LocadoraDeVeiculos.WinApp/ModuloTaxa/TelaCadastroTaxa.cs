using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
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

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TelaCadastroTaxa : Form
    {
        private Taxa taxa;
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroTaxa()
        {
            InitializeComponent();
        }
        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get
            {
                return taxa;
            }
            set
            {
                taxa = value;
                ColarTipoTaxa();
                txtBoxTaxaValor.Text = taxa.Valor.ToString();
                txtTaxaDescricao.Text = taxa.Descricao;
            }
        }

        #region Botoes

        private void btnCadastrarTaxa_Click(object sender, EventArgs e)
        {

            taxa.Tipo = GravarTipoTaxa();
            taxa.Valor = ConverterValor();
            taxa.Descricao = txtTaxaDescricao.Text;

            var resultadoValidacao = GravarRegistro(Taxa);
            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                      "Cadastro de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }

        }

        #endregion

        #region Rodape

        private void TelaCadastroTaxa_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroTaxa_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion

        #region Metodos

        private double ConverterValor()
        {

            double valor = 0;

            bool estavalido = double.TryParse(txtBoxTaxaValor.Text, out valor);
            if (estavalido == false)
            {
                MessageBox.Show("Insira apenas números no campo 'Valor'.",
                "Cadastro de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return valor;

        }

        private string GravarTipoTaxa()
        {
            string tipo = "";
            if (radioBtnFixoTaxa.Checked == true)
            {
                tipo = "Fixo";
            }
            if (radioBtnDiarioTaxa.Checked == true)
            {
                tipo = "Diaria";
            }
            return tipo;
        }

        private string ColarTipoTaxa()
        {
            string tipo = "";
            if (taxa.Tipo == "Fixo")
            {
                radioBtnFixoTaxa.Checked = true;
            }
            if (taxa.Tipo == "Diaria")
            {
                radioBtnDiarioTaxa.Checked = true;
            }
            return tipo;
        }

        #endregion

    }
}

