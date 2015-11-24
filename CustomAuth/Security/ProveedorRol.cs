using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using CustomAuth.Models;
using CustomAuth.Utility;

namespace CustomAuth.Security
{
    public class ProveedorRol: RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var key = ConfigurationManager.AppSettings["ClaveCifrado"];
            var cif = SeguridadUtility.Encrypt(username, key);

            using (var db = new AutenticacionEntities())
            {
                try
                {
                    var us = db.Usuario.First(o => o.Login.Equals(cif));
                    return us.Rol.Nombre.Equals(roleName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }    
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            var key = ConfigurationManager.AppSettings["ClaveCifrado"];
            var cif = SeguridadUtility.Encrypt(username, key);

            using (var db = new AutenticacionEntities())
            {
                try
                {
                    var us = db.Usuario.First(o => o.Login.Equals(cif));
                    return new[] { us.Rol.Nombre };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
