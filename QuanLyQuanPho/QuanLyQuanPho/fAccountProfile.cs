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
    public partial class fAccountProfile : Form
    {
        Account account;

        public Account Account { get => account; set => account = value; }

        public fAccountProfile(Account account)
        {
            InitializeComponent();
            this.Account = account;
            LoadAccountProfile();
        }

        #region Methods
        private void LoadAccountProfile()
        {
            txbUserName.Text = Account.UserName;
            txbDisplayName.Text = Account.DisplayName;
        }

        private void UpdateAccountProfile()
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            string password = txbPassword.Text;
            string newPassword = txbNewPassword.Text;
            string reNewPassword = txbReNewPassword.Text;

            if (displayName == null || displayName == "")
            {
                MessageBox.Show("Tên hiển thị không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (password == null || password == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (newPassword != reNewPassword)
            {
                MessageBox.Show("Mật khẩu mới không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (AccountDAO.Instance.UpdateAccountByUserNameAndPassword(userName, displayName, password, newPassword))
            {
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo");
            }

            else
            {
                MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountProfile();
        }

    }
}
