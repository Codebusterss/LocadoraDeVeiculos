using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloVeiculo
{
    public class RepositorioVeiculoORM
    {
        private DbSet<Veiculo> veiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioVeiculoORM(LocadoraDeVeiculosDbContext dbContext)
        {
            veiculos = dbContext.Set<Veiculo>();
            this.dbContext = dbContext;
        }

        public void Editar(Veiculo registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiculos.Remove(registro);
        }

        public void Inserir(Veiculo novoRegistro)
        {
            veiculos.Add(novoRegistro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(x => x.ID == id);
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return veiculos.FirstOrDefault(x => x.Placa == placa);
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiculos.ToList();
        }
    }
}
