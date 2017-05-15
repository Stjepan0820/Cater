using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.Model;
using System.Data;

namespace Cater.DAL
{
    public class CategoryInfoDAL
    {
        /// <summary>
        /// 根据商品类别的id查该商品类别信息
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public CategoryInfo GetCategoryInfoCatId(int catId)
        {
            string sql = "select * from CategoryInfo where DelFlag=0 and CatId=" + catId;
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            CategoryInfo ct = null;
            if (dt.Rows.Count>0)
            {
                ct = RowtoCategoryInfo(dt.Rows[0]);
            }
            return ct;
        }
        /// <summary>
        /// 根据删除标识查询所有商品类别信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<CategoryInfo> GetAllCategoryInfoDelFlag(int delFlag)
        {
            string sql = "select * from CategoryInfo where DelFlag=" + delFlag;
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            List<CategoryInfo> list = new List<CategoryInfo>();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowtoCategoryInfo(dr));
                }
            }
            return list;
        }

        private CategoryInfo RowtoCategoryInfo(DataRow dr)
        {
            CategoryInfo ct = new CategoryInfo();
            ct.CatId = Convert.ToInt32(dr["CatId"]);
            ct.CatName = dr["CatName"].ToString();
            ct.CatNum = dr["CatNum"].ToString();
            ct.Remark = dr["Remark"].ToString();
            ct.SubBy = Convert.ToInt32(dr["SubBy"]);
            ct.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return ct;
        }
    }
}
