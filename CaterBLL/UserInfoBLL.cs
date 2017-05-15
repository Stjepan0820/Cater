using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.DAL;
using Cater.Model; 
namespace Cater.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();
        /// <summary>
        /// 根据用户的账号和密码判断是否登录成功
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="pwd">登录的密码</param>
        /// <param name="msg">返回的信息</param>
        /// <returns>如果返回true则登录成功，如果为false则登录失败</returns>
        public bool GetUserInfoByLoginUserNameAndPwd(string loginName,string pwd, out string msg)
        {
            //获取该用户的信息
            UserInfo user = dal.GetUserInfoByLoginUserName(loginName);
            if (user!=null)
            {
                if (user.PWd==pwd)
                {
                    msg = "登录成功";
                    return true;
                }
                else
                {
                    msg = "登录失败";
                    return false;
                }
            }
            else
            {
                msg = "用户不存在";
                return false;
            }
        }
    }
}
