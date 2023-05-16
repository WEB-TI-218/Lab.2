using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        //public RequestResponceAction UserLoginAction(ULoginData data)
        //{
        //    UDbTable result;
        //    var validate = new EmailAddressAttribute();
        //    if (validate.IsValid(data.Credential))
        //    {
        //        var pass = LoginHelpers.HashGen(data.Password);
        //        using (var db = new UserContext())
        //        {
        //            result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
        //        }

        //        if (result == null)
        //        {
        //            return new RequestResponceAction { Status = false, StatusMsg = "The Username or Password is incorrect." };
        //        }

        //        using (var todo = new UserContext())
        //        {
        //            result.LasIp = data.LoginIP;
        //            result.LastLogin = data.LoginDateTime;
        //            todo.Entry(result).State = EntityState.Modified;
        //            todo.SaveChanges();
        //        }
        //        return new RequestResponceAction { Status = true };
        //    }

        //    return new RequestResponceAction { Status = false };
        //}
        //public RequestResponceAction UserRegisterAction(ULoginData data)
        //{
        //    UDbTable user;

        //    ////ToDo
        //    ///check if user and email dosent exist in Db


        //    using (var db = new UserContext())
        //    {
        //        user = new UDbTable
        //        {
        //            Username = data.Credential,
        //            Password = LoginHelpers.HashGen(data.Password),
        //            LastLogin = DateTime.Now,
        //            Level = Domain.Entities.Enum.URole.USER,
        //            Email = data.Email
        //        };
        //        db.Users.Add(user);
        //        db.SaveChanges();

        //    }

        //    using (var db = new UserContext())
        //    {
        //        user = db.Users.FirstOrDefault(u => u.Username == data.Credential);
        //    }



        //    using (var db = new UserContext())
        //    {
        //        var users = db.Users.Where(u => u.Level == Domain.Entities.Enum.URole.ADMINISTRATOR).ToList();
        //    }

        //    ////ToDo
        //    ///return status of registration

        //    return new RequestResponceAction();
        //}

        public RequestResponceAction UserRegisterAction(ULoginData data)
        {
            UDbTable user;

            using (var db = new UserContext())
            {
                bool userExists = db.Users.Any(u => u.Username == data.Credential);
                bool emailExists = db.Users.Any(u => u.Email == data.Email);

                if (userExists || emailExists)
                {
                    return new RequestResponceAction { Status = false, StatusMsg = "Userlogin or Email Already Exists" };
                }
                else
                {
                    user = new UDbTable
                    {
                        Username = data.Credential,
                        Password = LoginHelpers.HashGen(data.Password),
                        LastLogin = DateTime.Now,
                        Level = Domain.Entities.Enum.URole.USER,
                        Email = data.Email
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Credential);
            }

            using (var db = new UserContext())
            {
                var users = db.Users.Where(u => u.Level == Domain.Entities.Enum.URole.ADMINISTRATOR).ToList();
            }

            return new RequestResponceAction { StatusMsg = "Registration successful" };
        }

        internal RequestResponceAction UserLoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelpers.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new RequestResponceAction { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIP;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new RequestResponceAction { Status = true };
            }
            else
            {
                var pass = LoginHelpers.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new RequestResponceAction { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIP;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new RequestResponceAction { Status = true };
            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            var userminimal = new UserMinimal
            {
                Id = curentUser.Id,
                Email = curentUser.Email,
                LasIp = curentUser.LasIp,
                LastLogin = curentUser.LastLogin,
                Level = curentUser.Level,
                Username = curentUser.Username
            };

            return userminimal;
        }
    }
}
