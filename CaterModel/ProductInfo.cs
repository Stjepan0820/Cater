using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cater.Model
{
    public class ProductInfo
    {
        /// <summary>
        /// 商品主键
        /// </summary>
        public int ProId { get; set; }
        /// <summary>
        /// 商品类型id
        /// </summary>
        public int? CatId { get; set; }
        /// <summary>
        /// 商品名字
        /// </summary>
        public string ProName { get; set; }
        /// <summary>
        /// 商品成本
        /// </summary>
        public decimal? ProCost { get; set; }
        /// <summary>
        /// 商品拼音
        /// </summary>
        public string ProSpell { get; set; }
        /// <summary>
        /// 商品实际价格
        /// </summary>
        public decimal? ProPrice { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string ProUnit { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 商品删除标识
        /// </summary>
        public int? DelFlag { get; set; }
        /// <summary>
        /// 商品提交时间
        /// </summary>
        public DateTime? SubTime { get; set; }
        /// <summary>
        /// 商品库存
        /// </summary>
        public decimal? ProStock { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProNum { get; set; }
        /// <summary>
        /// 商品提交人
        /// </summary>
        public int? SubBy { get; set; }

    }
}
