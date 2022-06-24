using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfigurarToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Funcionários";

        public override string TooltipInserir { get { return "Inserir um funcionário."; } }

        public override string TooltipEditar { get { return "Editar um funcionário."; } }

        public override string TooltipExcluir { get { return "Excluir um funcionário."; } }
    }
}
