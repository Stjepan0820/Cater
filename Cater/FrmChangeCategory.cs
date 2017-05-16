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
    public partial class FrmChangeCategory : Form
    {
        public FrmChangeCategory()
        {
            InitializeComponent();
        }
        private  int TP { get; set; }//标识

        public void SetTxt(object sender,EventArgs e)
        {
            FrmEventArgs fea = e as FrmEventArgs;
            this.TP = fea.Temp;
            if (this.TP==1)//新增
            {

            }
            else if (this.TP==2)
            {
                CategoryInfo ct = fea.obj as CategoryInfo;
                txtCName.Text = ct.CatName;
                txtCNum.Text = ct.CatNum;
                txtCRemark.Text = ct.Remark;
                labId.Text = ct.CatId.ToString();

            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                CategoryInfoBLL bll = new CategoryInfoBLL();
                CategoryInfo ct = new CategoryInfo();
                ct.CatName = txtCName.Text;
                ct.CatNum = txtCNum.Text;
                ct.Remark = txtCRemark.Text;

                //新增还是修改
                if (this.TP==1)
                {
                    ct.DelFlag = 0;
                    ct.SubBy = 1;
                    ct.SubTime = System.DateTime.Now;
                }
                else if (this.TP==2)
                {
                    ct.CatId = Convert.ToInt32(labId.Text);
                }
                string msg = bll.SaveCategoryInfo(ct, this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }

        private bool Check()
        {
            if (string.IsNullOrEmpty(txtCName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCRemark.Text))
            {
                MessageBox.Show("备注不能为空");
                return false;
            }
            return true;
        }
    }
}
