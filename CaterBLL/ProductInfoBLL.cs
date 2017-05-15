using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.DAL;
using Cater.Model;

namespace Cater.BLL
{
    public class ProductInfoBLL
    {
        ProductInfoDAL dal = new ProductInfoDAL();
        /// <summary>
        /// 根据产品的id查询该产品信息
        /// </summary>
        /// <param name="proId">产品的id</param>
        /// <returns>产品对象</returns>
        public ProductInfo GetProductInfoByProId(int proId)
        {
            return dal.GetProductInfoByProId(proId);
        }


        /// <summary>
        /// 根据删除标识查询所有的产品信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            return dal.GetAllProductInfoByDelFlag(delFlag);
        }
    }
}
