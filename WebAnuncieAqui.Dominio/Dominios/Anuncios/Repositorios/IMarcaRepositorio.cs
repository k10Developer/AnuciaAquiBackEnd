using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios
{
    public interface IMarcaRepositorio
    {
        void Salvar(Marca marca);
        void Alterar(Marca marca);
        void Remover(int marca);
        List<Marca> ObterTodos();
        Marca ObterPorId(int marcaId);
    }
}
