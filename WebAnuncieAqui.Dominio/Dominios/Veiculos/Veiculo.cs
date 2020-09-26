using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;

namespace WebAnuncieAqui.Dominio.Dominios.Veiculos
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public string MarcaDescricao { get; set; }

        public int ModeloId { get; set; }
    public string  ModeloDescricao { get; set; }
    public string Placa { get; set; }
        public int Ano { get; set; }
        public double ValorDeCompra { get; set; }
        public ECor Cor { get; set; }
        public ETipoCombustivel TipoCombustivel { get; set; }
        public bool Ativo { get; set; }
    }

    public enum ECor
    {
        Branco = 1,
        Azul,
        Vermelho,
        Verde,
        Rosa,
        Amarelo
    }
    public enum ETipoCombustivel
    {
        Gasolina = 1,
        Etanol,
        Flex,
        CNV,
        Diesel
    }
}
