using LocadoraDeVeiculos.Dominio.ModuloLocacao;
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

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Veículo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Locacação", HeaderText = "Data de Locacação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Devolução", HeaderText = "Data de Devolução"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Status da Locação", HeaderText = "Status da Locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor Estimado", HeaderText = "Valor Estimado"}
            };

            return colunas;
        }


        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();
            foreach (Locacao locacao in locacoes)
            {
                grid.Rows.Add(locacao.ID, locacao.Veiculo.Modelo, locacao.DataLocacao, locacao.DataDevolucao, locacao.StatusLocacao, locacao.Valor);
            }
        }

        public Guid ObtemLocacaoSelecionada()
        {
            return grid.SelecionarPorID<Guid>();
        }

    }
}
