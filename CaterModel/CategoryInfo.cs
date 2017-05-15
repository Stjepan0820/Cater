using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cater.Model
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class CategoryInfo
    {
        /// <summary>
        /// 商品分类主键
        /// </summary>
        public int CatId { get; set; }
        /// <summary>
        /// 商品分类名字
        /// </summary>
        public string CatName { get; set; }
        /// <summary>
        /// 商品分类编号
        /// </summary>
        public string CatNum { get; set; }
        /// <summary>
        /// 商品分类备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 商品分类删除标识
        /// </summary>
        public int? DelFlag { get; set; }
        /// <summary>
        /// 商品分类提交时间
        /// </summary>
        public DateTime? SubTime { get; set; }
        /// <summary>
        /// 商品分类提交人
        /// </summary>
        public int? SubBy { get; set; }
    }
}
