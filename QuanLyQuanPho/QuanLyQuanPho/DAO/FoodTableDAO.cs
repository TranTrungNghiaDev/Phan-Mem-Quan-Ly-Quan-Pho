using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DAO
{
    public class FoodTableDAO
    {
        private static FoodTableDAO instance;

        public static FoodTableDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodTableDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private FoodTableDAO() { }

        public List<FoodTable> GetFoodTableList()
        {
            List<FoodTable> foodTableList = new List<FoodTable>();

            string query = "EXEC USP_GetFoodTableList";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                FoodTable foodTable = new FoodTable(row);
                foodTableList.Add(foodTable);
            }

            
            return foodTableList;
        }
    }
}
