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

        private DailySummary _dailySummary = new DailySummary();
        private WeekSummary _weekSummary = new WeekSummary();
        private User _currentUser;

        private int dailyCalBurnedValue = 0;
        private int dailyCalConsumedValue = 0;

        private int weekCalBurnedValue = 0;
        private int weekCalConsumedValue = 0;

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
            _dailySummary.UpdateData(_currentUser);
            _weekSummary.UpdateData(_currentUser);

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
            // daily.Update()
            InitializeDashboard();
        }

        // daily summary
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
            dashboard_calNetToday.Text = String.Format("{0} / {1}", (-1*_dailySummary.CalculatedNet).ToString(), _currentUser.Calorie_goal);
        }

        public void weekNet()
        {
            dashboard_calNetWeek.Text = String.Format("{0} / {1}", (-1 * _weekSummary.CalculatedNet).ToString(), _currentUser.Calorie_goal*7);
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
