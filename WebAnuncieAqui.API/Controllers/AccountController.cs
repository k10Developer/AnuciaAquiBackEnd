using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAnuciaAqui.API.Servicos;
using WebAnuciaAqui.Auxiliar;
using WebAnuciaAqui.Dominio.Dominios.Usuarios;
using WebAnuciaAqui.Dominio.Dominios.Usuarios.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAnuncieAqui.Auxiliar.Mensagens;

namespace WebAnuciaAqui.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IUsuarioServico _usuarioServico;
        public AccountController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            try
            {
                if (model == null || model.UserName == null || model.Password == null)
                    throw new Exception(Erro.DadosDePequisaInvalidos);
                var password = Cryptograph.ComputeHashSh1(model.Password);
                var user = _usuarioServico.Autenticacao(model.UserName, password);

                if (user == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = TokenService.GenerateToken(user);
                user.Password = "";
                return Ok( new
                {
                    user = user,
                    token = token
                });
            }
            catch (Exception ex)
            {
               return NotFound(new { message = ex.Message });
            }
            
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}