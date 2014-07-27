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


        public bool CreateUser(string password, string email)
        {

            try
            {
                User NewUser = new User
                {
                    Password = password,
                    Email = email,
                    CreatedDate = DateTime.UtcNow,
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

        public  bool ValidateUser(string email, string password)
        {
            User User = null;
            User = Context.Users.FirstOrDefault(Usr => Usr.Email == email && Usr.Password == password);

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
            User = Context.Users.FirstOrDefault(Usr => Usr.Email == username);
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