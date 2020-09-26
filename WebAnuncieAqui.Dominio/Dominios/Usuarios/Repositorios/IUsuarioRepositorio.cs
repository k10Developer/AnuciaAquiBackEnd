using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuciaAqui.Dominio.Dominios.Usuarios
{
    public interface IUsuarioRepositorio
    {
        Usuario Autenticacao(string userName, string password);
        Usuario ObterUsuarioPorId(int id);
        List<Usuario> ObterTodos();
        List<Usuario> ObterTodos(string role);
        List<Usuario> ObterTodosPorEmail(string email);
        List<Usuario> ObterTodosPorValor(string valor);

        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        void Deletar(int id);
    }
}
