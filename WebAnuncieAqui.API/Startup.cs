using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebAnuciaAqui.Business.Servicos.Usuarios;
using WebAnuciaAqui.Dominio.Dominios.Usuarios;
using WebAnuciaAqui.Dominio.Dominios.Usuarios.Servicos;
using WebAnuciaAqui.Infra;
using WebAnuciaAqui.Infra.BancoDeDados;
using WebAnuciaAqui.Infra.Repositorios.Usuarios;
using WebAnuncieAqui.Business.Servicos.Anuncios;
using WebAnuncieAqui.Business.Servicos.Veiculos;
using WebAnuncieAqui.Business.Servicos.Vendas;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Servicos;
using WebAnuncieAqui.Dominio.Dominios.Vendas.Repositorio;
using WebAnuncieAqui.Dominio.Dominios.Vendas.Servicos;
using WebAnuncieAqui.Infra.Repositorios.Anuncios;
using WebAnuncieAqui.Infra.Repositorios.Veiculos;
using WebAnuncieAqui.Infra.Repositorios.Vendas;

namespace WebAnuciaAqui.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            ConfigureToken(services);
            RegisterInterfaces(services);
        }

        private void RegisterInterfaces(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            services.AddEntityFrameworkNpgsql().AddDbContext<WebAnuncieAquiContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DBWebAnuciaAqui")));
            var connectionstring = ConfigurationExtensions.GetConnectionString(configuration, "DBWebAnuciaAqui");
            var dbType = configuration.GetValue<int>("DbType");
            var serverInfo = new ServerInformation((DbType)dbType, connectionstring);
            CreateDataBase(serverInfo);
            RumMigrations(services, connectionstring, serverInfo.DatabaseType);

            Register(services, serverInfo);
        }

        private void Register(IServiceCollection services, ServerInformation serverInfo)
        {
            services.AddTransient<IDatabaseFactory, DatabaseFactory>();
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IAnuncioServicos, AnuncioServicos>();
            services.AddTransient<IAnuncioRepositorio, AnuncioRepositorio>();
            services.AddTransient<IModeloServicos, ModeloServicos>();
            services.AddTransient<IModeloRepositorio, ModeloRepositorio>();
            services.AddTransient<IMarcaServicos, MarcaServicos>();
            services.AddTransient<IMarcaRepositorio, MarcaRepositorio>();
            services.AddTransient<IVendaServicos, VendaServicos>();
            services.AddTransient<IVendaRepositorio, VendaRepositorio>();
            services.AddTransient<IVeiculoServicos, VeiculoServicos>();
            services.AddTransient<IVeiculoRepositorio, VeiculosRepositorio>();
            services.AddScoped<IDatabaseFactory>(options => new DatabaseFactory(serverInfo));

        }

        private void RumMigrations(IServiceCollection services, string connectionstring, DbType dbType)
        {
            // Logging is the replacement for the old IAnnouncer
            services.AddLogging(lb => lb.AddFluentMigratorConsole())
            // Registration of all FluentMigrator-specific services
            .AddFluentMigratorCore();

            if (dbType == DbType.SqlServer)
                services.ConfigureRunner(
                b => b
                    // Use SQLite
                    .AddSqlServer2012()
                    // The SQLite connection string
                    .WithGlobalConnectionString(connectionstring)
                    // Specify the assembly with the migrations
                    .ScanIn(typeof(DatabaseFactory).Assembly).For.Migrations());
            else if (dbType == DbType.SAPHana)
            {
                services.ConfigureRunner(
                b => b
                    .AddHana()
                    .WithGlobalConnectionString(connectionstring)
                    .WithMigrationsIn(typeof(ServerInformation).Assembly));
            }
            else if (dbType == DbType.Postgress)
            {
                services.ConfigureRunner(
                    b => b.AddPostgres()
                    .WithGlobalConnectionString(connectionstring)
                    .ScanIn(typeof(DatabaseFactory).Assembly).For.Migrations()
                );
            }

            var serviceProvider = services.BuildServiceProvider();
            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                // Instantiate the runner                
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                // Execute the migrations
                runner.MigrateUp();
            }
        }

        private void CreateDataBase(ServerInformation serverInfo)
        {
            var dbCreate = new PostgreSQLCreator(serverInfo);
            dbCreate.Createdatabase();
        }

        private static void ConfigureToken(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c =>
            {
                c.RequireHttpsMetadata = false;
                c.SaveToken = true;
                c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Active Service");
            //});
        }
    }
}
