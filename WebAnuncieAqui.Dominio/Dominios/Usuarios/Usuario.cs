using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuciaAqui.Dominio.Dominios.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
