using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTableId(int tableId)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = @"EXEC USP_GetMenuByTableID @TableID ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { tableId });
            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    Menu menu = new Menu(row);
                    listMenu.Add(menu);
                }
            }

            return listMenu;
        }
    }
}
