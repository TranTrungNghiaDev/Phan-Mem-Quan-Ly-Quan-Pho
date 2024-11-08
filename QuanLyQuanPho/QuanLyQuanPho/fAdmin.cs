using QuanLyQuanPho.DAO;
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
        public fAdmin()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            string query = "EXEC USP_GetAccountByUserName @UserName";

            dgvAccount.DataSource = DataProvider.Instance.ExcuteQuery(query, new object[] {"TranNghia98"});
        }
    }
}
