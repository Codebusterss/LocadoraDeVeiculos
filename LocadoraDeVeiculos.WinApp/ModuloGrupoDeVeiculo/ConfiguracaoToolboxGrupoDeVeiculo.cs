using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo
{
    public class ConfiguracaoToolboxGrupoDeVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Grupos de Veículos";

        public override string TooltipInserir { get { return "Inserir um grupo de veículos."; } }

        public override string TooltipEditar { get { return "Editar um grupo de veículos."; } }

        public override string TooltipExcluir { get { return "Excluir um grupo de veículos."; } }
    }
}
