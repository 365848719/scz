using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.Bll
{
   public class RoleBll : IBll.IRoleBLL
    {
        public string ShowDIDemo()
        {
            return "我是管理员角色";
        }

        public string ShowRoleInfo()
        {
            return $"哈哈,{ShowDIDemo()}";
        }
    }
}
