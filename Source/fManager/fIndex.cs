using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace fManager
{
    public partial class fIndex : DevExpress.XtraEditors.XtraForm
    {
        public fIndex()
        {
            InitializeComponent();
        }

        private void fIndex_Click(object sender, EventArgs e)
        {
            fLogin b = new fLogin();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            fLogin b = new fLogin();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void fIndex_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fIndex_Load(object sender, EventArgs e)
        {

        }
    }
}