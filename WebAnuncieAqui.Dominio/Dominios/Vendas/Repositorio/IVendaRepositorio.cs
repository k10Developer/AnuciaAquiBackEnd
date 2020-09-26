using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Vendas.Repositorio
{
    public interface IVendaRepositorio
    {
        void Salvar(Venda venda);
        void Alterar(Venda venda);
        void Remover(int vendaId);
        List<Venda> ObterTodos();
        List<RelatorioVenda> ObterVendasPorPeriodo(DateTime dataInical, DateTime dataFinal);
        Venda ObterPorId(int vendaId);


    }
}
