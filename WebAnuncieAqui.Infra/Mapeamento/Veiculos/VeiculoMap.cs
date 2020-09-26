using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Veiculos;

namespace WebAnuncieAqui.Infra.Mapeamento.Veiculos
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable<Veiculo>("Veiculo");
            builder.HasKey(c => c.Id);

        }

    }
}

