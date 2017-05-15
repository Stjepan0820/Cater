using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.Model;
using System.Data;

namespace Cater.DAL
{
    public class ProductInfoDAL
    {
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
            if (dt.Rows.Count>0)
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
            if (dt.Rows.Count>0)
            {
                foreach (DataRow  dr in dt.Rows)
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
