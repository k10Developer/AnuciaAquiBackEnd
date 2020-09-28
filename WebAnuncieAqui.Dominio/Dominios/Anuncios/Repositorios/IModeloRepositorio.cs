using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios
{
    public interface IModeloRepositorio
    {
        void Salvar(Modelo modelo);
        void Alterar(Modelo modelo);
        void Remover(int modelo);
        List<Modelo> ObterTodos();
        List<Modelo> ObterTodosPorMarca(int marcaId);
        Modelo ObterPorId(int modeloId);

        bool VinculadoAAlgumCarro(int modeloId);
    }
}
