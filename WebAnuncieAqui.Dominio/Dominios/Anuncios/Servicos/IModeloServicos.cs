using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos
{
    public interface IModeloServicos
    {
        void Salvar(Modelo modelo);
        void Alterar(Modelo modelo);
        void Remover(int modelo);
    }
}
