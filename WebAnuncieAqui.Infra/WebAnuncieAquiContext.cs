using WebAnuciaAqui.Dominio.Dominios.Usuarios;
using WebAnuciaAqui.Infra.Mapeamento.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Infra.Mapeamento.Anuncios;
using WebAnuncieAqui.Infra.Mapeamento.Veiculos;
using WebAnuncieAqui.Infra.Mapeamento.Vendas;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Veiculos;
using WebAnuncieAqui.Dominio.Dominios.Vendas;

namespace WebAnuciaAqui.Infra
{
    public class WebAnuncieAquiContext : DbContext
    {
        public WebAnuncieAquiContext(DbContextOptions<WebAnuncieAquiContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbQuery<RelatorioVenda> RelatorioVendas{ get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new AnuncioMap());
        }
    }
}
