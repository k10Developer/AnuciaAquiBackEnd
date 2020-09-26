using WebAnuciaAqui.Auxiliar;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuciaAqui.Infra.Migrations
{
    [Migration(202003271417)]
    public class _202003271417_Cricacao_Tabela_Usuario : Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {

            Create.Table("Usuarios")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("UserName").AsString(100)
                .WithColumn("Password").AsString(200)
                .WithColumn("Role").AsString(100)
                .WithColumn("Email").AsString(100);

            Insert.IntoTable("Usuarios").Row(new { UserName = "Kennedy" , Password = Cryptograph.ComputeHashSh1("manager"), Role = "manager", Email = "kennedycbkcs@hotmail.com"});
        }
    }
}
