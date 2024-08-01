using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingManagementSystem.Classes
{
    public class DailySummary : Summary
    {
        // retrieve data from the database for updating values in the dashboard
        public override void UpdateData(User currentUser)
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();
                // for burned calories
                string query = "SELECT SUM(calories) from fitness_log WHERE date_insert = @date_in AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    DateTime today = DateTime.Today;

                    cmd.Parameters.AddWithValue("@user_id", currentUser.ID);
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        CaloriesBurned = Convert.ToInt32(result);
                        
                    }
                    else
                    {
                        CaloriesBurned = 0;
                    }
                }

                // for consumed calories
                query = "SELECT SUM(calories) from food_log WHERE date_insert = @date_in AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    DateTime today = DateTime.Today;

                    cmd.Parameters.AddWithValue("@user_id", currentUser.ID);
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        CaloriesConsumed = Convert.ToInt32(result);
                    }
                    else
                    {
                        CaloriesConsumed = 0;
                    }
                }

                CalculatedNet = CaloriesConsumed - CaloriesBurned - currentUser.Bmr_calories;

                connect.Close();
            }
        }
    }
}
