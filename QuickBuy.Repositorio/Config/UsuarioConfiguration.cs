using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)"); 
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(p => p.Senha).IsRequired().HasMaxLength(400).HasColumnType("varchar(400)");
            builder.Property(p => p.SobreNome).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            //builder.Property(p=> p.Pedidos)

            builder.HasMany(u => u.Pedidos).WithOne(p => p.Usuario);

        }
    }
}
