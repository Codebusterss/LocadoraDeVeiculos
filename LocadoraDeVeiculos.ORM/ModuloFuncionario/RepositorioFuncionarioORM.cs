using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;


namespace LocadoraDeVeiculos.ORM.ModuloFuncionario
{
    public class RepositorioFuncionarioORM : IRepositorioFuncionario
    {
        private DbSet<Funcionario> funcionarios;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioFuncionarioORM(LocadoraDeVeiculosDbContext dbContext)
        {
            funcionarios = dbContext.Set<Funcionario>();
            this.dbContext = dbContext;
        }

        public void Inserir(Funcionario novoRegistro)
        {
            funcionarios.Add(novoRegistro);
        }

        public void Editar(Funcionario registro)
        {
            funcionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            funcionarios.Remove(registro);
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return funcionarios.FirstOrDefault(x => x.Login == login);
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return funcionarios.FirstOrDefault(x => x.Nome == nome);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            return funcionarios.SingleOrDefault(x => x.ID == id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarios.ToList();
        }
    }
}
