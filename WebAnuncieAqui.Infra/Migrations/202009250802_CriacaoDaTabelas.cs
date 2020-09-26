using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Infra.Migrations
{
    [Migration(202009250802)]
    public class _202009250802_CriacaoDaTabelas : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Create.Table("Anuncio").
                WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("VeiculoId").AsInt32()
                .WithColumn("DetalhesVeiculo").AsString(200)
                .WithColumn("Titulo").AsString(200)
                .WithColumn("Descricao").AsString(1000)
                .WithColumn("Valor").AsDouble()
                .WithColumn("DataDeCriacaoDoAnuncio").AsDateTime()
                .WithColumn("Ativo").AsBoolean()
                .WithColumn("Finalizar").AsBoolean().Nullable();

            Create.Table("Venda").
                WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("AnuncioId").AsInt32()
                .WithColumn("DetalheAnuncio").AsString(200)
                .WithColumn("ValorDeVenda").AsDouble()
                .WithColumn("DataDaVenda").AsDateTime()
                .WithColumn("Ativo").AsBoolean();

            Create.Table("Veiculo").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("MarcaId").AsInt32()
                .WithColumn("MarcaDescricao").AsString(200)
                .WithColumn("ModeloId").AsInt32()
                .WithColumn("ModeloDescricao").AsString(200)
                .WithColumn("Placa").AsString(20)
                .WithColumn("Ano").AsInt32()
                .WithColumn("ValorDeCompra").AsDouble()
                .WithColumn("Cor").AsInt32()
                .WithColumn("TipoCombustivel").AsInt32()
                .WithColumn("Ativo").AsBoolean();

            Create.Table("Marca").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Descricao").AsString(100);

            Insert.IntoTable("Marca").Row(new { Descricao = "Chevrolet" });
            Insert.IntoTable("Marca").Row(new { Descricao = "Volkswagen" });
            Insert.IntoTable("Marca").Row(new { Descricao = "Fiat" });

            Create.Table("Modelo").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Descricao").AsString(100)
                .WithColumn("MarcaId").AsInt32();

            Insert.IntoTable("Modelo").Row(new { Descricao = "Classic", MarcaId =  1});
            Insert.IntoTable("Modelo").Row(new { Descricao = "Onix", MarcaId = 1 });

            Insert.IntoTable("Modelo").Row(new { Descricao = "Gol", MarcaId = 2 });
            Insert.IntoTable("Modelo").Row(new { Descricao = "Fox", MarcaId = 2 });

            Insert.IntoTable("Modelo").Row(new { Descricao = "Uno", MarcaId = 3 });
            Insert.IntoTable("Modelo").Row(new { Descricao = "Argo", MarcaId = 3 });


        }
    }
}
