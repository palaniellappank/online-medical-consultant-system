using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMCS.DAL.Model;

namespace OMCS.DAL
{
    public class CustomMembershipProvider
    {
        readonly OMCSDBContext Context = new OMCSDBContext();


        public bool CreateUser(string username, string password, string email)
        {

            try
            {
                User NewUser = new User
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    CreateDate = DateTime.UtcNow,
                };

                Context.Users.Add(NewUser);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public  bool ValidateUser(string username, string password)
        {
            User User = null;
            User = Context.Users.FirstOrDefault(Usr => Usr.Username == username && Usr.Password == password);

            if (User != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  bool DeleteUser(string username)
        {
            User User = null;
            User = Context.Users.FirstOrDefault(Usr => Usr.Username == username);
            if (User != null)
            {
                Context.Users.Remove(User);
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}