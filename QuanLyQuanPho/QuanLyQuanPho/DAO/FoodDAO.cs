using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private FoodDAO() { }

        public List<Food> GetListFoodByCategoryId(int categoryId)
        {
            List<Food> listFood = new List<Food>();
            string query = @"EXEC USP_GetListFoodByCategoryId @CategoryId ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { categoryId });
            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                listFood.Add(food);
            }
            return listFood;
        }
    }
}
