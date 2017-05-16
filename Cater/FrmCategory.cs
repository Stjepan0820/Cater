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
        //新增商品类别----1
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            LoadFrmChangeCategory(1);
        }

        private void LoadFrmChangeCategory(int v)
        {
            FrmChangeCategory fcc = new FrmChangeCategory();
            this.evtFcc += new EventHandler(fcc.SetTxt);//注册事件
            fea.Temp = v;
            if (this.evtFcc!=null)
            {
                this.evtFcc(this, fea);
                fcc.FormClosed += new FormClosedEventHandler(fcc_FormClosed);
                fcc.ShowDialog();
            }
        }
        //刷新
        private void fcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCategoryInfoDelFlag(0);
        }


        //修改商品类别----2
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategoryInfo.SelectedRows.Count>0)
            {
                //获取选中的行的id
                int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value.ToString());
                //根据id获取该商品类别的所有信息
                CategoryInfoBLL bll = new CategoryInfoBLL();
                //村对象
                fea.obj = bll.GetCategoryInfoByCatId(id);//判断不是nul在赋值
                LoadFrmChangeCategory(2);

            }
            else
            {
                MessageBox.Show("请选中要修改的行");
            }
        }

        public event EventHandler evtFcc;
        FrmEventArgs fea = new FrmEventArgs();







        public event EventHandler evtFcp;//产品增加或修改的事件

        //增加产品
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            LoadFrmChangeProduct(3);
        }



        //显示窗体
        private void LoadFrmChangeProduct(int v)
        {
            FrmChangeProduct fcp = new FrmChangeProduct();
            this.evtFcp += new EventHandler(fcp.SetTxt);//注册新增或修改的产品的窗体的传值事件
            //此处的fea对象在新增或修改==类别的上面声明的,===
            fea.Temp = v;//存储标识,3表示新增产品信息,4---表示修改产品信息
            if (this.evtFcp!=null)
            {
                this.evtFcp(this, fea);//执行事件
                fcp.FormClosed += new FormClosedEventHandler(fcp_FormClosed);//关闭后刷新
                fcp.ShowDialog();//显示窗体

            }

        }
        /// <summary>
        /// 关闭新增或修改产品的窗体的刷新事件的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fcp_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
        }

        //修改产品
        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString());
                //根据id查选中行的所有数据
                ProductInfoBLL bll = new ProductInfoBLL();
                fea.obj = bll.GetProductInfoByProId(id);
                LoadFrmChangeProduct(4);

            }
            else
            {
                MessageBox.Show("请选中要修改的行");
            }
        }
        //删除产品
        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count>0)
            {
                //获取当前选中行的 ID
                int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString());

                ProductInfoBLL bll = new ProductInfoBLL();
                string msg = bll.SoftDeleteProductInfoProId(id) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                LoadProductInfoByDelFlag(0);//刷新
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex!=0)
            {
                ProductInfoBLL bll = new ProductInfoBLL();
                dgvProductInfo.AutoGenerateColumns = false;
                dgvProductInfo.DataSource = bll.GetProductInfoByCatId(Convert.ToInt32(cmbCategory.SelectedValue));
                if (dgvProductInfo.Rows.Count>0)
                {
                    dgvProductInfo.SelectedRows[0].Selected = false;
                }
                else
                {
                    LoadProductInfoByDelFlag(0);
                }
            }
        }
    }
}
