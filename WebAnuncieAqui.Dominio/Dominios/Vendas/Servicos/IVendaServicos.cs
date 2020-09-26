using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Vendas.Servicos
{
    public interface IVendaServicos
    {
        void Salvar(Venda venda);
        void Alterar(Venda venda);
        void Remover(int vendaId);
    }
}
