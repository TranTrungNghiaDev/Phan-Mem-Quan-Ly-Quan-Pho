using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DTO
{
    public class FoodTable
    {
        private int iD;
        private string name;
        private string status;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }

        public FoodTable(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }

        public FoodTable(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.Name = row["TableName"].ToString();
            this.Status = row["TableStatus"].ToString();
        }
    }
}
