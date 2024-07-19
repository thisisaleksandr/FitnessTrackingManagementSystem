using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FitnessTrackingManagementSystem.Classes;

namespace FitnessTrackingManagementSystem
{
    public partial class Dashboard : UserControl
    {
        private User _currentUser;

        public Dashboard()
        {
            InitializeComponent();
        }

        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            dailyCalBurned();
            weekCalBurned();

            dailyCalConsumed();
            weekCalConsumed();

            dailyNet();
            weekNet();

            weightToday();
        }

        public void refreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            InitializeDashboard();
        }


        // daily summary
        public void dailyCalBurned()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string query = "SELECT SUM(calories) from fitness_log WHERE date_insert = @date_in AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    DateTime today = DateTime.Today;

                    cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if(result != DBNull.Value)
                    {
                        int todayCal = Convert.ToInt32(result);
                        dashboard_calBurnedToday.Text = todayCal.ToString();
                    }
                    else
                    {
                        dashboard_calBurnedToday.Text = "0";
                    }
                }
                connect.Close();
            }
        }
        public void weekCalBurned()
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
                    cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                    cmd.Parameters.AddWithValue("@startWeek", startWeek);
                    cmd.Parameters.AddWithValue("@endWeek", endWeek);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int weekCal = Convert.ToInt32(result);

                        dashboard_calBurnedWeek.Text = weekCal.ToString();
                    }
                    else
                    {
                        dashboard_calBurnedWeek.Text = "0";
                    }
                }
                connect.Close();
            }
        }

        public void dailyCalConsumed()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string query = "SELECT SUM(calories) from food_log WHERE date_insert = @date_in AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    DateTime today = DateTime.Today;

                    cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int todayCalCons = Convert.ToInt32(result);
                        dashboard_calConsumedToday.Text = todayCalCons.ToString();
                    }
                    else
                    {
                        dashboard_calConsumedToday.Text = "0";
                    }
                }
                connect.Close();
            }
        }
        public void weekCalConsumed()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                DateTime today = DateTime.Now.Date;

                DateTime startWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                DateTime endWeek = startWeek.AddDays(7);

                string query = $"SELECT SUM(calories) from food_log WHERE date_insert >= @startWeek AND date_insert <= @endWeek AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                    cmd.Parameters.AddWithValue("@startWeek", startWeek);
                    cmd.Parameters.AddWithValue("@endWeek", endWeek);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int weekCal = Convert.ToInt32(result);

                        dashboard_calConsumedWeek.Text = weekCal.ToString();
                    }
                    else
                    {
                        dashboard_calConsumedWeek.Text = "0";
                    }
                }
                connect.Close();
            }
        }
        public void dailyNet()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string query = @"
                        SELECT 
                            ISNULL(SUM(food_log.calories), 0) - ISNULL(SUM(fitness_log.calories), 0) 
                        FROM 
                            food_log 
                        LEFT JOIN 
                            fitness_log 
                        ON 
                            food_log.date_insert = fitness_log.date_insert 
                        WHERE 
                            food_log.date_insert = @date_in AND food_log.user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    DateTime today = DateTime.Today;

                    cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int todayNet = Convert.ToInt32(result);
                        dashboard_calNetToday.Text = todayNet.ToString();
                    }
                    else
                    {
                        dashboard_calNetToday.Text = String.Format("0 / {0}", _currentUser.Calorie_goal);

                        //dashboard_calNetToday.Text =  _currentUser.Username;
                    }
                }
                connect.Close();
            }
        }

        public void weekNet()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string query = "SELECT SUM(calories) FROM food_log WHERE date_insert = @date_in AND user_id = @user_id";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    DateTime today = DateTime.Today;

                    cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int todayCalCons = Convert.ToInt32(result);
                        dashboard_calNetWeek.Text = todayCalCons.ToString();
                    }
                    else
                    {
                        dashboard_calNetWeek.Text = String.Format("0 / {0}", _currentUser.Calorie_goal);

                        //dashboard_calNetToday.Text =  _currentUser.Username;
                    }
                }
            }
        }
        public void weightToday()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string query = "SELECT TOP 1 weight_value FROM weight_log WHERE user_id = @user_id ORDER BY date_insert DESC ";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    // DateTime today = DateTime.Today;

                    // cmd.Parameters.AddWithValue("@date_in", today);
                    cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int lastWeight = Convert.ToInt32(result);
                        dashboard_currWeight.Text = lastWeight.ToString();
                    }
                    else
                    {
                        dashboard_currWeight.Text = "0";
                    }
                }
                connect.Close();
            }
        }
    }
}
