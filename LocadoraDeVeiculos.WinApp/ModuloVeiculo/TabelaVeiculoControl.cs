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

                new DataGridViewTextBoxColumn { DataPropertyName = "Plano Diário", HeaderText = "Plano Diário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Plano Controlado", HeaderText = "Plano Controlado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Plano Livre", HeaderText = "Plano Livre"}
            };

            return colunas;
        }


        public void AtualizarRegistros(List<Veiculo> planos)
        {
            grid.Rows.Clear();
            foreach (Veiculo veiculo in veiculo)
            {
                grid.Rows.Add(veiculo.ID, veiculo.veiculo.Nome, veiculo.DiarioValorDia, veiculo.ControladoValorDia, veiculo.LivreValorDia);
            }
        }

        public Guid ObtemPlanoSelecionado()
        {
            return grid.SelecionarPorID<Guid>();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
