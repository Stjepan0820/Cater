using Cater.BLL;
using Cater.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cater
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            //加载所有的商品类别
            LoadCategoryInfoDelFlag(0);

            //加载所有的产品信息
            LoadProductInfoByDelFlag(0);


            //加载下拉框中所有的类别
            LoadCategoryInfoByDelFlagInComboBox(0);
        }
        /// <summary>
        /// 把类别加载到下拉框中
        /// </summary>
        /// <param name="v"></param>
        private void LoadCategoryInfoByDelFlagInComboBox(int v)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(v);
            list.Insert(0, new CategoryInfo() { CatName = "请选择", CatId = -1 });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }
        /// <summary>
        /// 加载所有产品
        /// </summary>
        /// <param name="v"></param>
        private void LoadProductInfoByDelFlag(int v)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProductInfo.AutoGenerateColumns = false;//禁止自动生产列
            dgvProductInfo.DataSource = bll.GetAllProductInfoByDelFlag(v);
            if (dgvProductInfo.Rows.Count>0)
            {
                dgvProductInfo.SelectedRows[0].Selected = false;//禁止默认第一行选中

            }
        }

        /// <summary>
        /// 所有商品类别
        /// </summary>
        /// <param name="v"></param>
        private void LoadCategoryInfoDelFlag(int v)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            dgvCategoryInfo.AutoGenerateColumns = false;
            dgvCategoryInfo.DataSource = bll.GetAllCategoryInfoByDelFlag(v);
            if (dgvCategoryInfo.Rows.Count>0)
            {
                dgvCategoryInfo.SelectedRows[0].Selected = false;
            }
        }
    }
}
