using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DAO
{
    public class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;

        public static FoodCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodCategoryDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private FoodCategoryDAO() { }

        public List<FoodCategory> GetListFoodCategory()
        {
            List<FoodCategory> listFoodCategory = new List<FoodCategory>();

            string query = @"EXEC USP_GetListFoodCategory";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                FoodCategory foodCategory = new FoodCategory(row);
                listFoodCategory.Add(foodCategory);
            }
            return listFoodCategory;
        }
    
        public DataTable GetFoodCategory()
        {
            string query = @"EXEC USP_GetListFoodCategory";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public bool AddNewCategory(string categoryName)
        {
            string query = @"EXEC USP_AddNewFoodCategory @CategoryName ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { categoryName });
            return result > 0;
        }

        public bool EditCategory(int id, string categoryName)
        {
            string query = @"EXEC USP_EditFoodCategory @Id , @CategoryName ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, categoryName });
            return result > 0;
        }

        public bool DeleteCategory(int id) {
            if(FoodDAO.Instance.DeleteFoodByCategoryId(id))
            {
                string query = @"EXEC USP_DeleteFoodCategoryById @Id ";
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id });
                return result > 0;
            }
            return false;
        }
    }
}
