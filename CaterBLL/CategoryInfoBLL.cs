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
        /// 新增或修改商品类别信息
        /// </summary>
        /// <param name="ct">商品类别对象</param>
        /// <param name="temp">标识1----新增,2----修改</param>
        /// <returns>成功还是失败</returns>
        public bool SaveCategoryInfo(CategoryInfo ct, int temp)
        {
            int r = 1;
            if (temp == 1)
            {
                r = dal.AddCategoryInfo(ct);
            }
            else if (temp==2)
            {
                r = dal.UpdateCategoryInfo(ct);
            }
            return r > 0;
        }


























        /// <summary>
        /// 根据商品类别的id查该商品类别信息
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public CategoryInfo GetCategoryInfoByCatId(int catId)
        {
            return dal.GetCategoryInfoCatId(catId);
        }
        /// <summary>
        /// 根据删除标识查询所有商品类别信息
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return dal.GetAllCategoryInfoDelFlag(delFlag);
        }
    }
}
