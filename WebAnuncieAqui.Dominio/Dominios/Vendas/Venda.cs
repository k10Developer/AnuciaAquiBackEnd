using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Vendas
{
    public class Venda
    {
        public int Id { get; set; }
        public int AnuncioId { get; set; }
        public string DetalheAnuncio { get; set; }
        public double ValorDeVenda { get; set; }
        public DateTime DataDaVenda { get; set; }
        public bool Ativo { get; set; }

        public void DataDeVenda()
        {
            this.DataDaVenda = DateTime.Now;
        }

    }
}
