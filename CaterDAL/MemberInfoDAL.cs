using Cater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Cater.DAL
{ 
    public class MemberInfoDAL
    {




        /// <summary>
        /// 根据会员的id查询该会员信息
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>会员对象</returns>
        public  MemberInfo GetMemmberInfoByMemmberId(int memmberId)
        {
            string sql = "select * from MemmberInfo where DelFlag=0 and MemmberId=" + memmberId;
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            MemberInfo mem = null;
            if (dt.Rows.Count>0)
            {
                mem = RowToMemberInfo(dt.Rows[0]);

            }
            return mem;
        }
        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="memberid">会员的id</param>
        /// <returns>受影响的行数</returns>
        public int SoftDeleteMemberInfoByNumberId(int memberid)
        {
            string sql = "update MemmberInfo set DelFlag=1 where MemmberId=" + memberid;
            return SqlHelperSqlite.ExecuteNonQuery(sql);
        }






        /// <summary>
        /// 根据删除标识查询所有的会员信息
        /// </summary>
        /// <param name="delFlag">删除标识0表示没删除，1表示删除</param>
        /// <returns>会员信息集合（对象）</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            string sql = "select * from MemmberInfo where DelFlag=" + delFlag;
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            //创建一个集合存所有的会员对象
            List<MemberInfo> list = new List<MemberInfo>();
            if (dt.Rows.Count>0)//判断是否有数据
            {
                //遍历所有的行
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberInfo(dr));
                }

            }
            return list;
        }

        private MemberInfo RowToMemberInfo(DataRow dr)
        {
            MemberInfo m = new MemberInfo();
            m.MemberAddress = dr["MemAddress"].ToString();
            m.MemberBirthday = Convert.ToDateTime(dr["MemBirthdaty"]);
            m.MemberDiscount = Convert.ToDecimal(dr["MemDiscount"]);
            m.MemberEndServerTime = Convert.ToDateTime(dr["MemEndServerTime"]);
            m.MemberGender = dr["MemGender"].ToString();
            m.MemberIntegral = Convert.ToDecimal(dr["MemIntegral"]);
            m.MemberId = Convert.ToInt32(dr["MemmberId"]);
            m.MemberMobilePhone = dr["MemMobilePhone"].ToString();
            m.MemberMoney = Convert.ToDecimal(dr["MemMoney"]);
            m.MemberName = dr["MemName"].ToString();
            m.MemberNum = dr["MemNum"].ToString();
            m.MemberType = Convert.ToInt32(dr["MemType"]);
            m.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return m;
        }
    }
}
