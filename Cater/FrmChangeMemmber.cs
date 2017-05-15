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
using Cater.BLL;
namespace Cater
{
    public partial class FrmChangeMemmber : Form
    {
        public FrmChangeMemmber()
        {
            InitializeComponent();
        }

        private  int TP { get; set; }//标识

        //加载所有会员的等级信息
        private void LoadMemmberTypeByDelFlag(int delFlag)
        {
            MemmberTypeBLL bll = new MemmberTypeBLL();
            List<MemmberType> list = bll.GetAllMemmeberTypeByDelFlag(delFlag);
            list.Insert(0, new MemmberType() { MemType = -1, MemTpName = "请选择" });
            //为下拉框绑定数据
            cmbMemType.DataSource = list;
            cmbMemType.DisplayMember = "MemTpName";//显示的是这个属性中的值
            cmbMemType.ValueMember = "MemType";//实际的值
        }
        public void SetTxt(object sender,EventArgs e)
        {

            LoadMemmberTypeByDelFlag(0);
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

                cmbMemType.SelectedValue = mem.MemType;//设置显示的会员等级，通过Memtype的值
                dtEndServerTime.Value = mem.MemberEndServerTime;

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsCheck())
            {
                MemberInfoBLL bll = new MemberInfoBLL();
                MemberInfo mem = new MemberInfo();
                mem.MemberAddress = "上海";//默认没有文本框
                mem.MemberBirthday = Convert.ToDateTime(txtBirs.Text);
                mem.MemberDiscount = Convert.ToDecimal(txtMemDiscount.Text);
                mem.MemberEndServerTime = dtEndServerTime.Value;
                mem.MemberGender = CheckGender();//性别
                mem.MemberMobilePhone = txtMemPhone.Text;//电话
                mem.MemberMoney = Convert.ToDecimal(txtmemMoney.Text);//钱
                mem.MemberName = txtMemName.Text;
                mem.MemberNum = txtMemNum.Text;
                mem.MemType = Convert.ToInt32(cmbMemType.SelectedValue);//等级

                //判断
                if (this.TP==1)//新增
                {
                    mem.DelFlag = 0;
                    mem.MemberIntegral = Convert.ToDecimal(txtMemIntegral.Text);
                    mem.SubTime = System.DateTime.Now;
                }
                else if (this.TP==2)//修改
                {
                    mem.MemberId = Convert.ToInt32(labId.Text);
                }

                string msg = bll.SaveMemmberInfo(mem, this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }

        private string CheckGender()
        {
            if (rdoMan.Checked)
            {
                return "男";
            }
            else
            {
                return "女";
            }
        }

        private bool IsCheck()
        {
            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemIntegral.Text))
            {
                MessageBox.Show("积分不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtmemMoney.Text))
            {
                MessageBox.Show("余额不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;

            }
            if (string.IsNullOrEmpty(txtMemNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemPhone.Text))
            {
                MessageBox.Show("电话不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(dtEndServerTime.Text))
            {
                MessageBox.Show("有效期不能为空");
                return false;
            }
            return true;
        }
    }
}
