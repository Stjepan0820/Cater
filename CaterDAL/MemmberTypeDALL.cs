using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.Model;
using System.Data;

namespace Cater.DAL
{
    public class MemmberTypeDALL
    {
        /// <summary>
        /// 根据删除标识查询所有的会员等级信息
        /// </summary>
        /// <param name="delFlag">删标识</param>
        /// <returns></returns>
        public List<MemmberType> GetAllMemmeberTypeByDelFlag(int delFlag)
        {
            string sql = "select * from MemmberType where DelFlag=" + delFlag;
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            List<MemmberType> list = new List<MemmberType>();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow  dr in dt.Rows)
                {
                    list.Add(RowToMemmberType(dr));
                }
            }
            return list;
        }

        private MemmberType RowToMemmberType(DataRow dr)
        {
            MemmberType mt = new MemmberType();
            mt.MemTpDesc = dr["MemTpDesc"].ToString();
            mt.MemTpName = dr["MemTpName"].ToString();
            mt.MemType = Convert.ToInt32(dr["MemType"]);
            mt.SubBy = Convert.ToInt32(dr["SubBy"]);
            return mt;

        }
    }
}
