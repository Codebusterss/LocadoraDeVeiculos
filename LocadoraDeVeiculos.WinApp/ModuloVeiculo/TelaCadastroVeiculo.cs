using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        internal Veiculo veiculo;

        public TelaCadastroVeiculo()
        {
            InitializeComponent();
        }

        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TelaCadastroVeiculo_Load(object sender, EventArgs e)
        {

        }
    }
}
