using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAnuciaAqui.Infra;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;

namespace WebAnuncieAqui.Infra.Repositorios.Anuncios
{
    public class AnuncioRepositorio : IAnuncioRepositorio
    {
        private WebAnuncieAquiContext _webAnuncieAquiContext;

        public AnuncioRepositorio(WebAnuncieAquiContext webAnuncieAquiContext)
        {
            _webAnuncieAquiContext = webAnuncieAquiContext;
        }
        public void Alterar(Anuncio anuncio)
        {
            _webAnuncieAquiContext.Entry<Anuncio>(anuncio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _webAnuncieAquiContext.SaveChanges();
        }

        public Anuncio ObterPorId(int anuncioId)
        {
            return _webAnuncieAquiContext.Anuncios.Where(c => c.Id == anuncioId && c.Ativo).FirstOrDefault();
        }

        public List<Anuncio> ObterTodos()
        {
            return _webAnuncieAquiContext.Anuncios.Where(c=> c.Ativo).ToList();
        }

        public void Remover(int anuncioId)
        {
            var anuncio = ObterPorId(anuncioId);
            anuncio.Ativo = false;
            Alterar(anuncio);
        }

        public void Salvar(Anuncio anuncio)
        {
            _webAnuncieAquiContext.Anuncios.Add(anuncio);
            _webAnuncieAquiContext.SaveChanges();
        }
    }
}
