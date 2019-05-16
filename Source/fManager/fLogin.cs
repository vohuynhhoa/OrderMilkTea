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
using fManager.DAO;
using fManager.DTO;
using System.Data.SqlClient;

namespace fManager
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void btndangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HOAHOA\\SQLEXPRESS;Initial Catalog=ORDERMILKTEA;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select UserName from Account where UserName='"+ txtusername.Text+ "' and PassWord='" +txtpass.Text+"' ",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count==1)
            {
                
                fMain b = new fMain(dt.Rows[0][0].ToString());
                this.Hide();
                b.ShowDialog();
                this.Show();
                
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu. Vui lòng nhập lại!!!","Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
        }
        bool Login (string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}