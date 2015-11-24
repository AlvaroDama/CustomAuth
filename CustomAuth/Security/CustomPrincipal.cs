using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CustomAuth.Security
{
    public class CustomPrincipal:IPrincipal
    {
        
        public IIdentity Identity { get; private set; }

        public CustomIdentity MyCustomIdentity
        {
            get { return (CustomIdentity) Identity; } 
            set { Identity = value; }
        }

        public CustomPrincipal(CustomIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            return MyCustomIdentity.Rol == role;
        }
    }
}
