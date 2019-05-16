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
using fManager.DAO;
using fManager.DTO;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace fManager
{
    public partial class fAdmin : DevExpress.XtraEditors.XtraForm
    {
        BindingSource foodList = new BindingSource();

        BindingSource accountList = new BindingSource();
        BindingSource staffList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource categoryList = new BindingSource();

        public Account loginAccount;
        

        public fAdmin()
        {
            InitializeComponent();
            LoadData();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadDateTimePickerBill();

        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }


        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.GetListTable();
        }
        void LoadListStaff()
        {
            staffList.DataSource = StaffDAO.Instance.GetListStaff();
        }
        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }


        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void AddTableBinding()
        {
            txtTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
        }
        

        void LoadCategoryIntoCombobox()
        {
            string query = "Select * from FoodCategory ";
            cbFoodCategory.DataSource = DataProvider.Instance.ExecuteQuery(query);
            cbFoodCategory.DisplayMember = "Name";

        }
        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));

        }
        void AddStaffBinding()
        {
            
            txtidstaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtnamestaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtsexstaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "sex", true, DataSourceUpdateMode.Never));
            txtnumberstaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "numberphone", true, DataSourceUpdateMode.Never));
            txtaddressstaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "address", true, DataSourceUpdateMode.Never));

        }
        
 

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gridbill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            /*panel32.Enabled = false;
            panel35.Enabled = false;
            panel38.Enabled = false;
            panel41.Enabled = false;
            panel43.Enabled = false;
            btnEditAccount.Enabled = false;
            btnEditCategory.Enabled = false;
            btnEditFood.Enabled = false;
            btnEditStaff.Enabled = false;
            btnEditTable.Enabled = false;*/
            



        }
        void LoadData()
        {
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvTable.DataSource = tableList;
            dtgvStaff.DataSource = staffList;
            dtgvCategory.DataSource = categoryList;

            LoadListFood();
            LoadAccount();
            LoadListStaff();
            LoadListCategory();
            LoadListTable();
            LoadCategoryIntoCombobox(cbFoodCategory);
            AddFoodBinding();
            AddTableBinding();
            AddAccountBinding();
            AddStaffBinding();
            AddCategoryBinding();

        }
        void AddAccountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            //numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        private void fAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }
        private event EventHandler insertStaff;
        public event EventHandler InsertStaff
        {
            add { insertStaff += value; }
            remove { insertStaff -= value; }
        }
        private event EventHandler deleteStaff;
        public event EventHandler DeleteStaff
        {
            add { deleteStaff += value; }
            remove { deleteStaff -= value; }
        }

        private event EventHandler updateStaff;
        public event EventHandler UpdateStaff
        {
            add { updateStaff += value; }
            remove { updateStaff -= value; }
        }
        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }
        private event EventHandler insertAccount;
        public event EventHandler InsertAccount
        {
            add { insertAccount += value; }
            remove { insertAccount -= value; }
        }
        private event EventHandler deleteAccount;
        public event EventHandler DeleteAccount
        {
            add { deleteAccount += value; }
            remove { deleteAccount -= value; }
        }

        private event EventHandler updateAccount;
        public event EventHandler UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            //panel32.Enabled = true;
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm thức uống thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức uống!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }
        void LoadCategoryIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            //panel35.Enabled = true;
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListCategory();
                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            //panel38.Enabled = true;
            string userName = txtUserName.Text;
            string displayName = txbDisplayName.Text;
            //int type = (int)numericUpDown1.Value;

            if (AccountDAO.Instance.InsertAccount(userName, displayName))
            {
                MessageBox.Show("Thêm tài khoản thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadAccount();
                if (insertAccount != null)
                    insertAccount(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }


        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            //panel41.Enabled = true;
            string name = txtnamestaff.Text;
            string sex = txtsexstaff.Text;
            int numberphone = Convert.ToInt32(txtnumberstaff.Text);
            string address = txtaddressstaff.Text;
            if (StaffDAO.Instance.InsertStaff(name, sex, numberphone, address))
            {
                MessageBox.Show("Thêm nhân viên thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListStaff();
                if (insertStaff != null)
                    insertStaff(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhân viên!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }


        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            /*panel43.Enabled = true;
            btnAddTable.Enabled = false;
            btnEditTable.Enabled = false;
            btnDeleteTable.Enabled = false;*/
            string name = txtTableName.Text;
            string status = txtTableStatus.Text;

            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListTable();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa thức uống thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức uống!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btnExitFood_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadFood_Click(object sender, EventArgs e)
        {
            txbFoodName.Text = "";
            cbFoodCategory.Text = "Chọn danh mục";
            nmFoodPrice.Text = "0";
            

        }

        private void btnLoadCategory_Click(object sender, EventArgs e)
        {
            txbCategoryID.Text = "";
            txbCategoryName.Text = "";
            
        }

        private void btnLoadAccount_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txbDisplayName.Text = "";
            //numericUpDown1.Text = "0";

            
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        private void btnFristBillPage_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }

        private void btnPrevioursBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);

            if (page > 1)
                page--;

            txbPageBill.Text = page.ToString();
        }

        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            if (page < sumRecord)
                page++;

            txbPageBill.Text = page.ToString();

        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txbPageBill.Text = lastPage.ToString();
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnShowStaff_Click(object sender, EventArgs e)
        {
            LoadListStaff();
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnExitCategory_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadStaff_Click(object sender, EventArgs e)
        {
            txtsexstaff.Text = "";
            txtnamestaff.Text = "";
            txtaddressstaff.Text = "";
            txtnumberstaff.Text = "";
        }

        private void btnExitAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            txtTableName.Text = "";
            txtTableStatus.Text = "";
        }

        private void btnExitTable_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitStaff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListCategory();
                if (deleteCategory != null)
                    deleteCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa danh mục thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListCategory();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtidstaff.Text);

            if (StaffDAO.Instance.DeleteStaff(id))
            {
                MessageBox.Show("Xóa nhân viên thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListStaff();
                if (deleteStaff != null)
                    deleteStaff(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtidstaff.Text);
            string name = txtnamestaff.Text;
            string sex = txtsexstaff.Text;
            int numberphone = Convert.ToInt32(txtnumberstaff.Text);
            string address = txtaddressstaff.Text;
            

            if (StaffDAO.Instance.UpdateStaff(id, name, sex, numberphone, address))
            {
                MessageBox.Show("Sửa nhân viên thành công!!!","Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListStaff();
                if (updateStaff != null)
                    updateStaff(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa nhân viên", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTableID.Text);

            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListTable();
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTableID.Text);
            string name = txtTableName.Text;
            string status = txtTableStatus.Text;

            if (TableDAO.Instance.UpdateTable(id, name, status))
            {
                MessageBox.Show("Sửa bàn thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadListTable();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadAccount();
                if (deleteAccount != null)
                    deleteAccount(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string displayName = txbDisplayName.Text;
            //int type = (int)numericUpDown1.Value;

            if (AccountDAO.Instance.UpdateAccount(userName, displayName))
            {
                MessageBox.Show("Sửa tài khoản thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadAccount();
                if (updateAccount != null)
                    updateAccount(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa tài khoản", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            
        }
        private void export2Excel(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++) { obj.Cells[1, i] = g.Columns[i - 1].HeaderText; }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null) { obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            export2Excel(dtgvBill, @"D:\", "xuatfileExcel");
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            /*chart1.Series["Tổng tiền"].XValueMember = "Tổng tiền";
            chart1.Series["Tổng tiền"].YValueMembers = "Giảm giá";
            chart1.DataSource = dtgvBill;
            chart1.DataBind();*/


        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            fChangeAccount b = new fChangeAccount();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
           
            staffList.DataSource = SearchStaffByName(txtSearchStaff.Text);
        }
        List<Staff> SearchStaffByName(string name)
        {
            List<Staff> listStaff = StaffDAO.Instance.SearchStaffByName(name);

            return listStaff;
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            categoryList.DataSource = SearchCategoryByName(txtCategory.Text);
        }
        List<Category> SearchCategoryByName(string name)
        {
            List<Category> listCategory = CategoryDAO.Instance.SearchCategoryByName(name);

            return listCategory;
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            tableList.DataSource = SearchTableByName(txtTable.Text);
        }
        List<Table> SearchTableByName(string name)
        {
            List<Table> listTable = TableDAO.Instance.SearchTableByName(name);

            return listTable;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
           
        }
        
    }
    }


