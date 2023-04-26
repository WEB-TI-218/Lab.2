using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        public RequestResponceAction UserLoginAction(ULoginData data)
        {
            UDbTable user;
            using (var db = new UserContext())
            {
                user = new UDbTable
                {
                    Username = data.Credential,
                    Password = data.Password,
                    LastLogin = DateTime.Now,
                    Level = Domain.Entities.Enum.URole.USER,
                    Email = data.Email
                };
                db.Users.Add(user);
                db.SaveChanges();

            }

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Credential);
            }

            //if(user == null) 
            //{
            //    //throw new Exception();
            //    using (UserContext db = new UserContext())
            //    {
            //        //db.Users.Add(new UDbTable { Username = user.Username,Email = user.Email, Password = user.Password });
            //        //db.SaveChanges();

            //        //user = db.Users.Where(u => u.Email == user.Username && u.Password == user.Password).FirstOrDefault();
                  
            //    }

            //}

            using (var db = new UserContext())
            {
               var users = db.Users.Where(u => u.Level == Domain.Entities.Enum.URole.ADMINISTRATOR).ToList();
            }
            return new RequestResponceAction();
        }

    }
   
}
