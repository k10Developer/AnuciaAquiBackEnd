using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAnuciaAqui.Infra;
using WebAnuncieAqui.Dominio.Dominios.Vendas;
using WebAnuncieAqui.Dominio.Dominios.Vendas.Repositorio;
using WebAnuncieAqui.Infra.Helpers;

namespace WebAnuncieAqui.Infra.Repositorios.Vendas
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private WebAnuncieAquiContext _webAnuncieAquiContext;

        public VendaRepositorio(WebAnuncieAquiContext webAnuncieAquiContext)
        {
            _webAnuncieAquiContext = webAnuncieAquiContext;
        }
        public void Alterar(Venda venda)
        {
            _webAnuncieAquiContext.Entry<Venda>(venda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _webAnuncieAquiContext.SaveChanges();
        }

        public Venda ObterPorAnuncioId(int anuncioId)
        {
            return _webAnuncieAquiContext.Vendas.Where(c => c.AnuncioId == anuncioId).FirstOrDefault();
        }

        public Venda ObterPorId(int vendaId)
        {
            return _webAnuncieAquiContext.Vendas.Where(c => c.Id == vendaId && c.Ativo).FirstOrDefault();
        }

        public List<Venda> ObterTodos()
        {
            return _webAnuncieAquiContext.Vendas.ToList();
        }

        public List<RelatorioVenda> ObterVendasPorPeriodo(DateTime dataInical, DateTime dataFinal)
        {
            if (dataInical == dataFinal)
                dataFinal = dataFinal.Date.AddHours(23).AddMinutes(59);
            var sql = $@"
                         select 
                               ([Ve].[MarcaDescricao] || ' ' || [Ve].[ModeloDescricao] || ' ' || [Ve].[Placa]) as [Veiculo],
                               [V].[DataDaVenda] as [DataDaVenda],
                               ([V].[ValorDeVenda] - [Ve].[ValorDeCompra]) as [Lucro]
                         from [Venda] as [V]
                         inner join [Anuncio] as [A] on [V].[AnuncioId] = [A].[Id]
                         inner join [Veiculo] as [Ve] on [A].[VeiculoId] = [Ve].[Id]
                         where [V].[DataDaVenda] between '{dataInical}' and '{dataFinal}'
                     ".TSQLToAnsi();

            var result = _webAnuncieAquiContext.RelatorioVendas.FromSqlRaw<RelatorioVenda>(sql).ToList();

            return result;
        }

        public void Remover(int vendaId)
        {
            var venda = ObterPorId(vendaId);
            venda.Ativo = false;
            Alterar(venda);
        }

        public void Salvar(Venda venda)
        {
            _webAnuncieAquiContext.Vendas.Add(venda);
            _webAnuncieAquiContext.SaveChanges();
        }
    }
}
