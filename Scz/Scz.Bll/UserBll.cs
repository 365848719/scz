using Scz.IBll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.Bll
{
   public class UserBll : IUserBLL,IPeopleBLL
    {
        public string GetUserInfo()
        {
            return "scz 的用户信息 ";
        }

        public string Introduce()
        {
            return "my name is scz ";
        }
    }
}
