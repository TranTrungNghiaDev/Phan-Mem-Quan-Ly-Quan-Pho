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
        public fTableManager()
        {
            InitializeComponent();

            LoadTable();
            LoadSwitchTable();
            LoadListFoodCategory();
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
        #endregion

        #region Events
        private void Button_Click(object? sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as FoodTable).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableId);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile fAccountProfile = new fAccountProfile();
            fAccountProfile.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
        }
        #endregion

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

            if (uncheckBillID > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn thanh toán hóa đơn cho " + foodTable.Name + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    BillDAO.Instance.CheckOut(uncheckBillID, discount);
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
            
            if(dialogResult == DialogResult.Yes)
            {
                BillDAO.Instance.SwitchBillByTableID(firstTable.ID, secondTable.ID);
                LoadTable();
            }
        }
    }
}
