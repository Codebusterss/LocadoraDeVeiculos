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
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{

    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Admissão", HeaderText = "Data de Admissão"}
            };

            return colunas;
        }


        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();
            foreach (Funcionario funcionario in funcionarios)
            {
                grid.Rows.Add(funcionario.ID, funcionario.Nome, funcionario.Login, funcionario.Senha, funcionario.DataAdmissao);
            }
        }

        public int ObtemGrupoDeVeiculoSelecionado()
        {
            return grid.SelecionarPorID<int>();
        }

    }
}
