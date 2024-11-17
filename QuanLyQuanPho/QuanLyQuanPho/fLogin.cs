using QuanLyQuanPho.DAO;
using QuanLyQuanPho.DTO;
using System.Data;

namespace QuanLyQuanPho
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string password = txbPassword.Text;

            if(Login(userName, password))
            {
                DataTable accountData = AccountDAO.Instance.GetAccountByUserName(userName);
                Account account = new Account(accountData.Rows[0]);

                fTableManager fTableManager = new fTableManager(account);
                this.Hide();
                fTableManager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }

        private bool Login(string userNamer, string password)
        {
            return AccountDAO.Instance.Login(userNamer, password);
        }
    }
}
