using Cater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cater.DAL;

namespace Cater.BLL
{
    public class MemmberTypeBLL
    {
        MemmberTypeDALL dal = new MemmberTypeDALL();

        
        /// <summary>
        /// 根据删除标识查询所有的会员等级信息
        /// </summary>
        /// <param name="delFlag">删标识</param>
        /// <returns></returns>
        public List<MemmberType> GetAllMemmeberTypeByDelFlag(int delFlag)
        {
            return dal.GetAllMemmeberTypeByDelFlag(delFlag);
        }
    }
}
