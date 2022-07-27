using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloCondutor
{
    public class MapeadorCondutorORM : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("CONDUTOR");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.ValidadeCNH).IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CPF).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CNH).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CondutorCliente).IsRequired();
            builder.HasOne(x => x.Cliente);
        }
    }
}