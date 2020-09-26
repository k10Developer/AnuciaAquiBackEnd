using WebAnuciaAqui.Auxiliar;
using WebAnuciaAqui.Dominio.Dominios.Usuarios;
using WebAnuciaAqui.Dominio.Dominios.Usuarios.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Auxiliar.Mensagens;

namespace WebAnuciaAqui.Business.Servicos.Usuarios
{
    public class UsuarioServico : IUsuarioServico
    {
        private IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public void Adicionar(Usuario usuario, string passwordConfirm)
        {
            if (!usuario.Password.Equals(passwordConfirm))
                throw new Exception(Erro.SenhasNaoCombinam);
            usuario.Password = Cryptograph.ComputeHashSh1(usuario.Password);
            _usuarioRepositorio.Adicionar(usuario);
        }

        public void Alterar(Usuario usuario)
        {
            _usuarioRepositorio.Alterar(usuario);
        }

        public Usuario Autenticacao(string userName, string password)
        {
           return _usuarioRepositorio.Autenticacao(userName,password);
        }

        public void Deletar(int id)
        {
            _usuarioRepositorio.Deletar(id);
        }
    }
}
