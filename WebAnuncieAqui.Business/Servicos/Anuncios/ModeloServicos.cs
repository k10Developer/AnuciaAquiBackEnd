using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;

namespace WebAnuncieAqui.Business.Servicos.Anuncios
{
    public class ModeloServicos : IModeloServicos
    {
        private IModeloRepositorio _repositorio;
        public ModeloServicos(IModeloRepositorio modeloRepositorio)
        {
            _repositorio = modeloRepositorio;
        }
  
        public void Alterar(Modelo modelo)
        {
            _repositorio.Alterar(modelo);
        }   
           
        public void Remover(int modelo)
        {
            _repositorio.Remover(modelo);
        }

        public void Salvar(Modelo modelo)
        {
            _repositorio.Salvar(modelo);
        }
    }
}
