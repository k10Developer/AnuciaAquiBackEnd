using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Vendas
{
    public class RelatorioVenda
    {
        public string Veiculo { get; set; }
        public DateTime DataDaVenda { get; set; }
        public double Lucro { get; set; }
    }
}
