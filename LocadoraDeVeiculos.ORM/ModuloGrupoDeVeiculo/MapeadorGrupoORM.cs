using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloGrupoDeVeiculo
{
    public class MapeadorGrupoORM : IEntityTypeConfiguration<GrupoDeVeiculo>
    {
        public void Configure(EntityTypeBuilder<GrupoDeVeiculo> builder)
        {
            builder.ToTable("GRUPODEVEICULOS");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
        }
    }
}
