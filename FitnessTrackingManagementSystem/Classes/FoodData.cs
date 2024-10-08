﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FitnessTrackingManagementSystem.Classes;

namespace FitnessTrackingManagementSystem
{
    class FoodData: DataLog<FoodData>
    {
        public override int ID { get; set; }
        public string Meal { set; get; }
        public int Calories { set; get; }
        public override string Date { get; set; }

        public FoodData(User curr_user) : base(curr_user)
        {
        }

        // get last 12 entries from the database to populate the table
        public override List<FoodData> GetLastEntries()
        {
            List<FoodData> listData = new List<FoodData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM (SELECT TOP 12 * FROM food_log WHERE user_id = @userid ORDER BY date_insert DESC, id DESC) AS subquery ORDER by date_insert ASC, id ASC";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@userid", _current_user.ID);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // read the data and store it in the class
                        FoodData fData = new FoodData(_current_user);
                        fData.ID = (int)reader["id"];
                        fData.Meal = reader["meal_name"].ToString();
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
