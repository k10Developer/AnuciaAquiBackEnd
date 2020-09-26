using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Vendas;

namespace WebAnuncieAqui.Infra.Mapeamento.Vendas
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable<Venda>("Venda");
            builder.HasKey(c => c.Id);

        }
    }
}
