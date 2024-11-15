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
            LoadDateTimePickerForBill();
            LoadCheckBillByDate();
        }

        #region Methods
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
        #endregion

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadCheckBillByDate();
        }
        #endregion


    }
}
