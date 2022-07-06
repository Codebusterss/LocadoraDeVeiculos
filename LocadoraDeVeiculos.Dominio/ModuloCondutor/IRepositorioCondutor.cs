using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorioBase<Condutor>
    {
        Condutor SelecionarCondutorPorNome(string nome);

        Condutor SelecionarCondutorPorCPF(string cpf);

       Condutor SelecionarCondutorPorCNH(string cnh);

    }
}
