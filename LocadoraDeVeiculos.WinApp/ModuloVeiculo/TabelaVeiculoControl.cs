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

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Grupo de Veículos", HeaderText = "Grupo de Veículos"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Km Percorridos", HeaderText = "Km Percorridos"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo de Combustível", HeaderText = "Tipo de Combustível"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Capacidade do Tanque", HeaderText = "Capacidade do Tanque"},
            };

            return colunas;
        }


        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();
            foreach (Veiculo veiculo in veiculos)
            {
                grid.Rows.Add(veiculo.ID, veiculo.GrupoDeVeiculo.Nome, veiculo.Marca, veiculo.Modelo, veiculo.Placa, veiculo.KmPercorrido, veiculo.TipoCombustivel, veiculo.CapacidadeDoTanque);
            }
        }

        public Guid ObtemVeiculoSelecionado()
        {
            return grid.SelecionarPorID<Guid>();
        }
    }
}
