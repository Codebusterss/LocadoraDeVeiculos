using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloLocacao
{
    public class RepositorioLocacaoORM : IRepositorioLocacao
    {

        private DbSet<Locacao> locacoes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioLocacaoORM(LocadoraDeVeiculosDbContext dbContext)
        {
            locacoes = dbContext.Set<Locacao>();
            this.dbContext = dbContext;
        }
        public void Editar(Locacao registro)
        {
            locacoes.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            locacoes.Remove(registro);
        }

        public void Inserir(Locacao novoRegistro)
        {
            locacoes.Add(novoRegistro);
        }
   
        public Locacao SelecionarPorId(Guid id)
        {
            return locacoes.SingleOrDefault(x => x.ID == id);
        }

        public Locacao SelecionarLocacaoPorVeiculoID(Guid id)
        {
            return locacoes.FirstOrDefault(x => x.Veiculo.ID == id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return locacoes
                .Include(x => x.Funcionario)
                .Include(x => x.Condutor)
                .Include(x => x.Veiculo)
                .Include(x => x.Plano)
                .Include(x => x.Taxas)
                .Include(x => x.Cliente)
                .ToList();
        }
    }
}
