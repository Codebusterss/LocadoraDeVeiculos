using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloCliente
{
    public class MapeadorClienteORM : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CNPJ).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CPF).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.PessoaFisica).IsRequired();
        }
    }
}
