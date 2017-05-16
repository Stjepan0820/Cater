using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cater.BLL;
using Cater.Model;

namespace Cater
{
    public partial class FrmChangeProduct : Form
    {
        public FrmChangeProduct()
        {
            InitializeComponent();
        }

        private int TP { get; set; }
        //注册事件的方法
        public void SetTxt(object sender,EventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
            FrmEventArgs fea = e as FrmEventArgs;
            this.TP = fea.Temp;
            if (this.TP == 3)//新增
            {

            }
            else if (this.TP == 4)//修改
            {
                ProductInfo pro = fea.obj as ProductInfo;//小坑
                txtCost.Text = pro.ProCost.ToString();
                txtName.Text = pro.ProName;//名字
                txtNum.Text = pro.ProNum;//编号
                txtPrice.Text = pro.ProPrice.ToString();//价格
                txtRemark.Text = pro.Remark;//备注
                txtSpell.Text = pro.ProSpell;//坑-===天坑--拼音
                txtStock.Text = pro.ProStock.ToString();
                txtUnit.Text = pro.ProUnit;
                //id
                labId.Text = pro.ProId.ToString();

                cmbCategory.SelectedValue = pro.CatId;//显示该产品对应的类别
            }

        }

        private void LoadCategoryInfoByDelFlag(int delFlag)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(delFlag);
            list.Insert(0, new CategoryInfo() { CatId = -1, CatName = "请选择" });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }
        //确定增加还是修改
        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断标识
            if (CheckEmpty())
            {
                //获取对象中的属性的值
                ProductInfoBLL bll = new ProductInfoBLL();
                ProductInfo pro = new ProductInfo();
                pro.CatId = Convert.ToInt32(cmbCategory.SelectedValue);
                pro.ProCost = Convert.ToDecimal(txtCost.Text);
                pro.ProName = txtName.Text;
                pro.ProNum = txtNum.Text;
                pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
                pro.ProSpell = txtSpell.Text;//=======================好大的坑
                pro.ProStock = Convert.ToDecimal(txtStock.Text);
                pro.ProUnit = txtUnit.Text;
                pro.Remark = txtRemark.Text;

                if (this.TP==3)//新增
                {
                    pro.DelFlag = 0;
                    pro.SubBy = 1;
                    pro.SubTime = System.DateTime.Now;
                }
                else if (this.TP==4)//修改
                {
                    pro.ProId = Convert.ToInt32(labId.Text);
                }
                string msg = bll.SaveProductInfo(pro, this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }
        /// <summary>
        /// 判断所有的文本框不能为空
        /// </summary>
        /// <returns></returns>
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("商品成本不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("商品名称不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                MessageBox.Show("商品编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("商品价格不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("商品备注不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                MessageBox.Show("商品拼音不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("商品库存不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("商品单位不能为空");
                return false;
            }
            return true;
        }
    }
}
