using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDeDados :RepositorioBase<Condutor, MapeadorCondutor>,IRepositorioCondutor
    {
       
    }
}
