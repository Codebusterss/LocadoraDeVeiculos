using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloGrupoDeVeiculo
{
    public class RepositorioGrupoORM : IRepositorioGrupoDeVeiculo
    {

        private DbSet<GrupoDeVeiculo> grupos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioGrupoORM(LocadoraDeVeiculosDbContext dbContext)
        {
            grupos = dbContext.Set<GrupoDeVeiculo>();
            this.dbContext = dbContext;
        }
        public void Editar(GrupoDeVeiculo registro)
        {
            grupos.Update(registro);
        }

        public void Excluir(GrupoDeVeiculo registro)
        {
            grupos.Remove(registro);
        }

        public void Inserir(GrupoDeVeiculo novoRegistro)
        {
            grupos.Add(novoRegistro);
        }

        public GrupoDeVeiculo SelecionarGrupoPorNome(string nome)
        {
            return grupos.FirstOrDefault(x => x.Nome == nome);
        }

        public GrupoDeVeiculo SelecionarPorId(Guid id)
        {
            return grupos.SingleOrDefault(x => x.ID == id);
        }

        public List<GrupoDeVeiculo> SelecionarTodos()
        {
            return grupos.ToList();
        }
    }
}
