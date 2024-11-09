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
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();

            LoadTable();
        }

        #region Methods
        void LoadTable()
        {
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

        private void ShowBill(int tableId)
        {
            lsvBill.Items.Clear();

            List<Menu> listMenu = MenuDAO.Instance.GetListMenuByTableId(tableId);
            foreach (Menu menu in listMenu)
            {
                ListViewItem item = new ListViewItem(menu.ID.ToString());
                item.SubItems.Add(menu.FoodName);
                item.SubItems.Add(menu.Price.ToString());
                item.SubItems.Add(menu.Quantity.ToString());
                item.SubItems.Add(menu.TotalPrice.ToString());

                lsvBill.Items.Add(item);
            }

        }
        #endregion

        #region Events
        private void Button_Click(object? sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as FoodTable).ID;
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
    }
}
