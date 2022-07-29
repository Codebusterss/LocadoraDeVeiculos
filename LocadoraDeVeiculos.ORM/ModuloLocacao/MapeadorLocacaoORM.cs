using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloLocacao
{
    public class MapeadorLocacaoORM : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("LOCACAO");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.DataLocacao).IsRequired();
            builder.Property(x => x.DataDevolucao).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.StatusLocacao).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Seguro).HasColumnType("varchar(300)").IsRequired();
            builder.HasOne(x => x.Funcionario)
                .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Condutor)
                .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Veiculo)
                .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Cliente)
              .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Plano)
                .WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
