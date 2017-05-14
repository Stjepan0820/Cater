using Cater.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cater.DAL
{
    
    public class UserInfoDAL
    {
        /// <summary>
        /// 根据用户输入的账号去数据库中查询该账号的所有信息
        /// </summary>
        /// <param name="loginUserName">登录名</param>
        /// <returns>用户对象</returns>
        public UserInfo GetUserInfoByLoginUserName(string loginUserName)
        {
            string sql = "select * from UserInfo where DelFlag=0 and LoginUserName=@LoginUserName";
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql, new System.Data.SQLite.SQLiteParameter("@LoginUserName", loginUserName));
            UserInfo user = null;
            //判断是否有数据
            if (dt.Rows.Count>0)
            {
                user = RowToUserInfo(dt.Rows[0]);
            }
            return user;
        }
        //把关系型的数据转成对象的方式
        private UserInfo RowToUserInfo(DataRow dataRow)
        {
            UserInfo user = new UserInfo();
            user.LoginUserName = dataRow["LoginUserName"].ToString();
            user.PWd = dataRow["Pwd"].ToString();
            return user;
        }
    }
}
