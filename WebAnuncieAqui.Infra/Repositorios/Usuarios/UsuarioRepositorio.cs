using WebAnuciaAqui.Dominio.Dominios.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAnuciaAqui.Infra.Repositorios.Usuarios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private WebAnuncieAquiContext _webAnuncieAquiContext;
        public UsuarioRepositorio(WebAnuncieAquiContext webAnuncieAquiContext)
        {
            _webAnuncieAquiContext = webAnuncieAquiContext;
        }
        public void Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Autenticacao(string userName, string password)
        {
            return _webAnuncieAquiContext.Usuarios.Where(c => c.UserName.ToLower().Equals(userName.ToLower())).FirstOrDefault();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObterTodos(string role)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObterTodosPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObterTodosPorValor(string valor)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
