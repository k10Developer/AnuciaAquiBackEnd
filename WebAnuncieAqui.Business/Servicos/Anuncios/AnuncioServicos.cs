using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;

namespace WebAnuncieAqui.Business.Servicos.Anuncios
{
    public class AnuncioServicos : IAnuncioServicos
    {
        private IAnuncioRepositorio _repositorio;
        public AnuncioServicos(IAnuncioRepositorio anuncioRepositorio)
        {
            _repositorio = anuncioRepositorio;
        }
        public void Alterar(Anuncio anuncio)
        {
            _repositorio.Alterar(anuncio);
        }

        public void FinalizarAnuncio(int anuncioId)
        {
            var anuncio = _repositorio.ObterPorId(anuncioId);
            anuncio.FinalizarAnuncio();
            Alterar(anuncio);
        }

        public void Remover(int anuncioId)
        {
            _repositorio.Remover(anuncioId);
        }

        public void Salvar(Anuncio anuncio)
        {
            _repositorio.Salvar(anuncio);
        }
    }
}
