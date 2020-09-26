using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuciaAqui.Dominio.Dominios.Usuarios.Servicos
{
    public interface IUsuarioServico
    {
        Usuario Autenticacao(string userName, string password);
        void Adicionar(Usuario usuario, string passwordConfirm);
        void Alterar(Usuario usuario);
        void Deletar(int id);
    }
}
