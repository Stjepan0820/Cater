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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnMemmber_Click(object sender, EventArgs e)
        {
            FrmMember f = new FrmMember();
            f.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategory f = new FrmCategory();
            f.ShowDialog();
        }
    }
}
