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
    public partial class fCoffee : DevExpress.XtraEditors.XtraForm
    {
        public fCoffee()
        {
            InitializeComponent();
        }

        private void fCoffee_Load(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}