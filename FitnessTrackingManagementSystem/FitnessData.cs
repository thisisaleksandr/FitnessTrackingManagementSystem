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
    // class to store the data and then retrive it in a table in the fitness log form
    class FitnessData
    {
        public int ID { set; get; }
        public string Activity { set; get; }
        public int Duration {  set; get; }
        public int Calories {  set; get; }
        public string Date {  set; get; }

        private User _current_user;

        public FitnessData(User curr_user)
        {
            _current_user = curr_user;
        }

        public List<FitnessData> fitnessDataList()
        {
            List<FitnessData> listData = new List<FitnessData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM fitness_log WHERE user_id = @userid";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@userid", _current_user.ID);
                    cmd.ExecuteNonQuery();

                    // create a data reader
                    SqlDataReader reader = cmd.ExecuteReader();
 
                    while (reader.Read())
                    {
                        // read the data and store it in the class
                        FitnessData fData = new FitnessData(_current_user);
                        fData.ID = (int)reader["id"];
                        fData.Activity = reader["activity"].ToString();
                        fData.Duration = (int)reader["duration"];
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
