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
        private string foodName;
        private double price;
        private int quantity;
        private double totalPrice;

        public string FoodName { get => foodName; set => foodName = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Menu(string foodName, double price, int quantity, double totalPrice)
        {
            this.FoodName = foodName;
            this.Price = price;
            this.Quantity = quantity;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.FoodName = row["FoodName"].ToString();
            this.Price = (double)row["UnitPrice"];
            this.Quantity = (int)row["Quantity"];
            this.TotalPrice = (double)row["Total Price"];
        }
    }
}
