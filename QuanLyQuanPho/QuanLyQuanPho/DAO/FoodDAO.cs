using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
    
        public DataTable GetListFood()
        {
            string query = @"USP_GetFoodList";
            return DataProvider.Instance.ExcuteQuery(query);
        }
    
        public bool AddNewFoodToFoodList(string foodName, int categoryId, float price)
        {
            string query = @"EXEC USP_AddNewFoodToFoodList @FoodName , @CategoryID , @UnitPrice ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { foodName, categoryId, price });
            return result > 0;
        }
    
        public bool UpdateFoodById(int id, string foodName, int categoryId, float price)
        {
            string query = @"EXEC USP_UpdateFoodByFoodId @FoodId , @FoodName , @CategoryID , @UnitPrice ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, foodName, categoryId, price });
            return result > 0;
        }

        public bool DeleteFoodById(int id) {
            string query = @"EXEC USP_DeleteFoodById @FoodId ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id });
            return result > 0;
        }
    }
}
