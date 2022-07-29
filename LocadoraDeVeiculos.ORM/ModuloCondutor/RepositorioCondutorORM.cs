using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;


namespace LocadoraDeVeiculos.ORM.ModuloCondutor
{
    public class RepositorioCondutorORM : IRepositorioCondutor
    {
        private DbSet<Condutor> condutor;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioCondutorORM(LocadoraDeVeiculosDbContext dbContext)
        {
            condutor = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }

        public void Inserir(Condutor novoRegistro)
        {
            condutor.Add(novoRegistro);
        }

        public void Editar(Condutor registro)
        {
            condutor.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            condutor.Remove(registro);
        }
        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return condutor.FirstOrDefault(x => x.Nome == nome);
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return condutor.FirstOrDefault(x => x.CPF == cpf);
        }

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            return condutor.FirstOrDefault(x => x.CNH == cnh);
        }

        public Condutor SelecionarPorId(Guid id)
        {
            return condutor.SingleOrDefault(x => x.ID == id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutor.Include(x => x.Cliente).ToList();
        }
    }
}