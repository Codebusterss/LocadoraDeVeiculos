using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloVeiculo
{
    public class MapeadorVeiculoORM : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULO");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.Modelo).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.KmPercorrido).IsRequired();
            builder.Property(x => x.TipoCombustivel).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CapacidadeDoTanque).IsRequired();
            builder.HasOne(x => x.GrupoDeVeiculo);
            builder.Property(x => x.Foto);
        }
    }
}
