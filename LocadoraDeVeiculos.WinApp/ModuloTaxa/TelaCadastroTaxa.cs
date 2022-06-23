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
        public Func<Taxa, ValidationResult> GravarRegistro { get; set; }

        private void btnCadastrarTaxa_Click(object sender, EventArgs e)
        {
            if (validador.ApenasLetra(txtTaxaDescricao.Text))
            {
                taxa.Tipo = GravarTipoTaxa();
                taxa.Valor = ConverterValor();
                taxa.Descricao = txtTaxaDescricao.Text;

                var resultadoValidacao = GravarRegistro(Taxa);
                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro); 

                    DialogResult = DialogResult.None;
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
                taxa.Tipo = GravarTipoTaxa();
                taxa.Valor = ConverterValor();
                taxa.Descricao = txtTaxaDescricao.Text;




            }
        }
        private double ConverterValor()
        {

            double valor = 0;

            bool estavalido = double.TryParse(txtBoxTaxaValor.Text, out valor);
            if(estavalido == false)
            {
                MessageBox.Show("Valor tem que ser apenas numeros!", "Valor invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
       

    }
}

