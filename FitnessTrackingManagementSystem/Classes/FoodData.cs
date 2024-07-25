using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FitnessTrackingManagementSystem.Classes;

namespace FitnessTrackingManagementSystem
{
    class FoodData
    {
        public int ID { set; get; }
        public string MealName { set; get; }
        public int Calories { set; get; }
        public string Date { set; get; }

        private User _current_user;

        public FoodData(User curr_user)
        {
            _current_user = curr_user;
        }

        public List<FoodData> foodDataList()
        {
            List<FoodData> listData = new List<FoodData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM food_log WHERE user_id = @userid";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@userid", _current_user.ID);
                    cmd.ExecuteNonQuery();

                    // create a data reader
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // read the data and store it in the class
                        FoodData fData = new FoodData(_current_user);
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
