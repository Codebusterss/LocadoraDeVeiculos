using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCliente;
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

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutor : Form
    {
        private Cliente clienteSelecionado;
        private Condutor condutor;
        ValidadorRegex validador = new ValidadorRegex();
        private RepositorioClienteEmBancoDeDados repositorioClienteEmBanco = new RepositorioClienteEmBancoDeDados();
        public TelaCadastroCondutor(List<Cliente> clientes)
        {
            InitializeComponent();
            CarregarCondutor(clientes);
          
        }
        private void CarregarCondutor(List<Cliente> clientes)
        {
            comboBoxCondCliente.Items.Clear();

            foreach (var cliente in clientes)
            {
                comboBoxCondCliente.Items.Add(cliente.Nome);
            }
        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        public Condutor Condutor
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
                comboBoxCondCliente.SelectedItem = condutor.Cliente;
                checkBoxClienteCondutor.Checked = condutor.CondutorCliente;
                textBoxCondCPF.Text = condutor.CPF;
                textBoxCondCNH.Text = condutor.CNH;

               
            }
        }

        private void button1_Click(object sender, EventArgs e) //gravar
        {
           


            if (validador.ApenasLetra(textBoxCondNome.Text))
            {
                condutor.Cliente = clienteSelecionado;
                condutor.Nome = textBoxCondNome.Text;
                condutor.Email = textBoxCondEmail.Text;
                condutor.Telefone = textBoxTelefone.Text;
                condutor.Endereco = textBoxCondEndereco.Text;
                condutor.CPF = textBoxCondCPF.Text;
                condutor.CNH = textBoxCondCNH.Text;
                condutor.ValidadeCNH = DateTime.Parse(dateTimePickerCondValidade.Text);


                var resultadoValidacao = GravarRegistro(condutor);

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
                "Cadastro de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }
        }
       
        private void checkBoxClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {

            List<Cliente> clientes = repositorioClienteEmBanco.SelecionarTodos();
          
            string arrumar = "";

            
            if (comboBoxCondCliente.Text == "")
            {
                MessageBox.Show("Selecione um cliente primeiro",
                  "Cadastro de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (Cliente cliente in clientes)
                {
                    if (comboBoxCondCliente.Text == cliente.Nome)
                    {
                        clienteSelecionado = cliente;
                    }
                }
            }

            if(clienteSelecionado.PessoaFisica == false)
            {
                MessageBox.Show("Condutor não pode ser uma empresa.",
                "Cadastro de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                foreach (Cliente cliente in clientes)
                {
                    if(comboBoxCondCliente.Text == cliente.Nome)
                    {
                        textBoxCondNome.Text = cliente.Nome;
                        textBoxCondEmail.Text = cliente.Email;
                        arrumar = cliente.Telefone.Replace("(", "").Replace(")", "").Replace("-", "");
                        textBoxTelefone.Text = arrumar;
                        textBoxCondEndereco.Text = cliente.Endereco;
                        arrumar = cliente.CPF.Replace(".", "").Replace("-", "");
                        textBoxCondCPF.Text = arrumar;
                    }
                }
            }
        }

       


        private void comboBoxCondCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxClienteCondutor.Enabled = true;
        }

        private void TelaCadastroCondutor_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }
    }
}
