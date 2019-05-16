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
using System.Data.SqlClient;

namespace fManager
{
    public partial class fSellingMilkTea : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HOAHOA\\SQLEXPRESS;Initial Catalog=ORDERMILKTEA;Integrated Security=True");
        public fSellingMilkTea()
        {
            InitializeComponent();
            con.Open();
        }
        DataTable LoadData1()
        {
            var cmd = new SqlCommand("select name as [Tên], count(*) as [Số lượng bán] from BillInfo, Food  where  idFood='11' and Food.id=BillInfo.idFood group by name", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;


        }
        DataTable LoadData2()
        {
            var cmd = new SqlCommand("select name as [Tên], count(*) as [Số lượng bán] from BillInfo, Food  where  idFood='1' and Food.id=BillInfo.idFood group by name", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;


        }
        DataTable LoadData3()
        {
            var cmd = new SqlCommand("select name as [Tên], count(*) as [Số lượng bán] from BillInfo, Food  where  idFood='19' and Food.id=BillInfo.idFood  group by name", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;


        }
        DataTable LoadData4()
        {
            var cmd = new SqlCommand("select count(idFood) as [Tổng sản phẩm bán được] from BillInfo ", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;


        }


        private void fSellingMilkTea_Load(object sender, EventArgs e)
        {
            
            

        }

        private void fSellingMilkTea_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = LoadData1();
            dgv2.DataSource = LoadData2();
            dgv3.DataSource = LoadData3();

        }

        private void btntongban_Click(object sender, EventArgs e)
        {
            dgv4.DataSource = LoadData4();

        }
    }
}