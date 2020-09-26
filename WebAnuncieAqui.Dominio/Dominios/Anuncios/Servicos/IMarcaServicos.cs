using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos
{
    public interface IMarcaServicos
    {
        void Salvar(Marca marca);
        void Alterar(Marca marca);
        void Remover(int marca);
    }
}
