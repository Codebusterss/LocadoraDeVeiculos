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

        private void btnCadastrarTaxa_Click(object sender, EventArgs e)
        {
            if (validador.ApenasLetra(txtTaxaDescricao.Text))
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
        }
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

        private double ConverterValor()
        {

            double valor = 0;

            bool estavalido = double.TryParse(txtBoxTaxaValor.Text, out valor);
            if(estavalido == false)
            {
                MessageBox.Show("Insira apenas números no campo 'Valor'",
                "Cadastro de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return valor;
            
        }

        private string GravarTipoTaxa()
        {
            string tipo = "";
            if  (radioBtnFixoTaxa.Checked == true)
            {
                tipo = "Fixo";
            }
            if (radioBtnDiarioTaxa.Checked == true) 
            {
                tipo = "Diário";
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


    }
}

