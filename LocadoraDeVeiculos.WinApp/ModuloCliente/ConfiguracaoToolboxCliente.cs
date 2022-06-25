using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Clientes";

        public override string TooltipInserir { get { return "Inserir um cliente."; } }

        public override string TooltipEditar { get { return "Editar um cliente."; } }

        public override string TooltipExcluir { get { return "Excluir um cliente."; } }
    }
}
