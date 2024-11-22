using QuanLyQuanPho.DAO;
using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanPho
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountList = new BindingSource();

        private Account account;

        public Account Account { get => account; set => account = value; }

        public fAdmin()
        {
            InitializeComponent();
            Load();
        }

        #region Methods
        void Load()
        {
            LoadDateTimePickerForBill();
            LoadCheckBillByDate();
            LoadFoodCategory(cbxFoodCategory);
            AddCategoryBinding();
            LoadFoodList();
            AddFoodBinding();
            LoadTable();
            AddTableBinding();
            LoadAccount();
            AddAccountBinding();
        }

        void LoadTable()
        {
            tableList.DataSource = FoodTableDAO.Instance.GetTableList();
            dgvFoodTable.DataSource = tableList;
        }

        void AddTableBinding()
        {
            txbFoodTableId.DataBindings.Add(new Binding("Text", dgvFoodTable.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbFoodTableName.DataBindings.Add(new Binding("Text", dgvFoodTable.DataSource, "TableName", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetAccountList();
            dgvAccount.DataSource = accountList;
        }

        void AddAccountBinding()
        {
            txbUsserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayNameAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nudAccountType.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "AccountType", true, DataSourceUpdateMode.Never));
        }

        void LoadFoodCategory(ComboBox cbx)
        {
            categoryList.DataSource = FoodCategoryDAO.Instance.GetFoodCategory();
            dgvCategory.DataSource = categoryList;

            cbx.DataSource = FoodCategoryDAO.Instance.GetListFoodCategory();
            cbx.DisplayMember = "name";
        }

        void AddCategoryBinding()
        {
            txbCategoryId.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "CategoryName", true, DataSourceUpdateMode.Never));
        }

        void AddFoodBinding()
        {
            txbFoodId.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbFoodName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "FoodName", true, DataSourceUpdateMode.Never));
            nudFoodPrice.DataBindings.Add(new Binding("Value", dgvFood.DataSource, "UnitPrice", true, DataSourceUpdateMode.Never));
        }

        void LoadDateTimePickerForBill()
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadCheckBillByDate()
        {
            DateTime fromDate = dtpFromDate.Value;
            DateTime endDate = dtpEndDate.Value;
            dgvBill.DataSource = BillDAO.Instance.GetCheckBillByDate(fromDate, endDate);
        }

        void LoadFoodList()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
            dgvFood.DataSource = foodList;
        }

        void ChangeFoodCategoryByFoodId()
        {
            try
            {
                if (dgvFood.SelectedCells.Count > 0)
                {
                    string selectedCategoryName = dgvFood.SelectedCells[0].OwningRow.Cells["CategoryName"].Value.ToString();

                    foreach (FoodCategory foodCategory in cbxFoodCategory.Items)
                    {
                        if (selectedCategoryName == foodCategory.Name)
                        {
                            cbxFoodCategory.SelectedItem = foodCategory;

                        }
                    }

                }
            }

            catch { }
        }

        void AddNewFoodToFoodList()
        {
            string foodName = txbFoodName.Text;
            int categoryId = (cbxFoodCategory.SelectedItem as FoodCategory).ID;
            float price = (float)nudFoodPrice.Value;

            if (FoodDAO.Instance.AddNewFoodToFoodList(foodName, categoryId, price))
            {
                MessageBox.Show("Thêm món ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm món ăn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void EditFoodById()
        {
            int id = Int32.Parse(txbFoodId.Text);
            string foodName = txbFoodName.Text;
            int categoryId = (cbxFoodCategory.SelectedItem as FoodCategory).ID;
            float price = (float)nudFoodPrice.Value;

            if (FoodDAO.Instance.UpdateFoodById(id, foodName, categoryId, price))
            {
                MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }

            else
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DeleteFoodById()
        {
            int foodId = Int32.Parse(txbFoodId.Text);
            if (FoodDAO.Instance.DeleteFoodById(foodId))
            {
                MessageBox.Show("Xóa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa thông tin không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SearchFoodByName()
        {
            string foodName = txbSearchFood.Text;
            DataTable searchFoodData = FoodDAO.Instance.SearchFoodByName(foodName);
            foodList.DataSource = searchFoodData;
        }

        void AddNewCategory()
        {
            string categoryName = txbCategoryName.Text;
            if (FoodCategoryDAO.Instance.AddNewCategory(categoryName))
            {
                MessageBox.Show("Thêm doanh mục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFoodCategory(cbxFoodCategory);
                if (addCategory != null)
                {
                    addCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm doanh mục không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void EditCategory()
        {
            int categoryId = Int32.Parse(txbCategoryId.Text);
            string categoryName = txbCategoryName.Text;
            if (FoodCategoryDAO.Instance.EditCategory(categoryId, categoryName))
            {
                MessageBox.Show("Sửa doanh mục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFoodCategory(cbxFoodCategory);
                if (updateCategory != null)
                {
                    updateCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm doanh mục không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DeleteCategory()
        {
            int categoryId = Int32.Parse(txbCategoryId.Text);
            if (FoodCategoryDAO.Instance.DeleteCategory(categoryId))
            {
                MessageBox.Show("Xóa doanh mục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFoodCategory(cbxFoodCategory);
                if (xoaCategory != null)
                {
                    xoaCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa doanh mục không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddNewTableByName()
        {
            string tableName = txbFoodTableName.Text;
            if (FoodTableDAO.Instance.AddNewTableByName(tableName))
            {
                MessageBox.Show("Thêm bàn mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTable();
            }
            else
            {
                MessageBox.Show("Thêm bàn mới không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void UpdateTableByName()
        {
            int tableId = Int32.Parse(txbFoodTableId.Text);
            string tableName = txbFoodTableName.Text;
            if (FoodTableDAO.Instance.UpdateFoodTableById(tableId, tableName))
            {
                MessageBox.Show("Sửa thông tin bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTable();
            }
            else
            {
                MessageBox.Show("Sửa thông tin bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void DeleteFoodTableById()
        {
            int tableId = Int32.Parse(txbFoodTableId.Text);
            if (FoodTableDAO.Instance.DeleteFoodTableById(tableId))
            {
                MessageBox.Show("Xóa thông tin bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTable();
                if (deleteTable != null)
                {
                    deleteTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa thông tin bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddNewAccount()
        {
            string userName = txbUsserName.Text;
            string displayName = txbDisplayNameAccount.Text;
            int accountType = (int)nudAccountType.Value;

            if (AccountDAO.Instance.AddNewAccount(userName, displayName, accountType))
            {
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UpdateAccount()
        {
            string userName = txbUsserName.Text;
            string displayName = txbDisplayNameAccount.Text;
            int accountType = (int)nudAccountType.Value;

            if (AccountDAO.Instance.UpdateAccount(userName, displayName, accountType))
            {
                MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Sửa thông tin không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DeleteAccount()
        {
            string userName = txbUsserName.Text;

            if (userName == Account.UserName)
            {
                MessageBox.Show("Bạn không thể xóa tài khoản của chính mình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ResetPassword()
        {
            string userName = txbUsserName.Text;

            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadCheckBillByDate();
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadFoodList();
        }

        private void txbFoodId_TextChanged(object sender, EventArgs e)
        {
            ChangeFoodCategoryByFoodId();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm món này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                AddNewFoodToFoodList();
                LoadFoodList();
            }

        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                EditFoodById();
                LoadFoodList();
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                DeleteFoodById();
                LoadFoodList();
            }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            SearchFoodByName();
        }

        private void btnCategoryView_Click(object sender, EventArgs e)
        {
            LoadFoodCategory(cbxFoodCategory);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm doanh mục này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                AddNewCategory();
            }

        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa doanh mục này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                EditCategory();
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa doanh mục này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                DeleteCategory();
            }
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnViewFoodTable_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnAddFoodTable_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm bàn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                AddNewTableByName();
                if (addTable != null)
                {
                    addTable(this, new EventArgs());
                }
            }
        }

        private void btnEditFoodTable_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa thông tin bàn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                UpdateTableByName();
                if (updateTable != null)
                {
                    updateTable(this, new EventArgs());
                }
            }
        }

        private void btnDeteleFoodTable_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa thông tin bàn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                DeleteFoodTableById();
                if (deleteTable != null)
                {
                    deleteTable(this, new EventArgs());
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm tài khoản này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                AddNewAccount();
            }

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa thông tin tài khoản này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                UpdateAccount();
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                DeleteAccount();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn đặt lại mật khảu cho tài khoản này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                ResetPassword();
            }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler addCategory;
        public event EventHandler AddCategory
        {
            add { addCategory += value; }
            remove { addCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { UpdateCategory -= value; }
        }

        public event EventHandler xoaCategory;
        public event EventHandler XoaCategory
        {
            add { xoaCategory += value; }
            remove { xoaCategory -= value; }
        }

        public event EventHandler addTable;
        public event EventHandler AddTable
        {
            add { addTable += value; }
            remove { addTable -= value; }
        }

        public event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        public event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        #endregion
    }
}
