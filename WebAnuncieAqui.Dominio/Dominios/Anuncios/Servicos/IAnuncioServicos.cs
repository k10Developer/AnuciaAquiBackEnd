using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos
{
    public interface IAnuncioServicos
    {
        void FinalizarAnuncio(int anuncioId);
        void Salvar(Anuncio anuncio);
        void Alterar(Anuncio anuncio);
        void Remover(int anuncioId);
    }
}
