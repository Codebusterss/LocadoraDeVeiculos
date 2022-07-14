using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ConfiguracaoToolboxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Veiculos";

        public override string TooltipInserir { get { return "Inserir um veiculo."; } }

        public override string TooltipEditar { get { return "Editar um veiculo."; } }

        public override string TooltipExcluir { get { return "Excluir um veiculo."; } }
    }
}
