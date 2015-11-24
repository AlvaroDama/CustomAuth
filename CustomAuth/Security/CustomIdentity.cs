using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace CustomAuth.Security
{
    public class CustomIdentity : IIdentity
    {
        public string Name { get { return Login; } }
        public string AuthenticationType { get { return Identity.AuthenticationType; } }
        public bool IsAuthenticated { get { return Identity.IsAuthenticated; } }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        public string Email { get; set; }

        public string Rol { get; set; }

        public IIdentity Identity { get; set; }

        public CustomIdentity(IIdentity identity)
        {
            Identity = identity;
            var us = Membership.GetUser(identity.Name) as UsuarioMembership;
            Nombre = us.Nombre;
            Apellidos = us.Apellidos;
            Imagen = us.Imagen;
            Id = us.Id;
            Login = us.Login;
            Id = us.Id;
            Email = us.Email;
        }
    }
}
