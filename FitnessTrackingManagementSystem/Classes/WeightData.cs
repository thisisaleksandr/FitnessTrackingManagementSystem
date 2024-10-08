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
    class WeightData: DataLog<WeightData>
    {
        public override int ID { get; set; }
        public float Weight { set; get; }
        public override string Date { get; set; }

        public WeightData(User curr_user) : base(curr_user)
        {
        }

        // get last 12 entries from the database to populate the table
        public override List<WeightData> GetLastEntries()
        {
            List<WeightData> listData = new List<WeightData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM (SELECT TOP 12 * FROM weight_log WHERE user_id = @userid ORDER BY date_insert DESC, id DESC) AS subquery ORDER by date_insert ASC, id ASC";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@userid", _current_user.ID);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // read the data and store it in the class
                        WeightData wData = new WeightData(_current_user);
                        wData.ID = reader.GetInt32(reader.GetOrdinal("id"));
                        wData.Weight = (float)reader.GetDouble(reader.GetOrdinal("weight_value"));
                        wData.Date = reader.GetDateTime(reader.GetOrdinal("date_insert")).ToString("MM-dd-yyyy");

                        listData.Add(wData);
                    }
                }
                connect.Close();
            }
            return listData;
        }
    }
}
