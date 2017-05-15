using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cater.Model
{
    public class MemberInfo
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberMobilePhone { get; set; }
        public string MemberAddress { get; set; }
        public int MemType { get; set; }
        public string MemberGender { get; set; }
        public decimal MemberDiscount { get; set; }
        public decimal MemberMoney { get; set; }
        public int DelFlag { get; set; }
        public DateTime SubTime { get; set; }
        public decimal MemberIntegral { get; set; }
        public DateTime MemberEndServerTime { get; set; }
        public DateTime MemberBirthday { get; set; }
        public string MemberNum { get; set; }
    }
}
 