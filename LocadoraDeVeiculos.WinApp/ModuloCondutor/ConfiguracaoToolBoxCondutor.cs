using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ConfiguracaoToolBoxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Condutores";

        public override string TooltipInserir { get { return "Inserir um condutor."; } }

        public override string TooltipEditar { get { return "Editar um condutor."; } }

        public override string TooltipExcluir { get { return "Excluir um condutor."; } }
    }
}
