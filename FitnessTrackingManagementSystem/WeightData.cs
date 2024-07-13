using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FitnessTrackingManagementSystem
{
    class WeightData
    {
        public int ID { set; get; }
        public double Weight { set; get; }
        public string Date { set; get; }

        public List<WeightData> weightDataList()
        {
            List<WeightData> listData = new List<WeightData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM weight_log";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    // create a data reader
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // read the data and store it in the class
                        WeightData wData = new WeightData();
                        wData.ID = (int)reader["id"];
                        wData.Weight = (double)reader["weight_value"];
                        wData.Date = ((DateTime)reader["date_insert"]).ToString("MM-dd-yyyy");

                        listData.Add(wData);

                    }
                }
                connect.Close();
            }
            return listData;
        }
    }
}
