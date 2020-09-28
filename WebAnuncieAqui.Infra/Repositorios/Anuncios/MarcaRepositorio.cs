using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAnuciaAqui.Infra;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio;
using WebAnuncieAqui.Infra.Repositorios.Veiculos;

namespace WebAnuncieAqui.Infra.Repositorios.Anuncios
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private WebAnuncieAquiContext _webAnuncieAquiContext;
        private IVeiculoRepositorio _repositorioVeiculo;
        public MarcaRepositorio(WebAnuncieAquiContext webAnuncieAquiContext, IVeiculoRepositorio veiculoRepositorio )
        {
            _webAnuncieAquiContext = webAnuncieAquiContext;
            _repositorioVeiculo = veiculoRepositorio;
        }
        public void Alterar(Marca marca)
        {
            _webAnuncieAquiContext.Entry<Marca>(marca).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _webAnuncieAquiContext.SaveChanges();
        }

        public Marca ObterPorId(int marcaId)
        {
            return _webAnuncieAquiContext.Marcas.Where(c => c.Id == marcaId).FirstOrDefault();
        }

        public List<Marca> ObterTodos()
        {
            return _webAnuncieAquiContext.Marcas.ToList();
        }

        public void Remover(int marca)
        {
            _webAnuncieAquiContext.Marcas.Remove(ObterPorId(marca));
            _webAnuncieAquiContext.SaveChanges();
        }

        public void Salvar(Marca marca)
        {
            _webAnuncieAquiContext.Marcas.Add(marca);
            _webAnuncieAquiContext.SaveChanges();
        }

        public bool VinculadoAAlgumCarro(int marcaId)
        {
            var result = _repositorioVeiculo.ObterTodos().Any(c => c.MarcaId == marcaId && c.Ativo);
            return result;
        }
    }
}
