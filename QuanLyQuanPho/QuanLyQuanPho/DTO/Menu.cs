using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DTO
{
    public class Menu
    {
        private int iD;
        private string foodName;
        private double price;
        private int quantity;
        private double totalPrice;

        public int ID { get => iD; set => iD = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Menu(int id, string foodName, double price, int quantity, double totalPrice)
        {
            this.ID = id;
            this.FoodName = foodName;
            this.Price = price;
            this.Quantity = quantity;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.FoodName = row["FoodName"].ToString();
            this.Price = (double)row["UnitPrice"];
            this.Quantity = (int)row["Quantity"];
            this.TotalPrice = (double)row["Total Price"];
        }
    }
}
