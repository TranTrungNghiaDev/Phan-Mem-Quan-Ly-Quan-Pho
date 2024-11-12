using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DTO
{
    public class Food
    {
        private int iD;
        private string name;
        private int categoryId;
        private double price;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public double Price { get => price; set => price = value; }

        public Food(int id, string name, int categoryId, double price)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryId = categoryId;
            this.Price = price;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.Name = (string)row["FoodName"];
            this.CategoryId = (int)row["CategoryId"];
            this.Price = (double)row["UnitPrice"];
        }
    }
}
