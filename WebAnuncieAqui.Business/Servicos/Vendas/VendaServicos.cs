using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio;
using WebAnuncieAqui.Dominio.Dominios.Vendas;
using WebAnuncieAqui.Dominio.Dominios.Vendas.Repositorio;
using WebAnuncieAqui.Dominio.Dominios.Vendas.Servicos;

namespace WebAnuncieAqui.Business.Servicos.Vendas
{
    public class VendaServicos : IVendaServicos
    {
        private IVendaRepositorio _repositorio;
        public VendaServicos(IVendaRepositorio vendaRepositorio)
        {
            _repositorio = vendaRepositorio;
        }
        public void Alterar(Venda venda)
        {
            _repositorio.Alterar(venda);
        }

        public void Remover(int vendaId)
        {
            _repositorio.Remover(vendaId);
        }

        public void Salvar(Venda venda)
        {
            _repositorio.Salvar(venda);
        }
    }
}
