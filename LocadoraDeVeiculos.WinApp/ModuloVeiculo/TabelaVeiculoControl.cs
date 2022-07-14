using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

    public partial class TabelaVeiculoControl : UserControl
    {
    private object grid;

    public TabelaVeiculoControl()
        {
            InitializeComponent();
            grid.ConfigurarGrid();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());

        }

        private DataGridViewColumn[] ObterColunas()
        {

            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Capacidade Do Tanque", HeaderText = "Capacidade Do Tanque"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Km Percorrido", HeaderText = "Km Percorrido"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo Combustivel", HeaderText = "Tipo Combustivel"},

                
            };

            return colunas;
        }


        public void AtualizarRegistros(List<Veiculo> veiculo)
        {
            grid.Rows.Clear();
            foreach (Veiculo veiculo in veiculo)
            {
            object value = grid.Rows.Add(veiculo.ID, veiculo.Modelo, veiculo.Marca, veiculo.Placa, veiculo.Cor, veiculo.CapacidadeDoTanque, veiculo.KmPercorrido, veiculo.Ano, veiculo.TipoCombustivel);
            }
        }

        public int ObtemGrupoDeVeiculoSelecionado()
        {
            return grid.SelecionarPorID<int>();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TabelaVeiculoControl
            // 
            this.Name = "TabelaVeiculoControl";
            this.Load += new System.EventHandler(this.TabelaVeiculoControl_Load);
            this.ResumeLayout(false);

        }

        private void TabelaVeiculoControl_Load(object sender, EventArgs e)
        {

        }
    }
}