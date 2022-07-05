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
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{

    public partial class TabelaPlanoControl : UserControl
    {
        public TabelaPlanoControl()
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


        public void AtualizarRegistros(List<PlanoDeCobranca> planos)
        {
            grid.Rows.Clear();
            foreach (PlanoDeCobranca plano in planos)
            {
                grid.Rows.Add(plano.ID, plano.GrupoDeVeiculos.Nome, plano.DiarioValorDia, plano.ControladoValorDia, plano.LivreValorDia);
            }
        }

        public int ObtemPlanoSelecionado()
        {
            return grid.SelecionarPorID<int>();
        }

    }
}