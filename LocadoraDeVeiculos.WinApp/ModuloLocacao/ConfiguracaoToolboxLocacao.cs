using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    internal class ConfiguracaoToolboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Locações";

        public override string TooltipInserir { get { return "Inserir uma locação."; } }

        public override string TooltipEditar { get { return "Editar uma locação."; } }

        public override string TooltipExcluir { get { return "Excluir uma locação."; } }
    }
}
}
