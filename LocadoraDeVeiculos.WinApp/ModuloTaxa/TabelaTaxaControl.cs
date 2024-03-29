﻿using LocadoraDeVeiculos.Dominio.ModuloTaxa;
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

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TabelaTaxaControl : UserControl
    {
        public TabelaTaxaControl()
        {
            InitializeComponent();
            grid.ConfigurarGrid();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        private DataGridViewColumn[] ObterColunas()
        {

            var colunas = new DataGridViewColumn[] {
                 new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descrição", HeaderText = "Descrição"},

             

            };

            return colunas;
        }
        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();
            foreach (Taxa t in taxas)
            {
                grid.Rows.Add(t.ID, t.Valor, t.Tipo, t.Descricao);
            }
        }

        public Guid ObtemTaxaSelecionada()
        {
            return grid.SelecionarPorID<Guid>();
        }
    }
}
