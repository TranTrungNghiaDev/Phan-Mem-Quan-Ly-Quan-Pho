using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DTO
{
    public class FoodCategory
    {
        private int iD;
        private string name;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }

        public FoodCategory(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public FoodCategory(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = (string)row["CategoryName"];
        }
    }
}
