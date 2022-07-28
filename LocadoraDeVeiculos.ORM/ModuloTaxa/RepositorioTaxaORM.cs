using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.ORM.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;


namespace LocadoraDeVeiculos.ORM.ModuloTaxa
{
    public class RepositorioTaxaORM : IRepositorioTaxa
    {
        private DbSet<Taxa> taxa;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioTaxaORM(LocadoraDeVeiculosDbContext dbContext)
        {
            taxa = dbContext.Set<Taxa>();
            this.dbContext = dbContext;
        }

        public void Inserir(Taxa novoRegistro)
        {
            taxa.Add(novoRegistro);
        }

        public void Editar(Taxa registro)
        {
            taxa.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            taxa.Remove(registro);
        }

        public Taxa SelecionarPorId(Guid id)
        {
            return taxa.SingleOrDefault(x => x.ID == id);
        }

        public List<Taxa> SelecionarTodos()
        {
            return taxa.ToList();
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return taxa.FirstOrDefault(x => x.Descricao == descricao);
        }
    }
}