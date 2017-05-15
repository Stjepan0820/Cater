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

namespace Cater
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

       

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //账号密码都是正确的情况
            if (CheckEmpty())
            {
                //账号密码都不为空
                UserInfoBLL bll = new UserInfoBLL();
                string msg;
                if (bll.GetUserInfoByLoginUserNameAndPwd(txt_UserID.Text,txt_pwd.Text,out  msg))
                {
                    msgDiv1.MsgDivShow(msg, 1, Bind);
                }
                else
                {
                    msgDiv1.MsgDivShow(msg, 1);
                }
            }
        }

        private void Bind()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;//设置当前窗体的对话框结果
        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txt_UserID.Text))
            {
                msgDiv1.MsgDivShow("账号不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txt_pwd.Text))
            {
                msgDiv1.MsgDivShow("密码不能为空", 1);
            }
            return true;
        }

       
    }
}
