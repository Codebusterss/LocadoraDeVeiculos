using System;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorioBase<Veiculo>
    {
        Veiculo SelecionarFuncionarioPorNome(string nome);

        Veiculo SelecionarFuncionarioPorLogin(string login);
    }
}
