using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.Model;
using System.Data;
using System.Data.SQLite;

namespace Cater.DAL
{
    public class CategoryInfoDAL
    {
        /// <summary>
        /// 新增商品类别
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public int AddCategoryInfo(CategoryInfo ct)
        {
            string sql = "insert into CategoryInfo(CatName,CatNum,Remark,DelFlag,SubTime,SubBy) values(@CatName,@CatNum,@Remark,@DelFlag,@SubTime,@SubBy)";
            return AddAndUpdateCategoryInfo(ct, sql, 1);
        }

       /// <summary>
       /// 修改商品类别
       /// </summary>
       /// <param name="ct"></param>
       /// <returns></returns>
        public int UpdateCategoryInfo(CategoryInfo ct)
        {
            string sql = "update CategoryInfo set CatName=@CatName,CatNum=@CatNum,Remark=@Remark where CatId=@CatId";
            return AddAndUpdateCategoryInfo(ct, sql, 2);
        }

        private int AddAndUpdateCategoryInfo(CategoryInfo ct, string sql, int v)
        {
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@CatName",ct.CatName),
                new SQLiteParameter("@CatNum",ct.CatNum),
                new SQLiteParameter("@Remark",ct.Remark)
            };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if (v==1)//新增
            {
                list.Add(new SQLiteParameter("@DelFlag", ct.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", ct.SubTime));
                list.Add(new SQLiteParameter("@SubBy", ct.SubBy));
            }
            else if (v==2)//修改
            {
                list.Add(new SQLiteParameter("@CatId", ct.CatId));
            }
            return SqlHelperSqlite.ExecuteNonQuery(sql, list.ToArray());

        }





















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
        public List<CategoryInfo> GetAllCategoryInfoDelFlag (int delFlag)
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
