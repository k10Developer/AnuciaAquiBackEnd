using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAnuciaAqui.Infra;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio;

namespace WebAnuncieAqui.Infra.Repositorios.Anuncios
{
    public class ModeloRepositorio : IModeloRepositorio
    {
        private WebAnuncieAquiContext _webAnuncieAquiContext;
        private IVeiculoRepositorio _repositorioVeiculo;
        public ModeloRepositorio(WebAnuncieAquiContext webAnuncieAquiContext, IVeiculoRepositorio veiculoRepositorio)
        {
            _webAnuncieAquiContext = webAnuncieAquiContext;
            _repositorioVeiculo = veiculoRepositorio;
        }
        public void Alterar(Modelo modelo)
        {
            _webAnuncieAquiContext.Entry<Modelo>(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _webAnuncieAquiContext.SaveChanges();
        }

        public Modelo ObterPorId(int modeloId)
        {
            return _webAnuncieAquiContext.Modelos.Where(c => c.Id == modeloId).FirstOrDefault();
        }

        public List<Modelo> ObterTodos()
        {
            return _webAnuncieAquiContext.Modelos.ToList();
        }

        public List<Modelo> ObterTodosPorMarca(int marcaId)
        {
            return _webAnuncieAquiContext.Modelos.Where(c=> c.MarcaId == marcaId).ToList();
        }

        public void Remover(int modelo)
        {
            _webAnuncieAquiContext.Modelos.Remove(ObterPorId(modelo));
            _webAnuncieAquiContext.SaveChanges();
        }

        public void Salvar(Modelo modelo)
        {
            _webAnuncieAquiContext.Modelos.Add(modelo);
            _webAnuncieAquiContext.SaveChanges();
        }

        public bool VinculadoAAlgumCarro(int modeloId)
        {
            var result = _repositorioVeiculo.ObterTodos().Any(c => c.ModeloId == modeloId && c.Ativo);
            return result;
        }
    }
}
