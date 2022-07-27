using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;


namespace LocadoraDeVeiculos.ORM.ModuloCliente
{
    public class RepositorioClienteORM : IRepositorioCliente
    {
        private DbSet<Cliente> clientes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioClienteORM(LocadoraDeVeiculosDbContext dbContext)
        {
            clientes = dbContext.Set<Cliente>();
            this.dbContext = dbContext;
        }

        public void Inserir(Cliente novoRegistro)
        {
            clientes.Add(novoRegistro);
        }

        public void Editar(Cliente registro)
        {
            clientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            clientes.Remove(registro);
        }
        public Cliente SelecionarClientePorNome(string nome)
        {
            return clientes.FirstOrDefault(x => x.Nome == nome);
        }
        public Cliente SelecionarClientePorCNPJ(string cnpj)
        {
            return clientes.FirstOrDefault(x => x.CNPJ == cnpj);
        }

        public Cliente SelecionarClientePorCPF(string cpf)
        {
            return clientes.FirstOrDefault(x => x.CPF == cpf);
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return clientes.SingleOrDefault(x => x.ID == id);
        }

        public List<Cliente> SelecionarTodos()
        {
            return clientes.ToList();
        }
    }
}