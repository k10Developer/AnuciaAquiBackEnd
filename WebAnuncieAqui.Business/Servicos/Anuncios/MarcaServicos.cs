using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;

namespace WebAnuncieAqui.Business.Servicos.Anuncios
{
    public class MarcaServicos : IMarcaServicos
    {
        private IMarcaRepositorio _repositorio;
        public MarcaServicos(IMarcaRepositorio marcaRepositorio)
        {
            _repositorio = marcaRepositorio;
        }
        public void Alterar(Marca marca)
        {
            _repositorio.Alterar(marca);
        }

        public void Remover(int marca)
        {
            _repositorio.Remover(marca);
        }

        public void Salvar(Marca marca)
        {
            _repositorio.Salvar(marca);
        }
    }
}
