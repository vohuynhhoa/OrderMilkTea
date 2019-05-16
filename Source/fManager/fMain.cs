using DevExpress.XtraBars;
using fManager.DAO;
using fManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;



namespace fManager
{
    public partial class fMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                
                loginAccount = value;
                //ChangeAccount(loginAccount.Type);
            }
        }

        public fMain(string UserName)
        {
            InitializeComponent();
            lblhello.Text = UserName;
            //this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbxtable);
            if (lblhello.Text!= "Admin")
            {
                barButtonItemadmin.Enabled = false;
            }
            

        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        #region Method
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbxcategory.DataSource = listCategory;
            cbxcategory.DisplayMember = "Name";
            
        }
        void LoadFoodByCategoryID(int id)
        {

            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryByID(id);
            cbxFood.DataSource = listFood;
            cbxFood.DisplayMember = "Name";
        }
         void LoadTable()
        {
           flptable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                
                switch (item.Status)
                {
                    case "Trống":
                        string d = @"C:\Users\84162\Downloads\hinh\table.png";
                        btn.Image = Image.FromFile(d);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.Turquoise;
                        btn.FlatAppearance.BorderSize = 1;
                  
                        break;
                    default:
                        item.Status = "Có người";
                        btn.BackColor = Color.Turquoise;
                        btn.FlatAppearance.BorderColor = Color.Turquoise;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.ForeColor = Color.White;
                        break;
                }

                flptable.Controls.Add(btn);
            }
        }
        void LoadTableColor()
        {
            flptable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                Table table = lstbill.Tag as Table;
                if (table.Status == "Trống")
                {
                        table.Status = "Có người";
                        /*table.BackColor = Color.Turquoise;
                        btn.FlatAppearance.BorderColor = Color.Turquoise;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.ForeColor = Color.White*/
                }

                flptable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lstbill.Items.Clear();
            List<fManager.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (fManager.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                lstbill.Items.Add(lsvItem);
                totalPrice += item.TotalPrice;

            }
            txttotalprice.Text = txttotalprice.ToString();
            
            CultureInfo culture = new CultureInfo("vi-VN");

            Thread.CurrentThread.CurrentCulture = culture;

            txttotalprice.Text = totalPrice.ToString("c", culture);
            LoadTable();

        }
       
       


        #endregion


        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            
            int tableID = ((sender as Button).Tag as Table).ID;
            lstbill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            fCoffee b = new fCoffee();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void searchLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void myGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accordionControlElement4_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void myGradientPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            fAdmin b = new fAdmin();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }


        private void fMain_Load(object sender, EventArgs e)
        {
            LoadTable();
            
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
            fChangeAccount c = new fChangeAccount();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {

        }

        private void myGradientPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void myGradientPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void myGradientPanel9_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id= selected.ID;
            LoadFoodListByCategoryID(id);
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryByID(id);
            cbxFood.DataSource = listFood;
            cbxFood.DisplayMember = "Name";
        }

        private void btnaddfood_Click(object sender, EventArgs e)
        {
            
            Table table = lstbill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbxFood.SelectedItem as Food).ID;
            int count = (int)numericcount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);
            //LoadTableColor();
            LoadTable();
        }

        private void barButtonItem2_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            Table table = lstbill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)numdiscount.Value;

            double totalPrice = Convert.ToDouble(txttotalprice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }

        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            int id1 = (lstbill.Tag as Table).ID;

            int id2 = (cbxtable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lstbill.Tag as Table).Name, (cbxtable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            fFlowerTea b = new fFlowerTea();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            fSquashTea b = new fSquashTea();
            this.Hide();
            b.ShowDialog();
            this.Show();

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            fSpecialTea b = new fSpecialTea();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void accordionControlElement4_Click_2(object sender, EventArgs e)
        {
            fTopping b = new fTopping();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void barButtonItem2_ItemClick_3(object sender, ItemClickEventArgs e)
        {
            btnpay_Click(this, new EventArgs());
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnaddfood_Click(this, new EventArgs());
        }

        private void lblhello_Click(object sender, EventArgs e)
        {

        }

        private void txttotalprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            fSellingMilkTea b = new fSellingMilkTea();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }
    }
}
