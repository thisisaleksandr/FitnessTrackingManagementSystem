using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingManagementSystem.Classes
{
    public class WeekSummary : Summary
    {
        private int _daysSinceWeekStart;
        public int DaysSinceWeekStart { get { return _daysSinceWeekStart; } }
        
        public override void UpdateData(User currentUser)
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                DateTime endWeek = startWeek.AddDays(7);

                string query = $"SELECT SUM(calories) from fitness_log WHERE date_insert >= @startWeek AND date_insert <= @endWeek AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@user_id", currentUser.ID);
                    cmd.Parameters.AddWithValue("@startWeek", startWeek);
                    cmd.Parameters.AddWithValue("@endWeek", endWeek);

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
                query = $"SELECT SUM(calories) from food_log WHERE date_insert >= @startWeek AND date_insert <= @endWeek AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@user_id", currentUser.ID);
                    cmd.Parameters.AddWithValue("@startWeek", startWeek);
                    cmd.Parameters.AddWithValue("@endWeek", endWeek);

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

                CalculatedNet = CaloriesConsumed - CaloriesBurned - currentUser.Bmr_calories * getDaysSinceWeekStart();
                
                connect.Close();
            }
        }

        public int getDaysSinceWeekStart()
        {
            DayOfWeek startOfWeek = DayOfWeek.Sunday;
            _daysSinceWeekStart = ((int)DateTime.Now.DayOfWeek - (int)startOfWeek + 7) % 7 + 1;
            return _daysSinceWeekStart;
        }
    }
}
