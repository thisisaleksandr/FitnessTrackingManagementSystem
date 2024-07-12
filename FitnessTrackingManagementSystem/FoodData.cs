using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FitnessTrackingManagementSystem
{
    class FoodData
    {
        public int ID { set; get; }
        public string MealName { set; get; }
        public int Calories { set; get; }
        public string Date { set; get; }

        public List<FoodData> foodDataList()
        {
            List<FoodData> listData = new List<FoodData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM food_log";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    // create a data reader
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // read the data and store it in the class
                        FoodData fData = new FoodData();
                        fData.ID = (int)reader["id"];
                        fData.MealName = reader["meal_name"].ToString();
                        fData.Calories = (int)reader["calories"];
                        fData.Date = ((DateTime)reader["date_insert"]).ToString("MM-dd-yyyy");

                        listData.Add(fData);

                    }
                }
                connect.Close();
            }
            return listData;
        }
    }
}
