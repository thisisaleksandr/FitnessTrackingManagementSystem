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
    class WeightData: DataLog<WeightData>
    {
        public float Weight { set; get; }

        public WeightData(User curr_user) : base(curr_user)
        {
        }

        public override List<WeightData> getLastEntries()
        {
            List<WeightData> listData = new List<WeightData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM (SELECT TOP 12 * FROM weight_log WHERE user_id = @userid ORDER BY date_insert DESC) AS subquery ORDER by date_insert ASC";

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
                        wData.DateString = reader.GetDateTime(reader.GetOrdinal("date_insert")).ToString("MM-dd-yyyy");

                        listData.Add(wData);

                    }
                }
                connect.Close();
            }
            return listData;
        }
    }
}
