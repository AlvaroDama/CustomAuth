using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using CustomAuth.Models;
using CustomAuth.Utility;

namespace CustomAuth.Security
{
    public class UsuarioMembership : MembershipUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        public override string Email { get; set; }
        public string Rol { get; set; }

        public IIdentity Identity { get; set; }

        public UsuarioMembership(Usuario user)
        {
            var key = ConfigurationManager.AppSettings["ClaveCifrado"];
            Id = user.Id;
            Nombre = user.Nombre;
            Apellidos = user.Apellidos;
            Imagen = user.Imagen;
            Rol = user.Rol.Nombre;
            Email = SeguridadUtility.Decrypt(Convert.FromBase64String(user.Email), key);
            Login = user.Login;

        }
    }
}
