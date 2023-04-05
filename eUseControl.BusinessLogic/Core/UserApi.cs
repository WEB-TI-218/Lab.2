using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Username = "Serghei123456",
                    Password = "dow158ciewhsa",
                    LastLogin = DateTime.Now,
                    Level = Domain.Entities.Enum.URole.ADMINISTRATOR,
                    Email = "info1@mail.ru"
                };  
                db.Users.Add(user);
                db.SaveChanges();
            }

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Credential);
            }

            if(user == null) 
            {
                throw new Exception();
            }

            using (var db = new UserContext())
            {
               var users = db.Users.Where(u => u.Level == Domain.Entities.Enum.URole.ADMINISTRATOR).ToList();
            }
            return new RequestResponceAction();
        }

    }
   
}
