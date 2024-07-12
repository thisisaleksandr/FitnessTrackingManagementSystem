﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FitnessTrackingManagementSystem
{
    // class to store the data and then retrive it in a table in the fitness log form
    class FitnessData
    {
        public int ID { set; get; }
        public string Activity { set; get; }
        public int Duration {  set; get; }
        public int Calories {  set; get; }
        public string Date {  set; get; }

        public List<FitnessData> fitnessDataList()
        {
            List<FitnessData> listData = new List<FitnessData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM fitness_log";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    // create a data reader
                    SqlDataReader reader = cmd.ExecuteReader();
 
                    while (reader.Read())
                    {
                        // read the data and store it in the class
                        FitnessData fData = new FitnessData();
                        fData.ID = (int)reader["id"];
                        fData.Activity = reader["activity"].ToString();
                        fData.Duration = (int)reader["duration"];
                        fData.Calories = (int)reader["calories"];
                        fData.Date = reader["date_insert"].ToString();

                        listData.Add(fData);
                        
                    }
                }
            }
            return listData;
        }

    }
}
