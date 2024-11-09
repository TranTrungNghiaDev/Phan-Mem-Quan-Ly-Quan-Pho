using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DTO
{
    public class BillInfo
    {
        private int id;
        private int billId;
        private int foodId;
        private int quantity;

        public int Id { get => id; set => id = value; }
        public int BillId { get => billId; set => billId = value; }
        public int FoodId { get => foodId; set => foodId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public BillInfo(int id, int billId, int foodId, int quantity)
        {
            this.Id = id;
            this.BillId = billId;
            this.FoodId = foodId;
            this.Quantity = quantity;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (int)row["id"];
            this.BillId = (int)row["BillId"];
            this.FoodId = (int)row["FoodId"];
            this.Quantity = (int)row["Quantity"];
        }
    }
}
