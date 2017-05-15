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
    public partial class FrmMember : Form
    {
        public FrmMember()
        {
            InitializeComponent();
        }

        private void FrmMember_Load(object sender, EventArgs e)
        {
            //显示所有的会员信息
            LoadMemberInfoByDelFlag(0);
        }
        /// <summary>
        /// 查询所有的会员信息
        /// </summary>
        /// <param name="v"></param>
        private void LoadMemberInfoByDelFlag(int v)
        {
            MemberInfoBLL bll = new MemberInfoBLL();
            dgvMemmber.AutoGenerateColumns = false;//禁止自动生成列
            dgvMemmber.DataSource = bll.GetAllMemberInfoByDelFlag(v);
            if (dgvMemmber.Rows.Count>0)
            {
                dgvMemmber.SelectedRows[0].Selected = false;
            }
        }
        //删除会员
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMemmber.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选中要删除的数据");
                return;
            }
            int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value.ToString());
            MemberInfoBLL bll = new MemberInfoBLL();
            string msg = bll.SoftDeleteMemberInfoByNumberId(id) ? "操作成功" : "操作失败";
            LoadMemberInfoByDelFlag(0);//刷新
            MessageBox.Show(msg);
        }
        //增加
        private void btnAddMemMber_Click(object sender, EventArgs e)
        {
            LoadFrmChangeMember(1);
        }


        //创建一个事件对象
        public event EventHandler evtFcm;
        FrmEventArgs fea = new FrmEventArgs();
        private void LoadFrmChangeMember(int v)
        {
            FrmChangeMemmber fcm = new FrmChangeMemmber();
            fea.Temp = v;//标识存起来
            this.evtFcm += new EventHandler(fcm.SetTxt);//注册事件
            if (this.evtFcm!=null)
            {
                this.evtFcm(this, fea);
                fcm.FormClosed += new FormClosedEventHandler(fcm_FormClosed);
                fcm.ShowDialog();//显示新增或修改的窗体
            }

        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fcm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMemberInfoByDelFlag(0);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            if (dgvMemmber.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选择数据");
                return;
            }
            //选中，根据id去数据库查询该行数据的所有信息
            MemberInfoBLL bll = new MemberInfoBLL();
            int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value);
            fea.obj = bll.GetMemmberInfoMemmberId(id);
            LoadFrmChangeMember(2);
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {

        }
    }
}
