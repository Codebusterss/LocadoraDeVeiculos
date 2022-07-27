using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ORM.ModuloFuncionario
{
    public class MapeadorFuncionarioORM : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIO");
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.DataAdmissao).IsRequired();
            builder.Property(x => x.Login).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Admin).IsRequired();
        }
    }
}
