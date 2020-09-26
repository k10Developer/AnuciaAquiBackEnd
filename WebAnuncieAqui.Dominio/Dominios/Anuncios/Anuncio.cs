using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Veiculos;

namespace WebAnuncieAqui.Dominio.Dominios.Anuncios
{
    public class Anuncio
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public string DetalhesVeiculo { get; set; }
        public string  Titulo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime? DataDeCriacaoDoAnuncio { get; set; }
        public bool Ativo { get; set; }
        public bool? Finalizar { get; private set; }
        public void DataCriacao()
        {
            this.DataDeCriacaoDoAnuncio = DateTime.Now;
        }
        public void FinalizarAnuncio()
        {
            this.Finalizar = true;
        }
    }
     
}
