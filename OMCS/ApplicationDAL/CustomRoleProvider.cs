using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OMCS.DAL.Model;

namespace OMCS.DAL
{
    class CustomRoleProvider
    {
        readonly OMCSDBContext Context = new OMCSDBContext();

        public void CreateRole(string roleName, string description)
        {
            Role Role = null;
            Role = Context.Roles.FirstOrDefault(Rl => Rl.RoleName == roleName);
            if (Role == null)
            {
                Role NewRole = new Role
                {
                    RoleName = roleName,
                    Description = description
                };
                Context.Roles.Add(NewRole);
                Context.SaveChanges();
            }
        }
        public void AddUserToRole(string userName, string roleName)
        {
            User user = Context.Users.Where(Usr => userName.Contains(Usr.Username)).FirstOrDefault();
            Role role = Context.Roles.Where(Rl => roleName.Contains(Rl.RoleName)).FirstOrDefault();

            if (!user.Roles.Contains(role))
            {
                user.Roles.Add(role);
                Context.SaveChanges();
            }

        }

        public bool DeleteRole(string roleName)
        {
            Role Role = null;
            Role = Context.Roles.FirstOrDefault(Rl => Rl.RoleName == roleName);
            if (Role != null)
            {
                Role.Users.Clear();
                Context.Roles.Remove(Role);
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<string> GetAllRoles()
        {
            return Context.Roles.Select(Rl => Rl.RoleName).ToList();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            User User = Context.Users.FirstOrDefault(Usr => Usr.Username == username);
            Role Role = Context.Roles.FirstOrDefault(Rl => Rl.RoleName == roleName);

            if (Role == null && User != null)
            {
                return User.Roles.Contains(Role);
            }
            return false;
        }
    }
}