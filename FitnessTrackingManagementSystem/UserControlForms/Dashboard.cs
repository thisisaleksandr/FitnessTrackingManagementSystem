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

namespace FitnessTrackingManagementSystem
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            dailyCalBurned();
        }

        // daily summary
        public void dailyCalBurned()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                connect.Open();

                string query = "SELECT SUM(calories) from fitness_log WHERE date_insert = @date_in";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    DateTime today = DateTime.Today;
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
                    
            }
        }
    }
}
