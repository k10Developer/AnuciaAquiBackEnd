using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios
{
    public interface IAnuncioRepositorio
    {
        void Salvar(Anuncio anuncio);
        void Alterar(Anuncio anuncio);
        void Remover(int anuncioId);
        List<Anuncio> ObterTodos();
        Anuncio ObterPorId(int anuncioId);

    }
}
