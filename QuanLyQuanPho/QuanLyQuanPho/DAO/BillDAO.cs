using QuanLyQuanPho.DTO;
using System.Data;

namespace QuanLyQuanPho.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private BillDAO() { }

        // Thành công nếu kết quá GetBillIdByTableId () là id
        // Thất bại nếu kết quả GetBillIdByTableId là: -1

        public int GetBillIdByTableId(int tableId)
        {
            string query = "EXEC USP_GetUnCheckBillByTableId @TableId ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { tableId });
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        public void CreateBillByTableId(int tableId)
        {
            string query = @"EXEC USP_CreateUncheckBillByTableID @TableID ";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { tableId });
        }

        public int GetLastestBillId()
        {
            string query = @"EXEC USP_GetLastestBillId";
            return (int)DataProvider.Instance.ExcuteScalar(query);
        }

        public void CheckOut(int uncheckBillID, int discount, int totalPrice)
        {
            string query = @"EXEC USP_CheckOutBillByBillID @BillID , @Discount , @TotalPrice";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { uncheckBillID, discount, totalPrice });
        }

        public void SwitchBillByTableID(int firstTableID, int secondTableID)
        {
            string query = @"EXEC USP_SwitchBillByTableId @firstTableID , @secondTableID ";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { firstTableID, secondTableID });
        }

        public void MergeBillByTableID(int firstTableID, int secondTableID)
        {
            string query = @"EXEC USP_MergeBillByTableId @firstTableID , @secondTableID ";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { firstTableID, secondTableID });
        }

        public DataTable GetCheckBillByDate(DateTime fromDate, DateTime endDate)
        {
            string query = @"EXEC USP_GetCheckBillByDate @fromDate , @endDate";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { fromDate, endDate });
        }

        public DataTable GetCheckBillByDateAndPage(DateTime fromDate, DateTime endDate, int page)
        {
            string query = @"EXEC USP_GetCheckBillByDateAndPage @fromDate , @endDate , @page";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { fromDate, endDate, page });
        }

        public int GetTotalCheckBillByDate(DateTime fromDate, DateTime endDate)
        {
            string query = @"EXEC USP_GetTotalCheckBillByDate @dateCheckIn , @dateCheckOut ";
            return (int)DataProvider.Instance.ExcuteScalar(query, new object[] { fromDate, endDate });
        }

    }
}
