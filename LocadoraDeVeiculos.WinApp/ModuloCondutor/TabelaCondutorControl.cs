using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Clientes", HeaderText = "Clientes"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereco"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"}
          };

            return colunas;
        }
        public void AtualizarRegistros(List<Condutor> condutor)
        {
            grid.Rows.Clear();
            foreach (Condutor c in condutor)
            {
                grid.Rows.Add(c.ID, c.Nome, c.Endereco, c.Email, c.Telefone);
            }
        }
      
        public int ObtemCondutorSelecionado()
        {
            return grid.SelecionarPorID<int>();
        }
    }
}
