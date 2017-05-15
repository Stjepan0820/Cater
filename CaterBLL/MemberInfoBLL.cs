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
        /// 新增或修改会员信息
        /// </summary>
        /// <param name="mem">会员对象</param>
        /// <param name="temp">1：新增|2：修改</param>
        /// <returns>成功还是失败</returns>
        public bool SaveMemmberInfo(MemberInfo mem,int temp)
        {
            int r = -1;
            if (temp==1)
            {
                r = dal.AddMemmberInfo(mem);
            }
            else if (temp==2)
            {
                r = dal.UpdateMemmberInfo(mem);
            }
            return r > 0;
        }











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
