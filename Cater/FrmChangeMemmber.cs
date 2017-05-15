using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cater.Model;

namespace Cater
{
    public partial class FrmChangeMemmber : Form
    {
        public FrmChangeMemmber()
        {
            InitializeComponent();
        }

        private  int TP { get; set; }//标识
        public void SetTxt(object sender,EventArgs e)
        {
            //获取传过来的标识和对象
            FrmEventArgs fea = e as FrmEventArgs;
            this.TP = fea.Temp;
            if (this.TP==1)
            {

            }
            else if (this.TP==2)//修改
            {
                MemberInfo mem = fea.obj as MemberInfo;//获取会员对象
                txtMemNum.Text = mem.MemberNum;
                txtBirs.Text = mem.MemberBirthday.ToString();
                txtMemDiscount.Text = mem.MemberDiscount.ToString();
                txtMemIntegral.Text = mem.MemberIntegral.ToString();
                txtmemMoney.Text = mem.MemberMoney.ToString();
                txtMemName.Text = mem.MemberName;
                txtMemPhone.Text = mem.MemberMobilePhone;
                rdoMan.Checked = mem.MemberGender == "男" ? true : false;
                rdoWomen.Checked = mem.MemberGender == "女" ? true:false;
                labId.Text = mem.MemberId.ToString();

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断
            if (this.TP == 1)//新增
            {

            }
            else if (this.TP == 2)//修改
            {

            }
        }
    }
}
