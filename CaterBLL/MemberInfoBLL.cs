using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.DAL;
using Cater.Model;

namespace Cater.BLL
{
    public class MemberInfoBLL
    {
        MemberInfoDAL dal = new MemberInfoDAL();

        /// <summary>
        /// 根据会员的id查询该会员信息
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>会员对象</returns>
        public MemberInfo GetMemmberInfoMemmberId(int memmberid)
        {
            return dal.GetMemmberInfoByMemmberId(memmberid);
        }




        /// <summary>
        /// 根据删除标识查询所有的会员信息
        /// </summary>
        /// <param name="memmberId">删除标识0---没删除,1---删除</param>
        /// <returns>会员信息集合(对象)</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int memmberId)
        {
            return dal.GetAllMemberInfoByDelFlag(memmberId);
        }
        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="memmberId">会员的id</param>
        /// <returns>受影响的行数</returns>
        public bool SoftDeleteMemberInfoByNumberId(int memberid)
        {
            return dal.SoftDeleteMemberInfoByNumberId(memberid) > 0;
        }
    }
}
