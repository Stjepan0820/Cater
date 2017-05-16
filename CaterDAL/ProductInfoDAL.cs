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
    public class ProductInfoDAL
    {


        /// <summary>
        /// 根据商品类别的ID查询该类别下有什么产品
        /// </summary>
        /// <param name="catId">类别的id</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatId(int catId)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and catId=" + catId;
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }





        /// <summary>
        /// 根据产品的id删除该产品
        /// </summary>
        /// <param name="proId">产品id</param>
        /// <returns></returns>
        public int SoftDeleteProductInfoProId(int proId)
        {
            string sql = "update ProductInfo set DelFlag=1 where ProId=" + proId;
            return SqlHelperSqlite.ExecuteNonQuery(sql);
        }





        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo(CatId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,DelFlag,SubTime,ProStock,ProNum,SubBy) values(@CatId,@ProName,@ProCost,@ProSpell,@ProPrice,@ProUnit,@Remark,@DelFlag,@SubTime,@ProStock,@ProNum,@SubBy)";
            return AddAndUpdateProductInfo(pro, sql, 3);
        }
        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CatId=@CatId,ProName=@ProName,ProCost=@ProCost,ProSpell=@ProSpell,ProPrice=@ProPrice,ProUnit=@ProUnit,Remark=@Remark,ProStock=@ProStock,ProNum=@ProNum where ProId=@ProId";
            return AddAndUpdateProductInfo(pro, sql, 4);
        }

        private int AddAndUpdateProductInfo(ProductInfo pro, string sql, int temp)
        {
            //准备参数
            SQLiteParameter[] ps = {
                 new SQLiteParameter("@CatId",pro.CatId),
                 new SQLiteParameter("@ProName",pro.ProName),
                 new SQLiteParameter("@ProCost",pro.ProCost),
                 new SQLiteParameter("@ProSpell",pro.ProSpell),
                 new SQLiteParameter("@ProPrice",pro.ProPrice),
                 new SQLiteParameter("@ProUnit",pro.ProUnit),
                 new SQLiteParameter("@Remark",pro.Remark),
                 new SQLiteParameter("@ProStock",pro.ProStock),
                 new SQLiteParameter("@ProNum",pro.ProNum)
                                  };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if (temp==3)//新增
            {
                list.Add(new SQLiteParameter("@DelFlag", pro.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", pro.SubTime));
                list.Add(new SQLiteParameter("@SubBy", pro.SubBy));
            }
            else if (temp==4)//修改
            {
                list.Add(new SQLiteParameter("@ProId", pro.ProId));
            }
            return SqlHelperSqlite.ExecuteNonQuery(sql, list.ToArray());
        }
















        /// <summary>
        /// 根据产品的id查询该产品信息
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public ProductInfo GetProductInfoByProId(int proId)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProId=" + proId;
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }
        /// <summary>
        /// 根据删除标识查询所有的产品信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            string sql = "select * from ProductInfo where DelFlag=" + delFlag;
            DataTable dt = SqlHelperSqlite.ExecuteTable(sql);
            List<ProductInfo> list = new List<ProductInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }

        private ProductInfo RowToProductInfo(DataRow dr)
        {
            ProductInfo pro = new ProductInfo();
            pro.CatId = Convert.ToInt32(dr["CatId"]);
            pro.ProCost = Convert.ToDecimal(dr["ProCost"]);
            pro.ProId = Convert.ToInt32(dr["ProId"]);
            pro.ProName = dr["ProName"].ToString();
            pro.ProNum = dr["ProNum"].ToString();
            pro.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            pro.ProSpell = dr["ProSpell"].ToString();
            pro.ProStock = Convert.ToDecimal(dr["ProStock"]);
            pro.ProUnit = dr["ProUnit"].ToString();
            pro.Remark = dr["Remark"].ToString();
            pro.SubBy = Convert.ToInt32(dr["SubBy"]);
            pro.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return pro;
        }
    }
}
