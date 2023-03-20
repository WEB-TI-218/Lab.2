using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public RequestResponceAction UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }
    }
}
