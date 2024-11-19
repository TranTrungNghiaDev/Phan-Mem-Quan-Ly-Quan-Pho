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
            txbFoodId.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Id"));
            txbFoodName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "FoodName"));
            nudFoodPrice.DataBindings.Add(new Binding("Value", dgvFood.DataSource, "UnitPrice"));

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
        #endregion



        private void txbFoodId_TextChanged(object sender, EventArgs e)
        {
            ChangeFoodCategoryByFoodId();
        }
    }
}
