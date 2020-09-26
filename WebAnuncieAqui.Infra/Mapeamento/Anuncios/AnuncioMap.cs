using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Veiculos;

namespace WebAnuncieAqui.Infra.Mapeamento.Anuncios
{
    public class AnuncioMap : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.ToTable<Anuncio>("Anuncio");
            builder.HasKey(c => c.Id);

        }
    }
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable<Marca>("Marca");
            builder.HasKey(c => c.Id);

        }
    }

    public class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable<Modelo>("Modelo");
            builder.HasKey(c => c.Id);

        }
    }
}
