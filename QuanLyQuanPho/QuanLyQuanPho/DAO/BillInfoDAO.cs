using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillInfoDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfoByBillId(int billId)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            string query = @"EXEC USP_GetListBillInfoByBillId @BillId ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { billId });
            foreach (DataRow row in data.Rows)
            {
                BillInfo billInfo = new BillInfo(row);
                listBillInfo.Add(billInfo);
            }
            return listBillInfo;
        }

        public void CreateBillInfoByBillID(int billId, int foodId, int quantity)
        {
            string query = @"EXEC USP_CreateBillInfoByBillAndFoodId @billId , @TableID , @Quantity ";
            DataProvider.Instance.ExcuteQuery(query, new object[] { billId, foodId, quantity });
        }

        public bool DeleteBillInfoByID(int billId)
        {
            string query = @"EXEC USP_DELETEBillInfoByFoodId @FoodId ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { billId });
            return result > 0;
        }
    
        public void DeleteBillInfoByCategoryId(int categoryId)
        {
            string query = @"EXEC USP_DeleteBillInfoByCategoryId @CategoryId ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { categoryId });
        }
    }
}
