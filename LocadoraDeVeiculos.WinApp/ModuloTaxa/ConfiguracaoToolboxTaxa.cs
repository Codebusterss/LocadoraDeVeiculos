﻿using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ConfiguracaoToolboxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Taxas";

        public override string TooltipInserir { get { return "Inserir uma taxa."; } }

        public override string TooltipEditar { get { return "Editar uma taxa."; } }

        public override string TooltipExcluir { get { return "Excluir uma taxa."; } }
    }
}
