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
            LoadFoodList();
            AddFoodBinding();
        }

        void LoadFoodCategory(ComboBox cbx)
        {
            cbx.DataSource = FoodCategoryDAO.Instance.GetListFoodCategory();
            cbx.DisplayMember = "name";
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
        #endregion
    }
}
