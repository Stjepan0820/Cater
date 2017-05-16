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
        /// 根据商品类别的id查该类别下有什么产品
        /// </summary>
        /// <param name="catId">类别的id</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatId(int catId)
        {
            return dal.GetProductInfoByCatId(catId);
        }













        /// <summary>
        /// 根据产品的id删除该产品
        /// </summary>
        /// <param name="proId">产品id</param>
        /// <returns></returns>
        public bool SoftDeleteProductInfoProId(int proId)
        {
            return dal.SoftDeleteProductInfoProId(proId) > 0;
        }


        /// <summary>
        /// 新增或者修改产品信息
        /// </summary>
        /// <param name="pro">产品对象</param>
        /// <param name="temp">标识---3-----新增,----4---修改</param>
        /// <returns></returns>
        public bool SaveProductInfo(ProductInfo pro,int temp)
        {
            int r = -1;
            if (temp==3)
            {
                r = dal.AddProductInfo(pro);
            }
            else if (temp==4)
            {
                r = dal.UpdateProductInfo(pro);
            }
            return r > 0;
        }








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
