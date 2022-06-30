using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutor : Form
    {
        public TelaCadastroCondutor()
        {
            InitializeComponent();
        }
        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        public Condutor condutor
        {
            get
            {
                return condutor;
            }
            set
            {
                condutor = value;
                textBoxCondID.Text = condutor.ID.ToString();
                textBoxCondEmail.Text = condutor.Email;
                textBoxCondEndereco.Text = condutor.Endereco;
                textBoxCondNome.Text = condutor.Nome;
                textBoxTelefone.Text = condutor.Telefone;
                textBoxCondCPF = condutor.CPF.ToString();
                if (cliente.CNH != "")
                {
                    txtBoxCNH.Text = condutor.CNH;
                }
                ChecarCPFCNPJ();
            }
        }
    }
}
