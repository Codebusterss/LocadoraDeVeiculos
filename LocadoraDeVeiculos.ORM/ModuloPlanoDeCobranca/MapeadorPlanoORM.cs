using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoORM : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("PLANODECOBRANCA");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.DiarioValorDia).IsRequired();
            builder.Property(x => x.DiarioValorKM).IsRequired();
            builder.Property(x => x.ControladoValorKM).IsRequired();
            builder.Property(x => x.ControladoLimiteKM).IsRequired();
            builder.Property(x => x.ControladoValorDia).IsRequired();
            builder.Property(x => x.LivreValorDia).IsRequired();
            builder.HasOne(x => x.GrupoDeVeiculos);
        }
    }
}
