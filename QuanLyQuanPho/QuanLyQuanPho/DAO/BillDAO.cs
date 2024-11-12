using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DataProvider.Instance.ExcuteNonQuery(query, new object[] {tableId});
            
        }

        public int GetLastestBillId()
        {
            string query = @"EXEC USP_GetLastestBillId";
            return (int)DataProvider.Instance.ExcuteScalar(query);
        }

        public void CheckOut(int uncheckBillID)
        {
            string query = @"EXEC USP_CheckOutBillByBillID @BillID ";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] {uncheckBillID});
        }
    }
}
