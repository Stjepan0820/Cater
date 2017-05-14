using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cater.Model
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginUserName { get; set; }
        public string PWd { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public int DelFlag { get; set; }
        public DateTime SubTime { get; set; }
    }
}
