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
using fManager.DTO;
using System.Data.SqlClient;

namespace fManager
{
    public partial class fChangeAccount : DevExpress.XtraEditors.XtraForm
    {
        
        public fChangeAccount()
        {
            InitializeComponent();



        }
        
        private void btnexituser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fInforAccount_Load(object sender, EventArgs e)
        {
            
            
           
        }

        private void fInforAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HOAHOA\SQLEXPRESS;Initial Catalog=ORDERMILKTEA;Integrated Security=True");

        private void btnupdateuser_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from dbo.Account where UserName = N'" + txttendangnhap.Text + "' and DisplayName= N'" + txttenhienthi.Text + "' and PassWord = N'" + txtmatkhaucu.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txtmatkhaumoi.Text == txtnhaplaimatkhau.Text)
                {
                    if (txtmatkhaumoi.Text.Length>6)
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("update dbo.Account set PassWord =N'" + txtmatkhaumoi.Text + "' where UserName =N'" + txttendangnhap.Text + "'and DisplayName=N'" + txttenhienthi.Text + "' and PassWord=N'" + txtmatkhaucu.Text + "'", con);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        errorProvider1.SetError(txtmatkhaumoi, "Độ dài mật khẩu không đúng!");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtmatkhaumoi, "Bạn chưa điền mật khẩu!");
                    errorProvider1.SetError(txtnhaplaimatkhau, "Mật khẩu nhập lại chưa đúng!");

                }
            }
            else
            {
                errorProvider1.SetError(txttendangnhap, "Tên đăng nhập không đúng!");
                errorProvider1.SetError(txttenhienthi, "Tên hiển thị không đúng!");
                errorProvider1.SetError(txtmatkhaucu, "Mật khẩu cũ không đúng!");
            }
        }
    }
}