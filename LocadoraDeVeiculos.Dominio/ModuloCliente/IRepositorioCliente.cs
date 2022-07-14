using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        Cliente SelecionarClientePorNome(string nome);

        Cliente SelecionarClientePorCPF(string cpf);

        Cliente SelecionarClientePorCNPJ(string cnpj);

        
    }
}
