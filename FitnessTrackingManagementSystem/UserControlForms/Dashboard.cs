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
        // summary classes
        private DailySummary _dailySummary = new DailySummary();
        private WeekSummary _weekSummary = new WeekSummary();

        private User _currentUser;

        public Dashboard()
        {
            InitializeComponent();
        }

        // to work with the current user
        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            InitializeDashboard();
        }

        // display values in the forms
        private void InitializeDashboard()
        {
            _dailySummary.UpdateData(_currentUser);
            _weekSummary.UpdateData(_currentUser);

            dailyCalBurned();
            weekCalBurned();

            dailyCalConsumed();
            weekCalConsumed();

            dailyNet();
            weekNet();

            weightToday();

            setDayCalGoal();
            setWeekCalGoal();

            setDayGoalAchieved();
        }

        public void refreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            // daily.Update()
            InitializeDashboard();
        }

        // show value based on if the goal has been achieved
        public void setDayGoalAchieved()
        {
            if (-1 * _dailySummary.CalculatedNet >= _currentUser.Calorie_goal)
            {
                dashboard_calGoalAchToday.Text = "YES";
                dashboard_calGoalAchToday.ForeColor = Color.Green;
            }
            else
            {
                dashboard_calGoalAchToday.Text = "NO";
                dashboard_calGoalAchToday.ForeColor = Color.Red;
            }
        }

        /* next functions will make some calculations and then 
         * set new values to the labels in the form */
        public void setDayCalGoal()
        {
            dashboard_calGoalToday.Text = _currentUser.Calorie_goal.ToString();
        }
        public void setWeekCalGoal()
        {
            dashboard_calGoalWeek.Text = (_currentUser.Calorie_goal * 7).ToString();
        }
        public void dailyCalBurned()
        {
            dashboard_calBurnedToday.Text = _dailySummary.CaloriesBurned.ToString();
        }
        public void weekCalBurned()
        {
            dashboard_calBurnedWeek.Text = _weekSummary.CaloriesBurned.ToString();
        }
        public void dailyCalConsumed()
        {
            dashboard_calConsumedToday.Text = _dailySummary.CaloriesConsumed.ToString();
        }
        public void weekCalConsumed()
        {
            dashboard_calConsumedWeek.Text = _weekSummary.CaloriesConsumed.ToString();
        }
        public void dailyNet()
        {
            dashboard_calNetToday.Text = (-1 * _dailySummary.CalculatedNet).ToString();
        }
        public void weekNet()
        {
            dashboard_calNetWeek.Text = (-1 * _weekSummary.CalculatedNet).ToString();
        }
        public void weightToday()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string query = "SELECT TOP 1 weight_value FROM weight_log WHERE user_id = @user_id ORDER BY date_insert DESC, id DESC";

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

        // click on the question button will show the calculation information 
        private void dashboard_aboutCalculation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deficit = Calories Consumed - Calories Burned - Daily Calorie Needs", "Calculation Information", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
