using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoORM : IRepositorioPlanoDeCobranca
    {
        private DbSet<PlanoDeCobranca> planos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioPlanoORM(LocadoraDeVeiculosDbContext dbContext)
        {
            planos = dbContext.Set<PlanoDeCobranca>();
            this.dbContext = dbContext;
        }
        public void Editar(PlanoDeCobranca registro)
        {
            planos.Update(registro);
        }

        public void Excluir(PlanoDeCobranca registro)
        {
            planos.Remove(registro);
        }

        public void Inserir(PlanoDeCobranca novoRegistro)
        {
            planos.Add(novoRegistro);
        }

        public PlanoDeCobranca SelecionarPorId(Guid id)
        {
            return planos.SingleOrDefault(x => x.ID == id);
        }

        public List<PlanoDeCobranca> SelecionarTodos()
        {
            return planos.ToList();
        }

        public PlanoDeCobranca SelecionarPlanoPorGrupo(Guid id)
        {
            return planos.FirstOrDefault(x => x.GrupoDeVeiculos.ID == id);
        }
    }
}
