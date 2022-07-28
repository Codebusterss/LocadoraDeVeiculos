
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloTaxa
{
    public class MapeadorTaxaORM : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TAXA");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Tipo).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("varchar(300)").IsRequired();
        }
    }
}