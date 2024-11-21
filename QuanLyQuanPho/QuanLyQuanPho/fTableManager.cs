using QuanLyQuanPho.DAO;
using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanPho
{
    public partial class fTableManager : Form
    {
        Account account;

        public Account Account
        {
            get => account;
            set
            {
                account = value;
                EnableAdminToolStripMenuByAccountType();
            }
        }

        public fTableManager(Account account)
        {
            InitializeComponent();

            LoadTable();
            LoadSwitchTable();
            LoadListFoodCategory();
            this.Account = account;
        }

        #region Methods
        void LoadTable()
        {
            flpTable.Controls.Clear();

            List<FoodTable> foodTables = FoodTableDAO.Instance.GetFoodTableList();
            foreach (FoodTable table in foodTables)
            {
                Button button = new Button() { Width = FoodTableDAO.TableWidth, Height = FoodTableDAO.TableHeight };
                button.Text = table.Name + Environment.NewLine + table.Status;
                button.Click += Button_Click;
                button.Tag = table;

                switch (table.Status)
                {
                    case ("Trống"):

                        button.BackColor = Color.Aqua;
                        break;

                    default:
                        button.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(button);
            }
        }

        void LoadListFoodCategory()
        {
            List<FoodCategory> listFoodCategory = FoodCategoryDAO.Instance.GetListFoodCategory();
            if (listFoodCategory.Count > 0)
            {
                cbxCategoryFood.DataSource = listFoodCategory;
                cbxCategoryFood.DisplayMember = "Name";
            }
        }

        void LoadListFoodByCategoryId(int categoryId)
        {
            List<Food> foodList = FoodDAO.Instance.GetListFoodByCategoryId(categoryId);
            cbxFood.DataSource = foodList;
            cbxFood.DisplayMember = "Name";
        }

        private void ShowBill(int tableId)
        {
            lsvBill.Items.Clear();

            List<Menu> listMenu = MenuDAO.Instance.GetListMenuByTableId(tableId);
            double totalPrice = 0;
            float discount = (float)nmDiscount.Value / 100;
            foreach (Menu menu in listMenu)
            {
                ListViewItem item = new ListViewItem(menu.FoodName.ToString());
                item.SubItems.Add(menu.Price.ToString());
                item.SubItems.Add(menu.Quantity.ToString());
                item.SubItems.Add(menu.TotalPrice.ToString());

                totalPrice += menu.TotalPrice;
                lsvBill.Items.Add(item);
            }
            totalPrice = totalPrice * (1 - discount);
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;

            txbTotalPrice.Text = totalPrice.ToString("c", cultureInfo);
        }

        private void LoadSwitchTable()
        {
            cbxSwitchTable.DataSource = FoodTableDAO.Instance.GetFoodTableList();
            cbxSwitchTable.DisplayMember = "Name";
        }

        private void EnableAdminToolStripMenuByAccountType()
        {
            if (Account.AccountType == 1)
            {
                adminToolStripMenuItem.Enabled = true;
            }
            else
            {
                adminToolStripMenuItem.Enabled = false;
            }
        }
        #endregion

        #region Events
        private void Button_Click(object? sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as FoodTable).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableId);
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile fAccountProfile = new fAccountProfile(this.Account);
            fAccountProfile.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.InsertFood += FAdmin_InsertFood;
            fAdmin.UpdateFood += FAdmin_UpdateFood;
            fAdmin.DeleteFood += FAdmin_DeleteFood;

            fAdmin.AddCategory += FAdmin_AddCategory;
            fAdmin.UpdateCategory += FAdmin_UpdateCategory;
            fAdmin.XoaCategory += FAdmin_XoaCategory;

            fAdmin.AddTable += FAdmin_AddTable;
            fAdmin.UpdateTable += FAdmin_UpdateTable;
            fAdmin.DeleteTable += FAdmin_DeleteTable;
            fAdmin.ShowDialog();
        }

        private void FAdmin_DeleteTable(object? sender, EventArgs e)
        {
            LoadTable();
        }

        private void FAdmin_UpdateTable(object? sender, EventArgs e)
        {
            LoadTable();
        }

        private void FAdmin_AddTable(object? sender, EventArgs e)
        {
            LoadTable();
        }

        private void FAdmin_XoaCategory(object? sender, EventArgs e)
        {
            LoadListFoodCategory();
            LoadListFoodByCategoryId((cbxCategoryFood.SelectedItem as FoodCategory).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as FoodTable).ID);
            }
        }

        private void FAdmin_UpdateCategory(object? sender, EventArgs e)
        {
            LoadListFoodCategory();
            LoadListFoodByCategoryId((cbxCategoryFood.SelectedItem as FoodCategory).ID);
        }

        private void FAdmin_AddCategory(object? sender, EventArgs e)
        {
            LoadListFoodCategory();
        }

        private void FAdmin_DeleteFood(object? sender, EventArgs e)
        {
            LoadListFoodByCategoryId((cbxCategoryFood.SelectedItem as FoodCategory).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as FoodTable).ID);
            }
            LoadTable();
        }

        private void FAdmin_UpdateFood(object? sender, EventArgs e)
        {
            LoadListFoodByCategoryId((cbxCategoryFood.SelectedItem as FoodCategory).ID);
            if(lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as FoodTable).ID);
            }
        }

        private void FAdmin_InsertFood(object? sender, EventArgs e)
        {
            LoadListFoodByCategoryId((cbxCategoryFood.SelectedItem as FoodCategory).ID);
        }

        private void cbxCategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem == null)
            {
                return;
            }
            else
            {
                FoodCategory foodCategory = comboBox.SelectedItem as FoodCategory;
                id = foodCategory.ID;
                LoadListFoodByCategoryId(id);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if(lsvBill.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần đặt món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FoodTable foodTable = lsvBill.Tag as FoodTable;
            Food food = cbxFood.SelectedItem as Food;

            if (foodTable != null)
            {
                int tableId = foodTable.ID;
                int billId = BillDAO.Instance.GetBillIdByTableId(tableId);
                int quantity = (int)nmQuantityFood.Value;

                if (billId == -1)
                {
                    BillDAO.Instance.CreateBillByTableId(tableId);
                    billId = BillDAO.Instance.GetLastestBillId();
                }

                int foodId = food.ID;
                BillInfoDAO.Instance.CreateBillInfoByBillID(billId, foodId, quantity);
                ShowBill(tableId);
                LoadTable();
            }

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            FoodTable foodTable = (lsvBill.Tag as FoodTable);
            int tableID = foodTable.ID;
            int uncheckBillID = BillDAO.Instance.GetBillIdByTableId(tableID);
            int discount = (int)nmDiscount.Value;
            int totalPrice = Int32.Parse(txbTotalPrice.Text.Split(" ")[0].Replace(".", ""));

            if (uncheckBillID > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn thanh toán hóa đơn cho " + foodTable.Name + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    BillDAO.Instance.CheckOut(uncheckBillID, discount, totalPrice);
                    ShowBill(tableID);
                    LoadTable();
                }
            }
        }

        private void nmDiscount_ValueChanged(object sender, EventArgs e)
        {
            FoodTable foodTable = lsvBill.Tag as FoodTable;
            int discount = (int)nmDiscount.Value;
            if (foodTable != null)
            {
                ShowBill(foodTable.ID);
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            FoodTable firstTable = lsvBill.Tag as FoodTable;
            FoodTable secondTable = cbxSwitchTable.SelectedItem as FoodTable;

            DialogResult dialogResult = MessageBox.Show(
                String.Format("Bạn có chắc muốn chuyển từ {0} sang {1} không ?", firstTable.Name, secondTable.Name),
                "Thông Báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                BillDAO.Instance.SwitchBillByTableID(firstTable.ID, secondTable.ID);
                LoadTable();
                ShowBill(firstTable.ID);
            }
        }

        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            FoodTable firstTable = lsvBill.Tag as FoodTable;
            FoodTable secondTable = cbxSwitchTable.SelectedItem as FoodTable;

            DialogResult dialogResult = MessageBox.Show(
                String.Format("Bạn có chắc muốn gộp từ {0} sang {1} không ?", firstTable.Name, secondTable.Name),
                "Thông Báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                BillDAO.Instance.MergeBillByTableID(firstTable.ID, secondTable.ID);
                LoadTable();
                ShowBill(firstTable.ID);
            }
        }
        #endregion
    }
}
