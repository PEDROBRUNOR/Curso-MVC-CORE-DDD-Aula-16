using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using System;

namespace Projeto.Curso.Core.Infra.Data.Mappings
{
    public class ProdutosMapping : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Apelido)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(p => p.Unidade)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.HasOne(p => p.Fornecedor)
               .WithMany(f => f.Produtos)
               .HasForeignKey(p => p.IdFornecedor);

            builder.Ignore(p => p.ListaErros);

            builder.ToTable("Produtos");

        }
    }
}



