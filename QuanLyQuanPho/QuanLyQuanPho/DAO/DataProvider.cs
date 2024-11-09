using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;


        string connectString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyQuanPho;Integrated Security=True";

        internal static DataProvider Instance {
            get 
            { 
                if(instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            } 
            private set => instance = value; 
        }

        private DataProvider() { }

        public DataTable ExcuteQuery(string query, object[] paramater = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] listParamater = query.Split(" ");
                    int i = 0;
                    foreach (string item in listParamater) {
                        if(item.Contains("@"))
                        {
                            sqlCommand.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExcuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] listParamater = query.Split(" ");
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains("@"))
                        {
                            sqlCommand.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data = sqlCommand.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExcuteScalar(string query, object[] paramater = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] listParamater = query.Split(" ");
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains("@"))
                        {
                            sqlCommand.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data = sqlCommand.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
