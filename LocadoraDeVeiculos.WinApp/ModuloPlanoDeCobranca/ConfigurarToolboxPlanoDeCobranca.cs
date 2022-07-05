using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ConfigurarToolboxPlanoDeCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Planos de Cobrança";

        public override string TooltipInserir { get { return "Inserir um novo plano."; } }

        public override string TooltipEditar { get { return "Editar um plano."; } }

        public override string TooltipExcluir { get { return "Excluir um plano."; } }
    }
}