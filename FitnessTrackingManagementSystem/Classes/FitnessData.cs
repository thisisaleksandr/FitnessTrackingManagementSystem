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
    class FitnessData: DataLog<FitnessData>
    {
        public override int ID { get; set; }
        public string Activity { get; set; }
        public int Duration { get; set; }
        public int Calories { get; set; }
        public override string Date { get; set; }

        public FitnessData(User curr_user):base(curr_user)
        {
        }

        // get last 12 entries from the database to populate the table
        public override List<FitnessData> GetLastEntries()
        {
            List<FitnessData> listData = new List<FitnessData>();

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string selectData = "SELECT * FROM (SELECT TOP 12 * FROM fitness_log WHERE user_id = @userid ORDER BY date_insert DESC, id DESC) AS subquery ORDER by date_insert ASC, id ASC";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@userid", _current_user.ID);
                    cmd.ExecuteNonQuery();

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
