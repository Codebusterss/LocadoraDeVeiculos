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
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo
{

    public partial class TabelaGrupoDeVeiculoControl : UserControl
    {
        public TabelaGrupoDeVeiculoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"}
            };

            return colunas;
        }


        public void AtualizarRegistros(List<GrupoDeVeiculo> grupoDeVeiculos)
        {
            grid.Rows.Clear();
            foreach (GrupoDeVeiculo grupo in grupoDeVeiculos)
            {
                grid.Rows.Add(grupo.ID, grupo.Nome);
            }
        }

        public int ObtemGrupoDeVeiculoSelecionado()
        {
            return grid.SelecionarPorID<int>();
        }

    }
}
