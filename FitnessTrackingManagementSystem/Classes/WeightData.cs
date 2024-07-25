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
    class WeightData
    {
        public int ID { set; get; }
        public float Weight { set; get; }
        public string Date { set; get; }

        private User _current_user;

        public WeightData(User curr_user)
        {
            _current_user = curr_user;
        }

        public List<WeightData> weightDataList()
        {
            List<WeightData> listData = new List<WeightData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM weight_log WHERE user_id = @userid";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@userid", _current_user.ID);
                    cmd.ExecuteNonQuery();

                    // create a data reader
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
