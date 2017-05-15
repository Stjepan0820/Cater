using Cater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.DAL;

namespace Cater.BLL
{
    public class CategoryInfoBLL
    {
        CategoryInfoDAL dal = new CategoryInfoDAL();



        /// <summary>
        /// 根据商品类别的id查该商品类别信息
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public CategoryInfo GetCategoryInfoByCatId(int catId)
        {
            return dal.GetCategoryInfoCatId(catId);
        }

        /// 根据删除标识查询所有商品类别信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return dal.GetAllCategoryInfoDelFlag(delFlag);
        }
    }
}
