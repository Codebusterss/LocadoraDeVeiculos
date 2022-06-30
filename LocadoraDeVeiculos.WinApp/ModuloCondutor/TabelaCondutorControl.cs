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
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
        {
            InitializeComponent();
        }
        public void AtualizarRegistros(List<Condutor> condutor)
        {
            grid.Rows.Clear();
            foreach (Condutor c in condutor)
            {
                grid.Rows.Add(c.ID, c.Nome, c.Endereco, c.Email, c.Telefone);
            }
        }
        public int ObtemClienteSelecionado()
        {
            return grid.SelecionarPorID<int>();
        }
    }
}
