using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca : IRepositorioBase<PlanoDeCobranca>
    {
        PlanoDeCobranca SelecionarPlanoPorGrupo(Guid idGrupo);
    }
}