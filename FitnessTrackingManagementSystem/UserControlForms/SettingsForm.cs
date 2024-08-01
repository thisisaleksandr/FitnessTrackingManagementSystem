using FitnessTrackingManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTrackingManagementSystem
{
    public partial class SettingsForm : UserControl
    {
        private int updatedNeeds;
        private int updatedGoal;
        private User _currentUser;

        public SettingsForm()
        {
            InitializeComponent();
        }

        // to work with the current user in this class
        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            InitializeSettingsLog();
        }

        private void InitializeSettingsLog()
        {
            displayCurrentSettings();
        }

        // displays current user's settings 
        public void displayCurrentSettings() {
            settings_currentDailyNeeds.Text = String.Format("{0} kcal / day", _currentUser.Bmr_calories);
            settings_CurrentDeficitGoal.Text = String.Format("{0} kcal / day", _currentUser.Calorie_goal);
        }
        
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            InitializeSettingsLog();
        }

        // click on update caloric needs button 
        private void settings_updateCaloricNeedsBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(settings_dailyCaloricNeeds.Text, out int value) == false)
            {
                MessageBox.Show("The Calorie value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                updatedNeeds = int.Parse(settings_dailyCaloricNeeds.Text);
                _currentUser.Bmr_calories = updatedNeeds;

                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    connect.Open();

                    string updateData = "UPDATE users SET bmr_calories = @bmr WHERE id = @id ";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentUser.ID);
                        cmd.Parameters.AddWithValue("@bmr", updatedNeeds);

                        cmd.ExecuteNonQuery();

                        settings_dailyCaloricNeeds.Text = "";

                        MessageBox.Show("Information updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connect.Close();
                }
                displayCurrentSettings();
            }   
        }

        // click on update the goal button
        private void settings_updateGoalBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(settings_deficitGoal.Text, out int value) == false)
            {
                MessageBox.Show("The Calorie value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                updatedGoal = int.Parse(settings_deficitGoal.Text);

                // update value in the user class
                _currentUser.Calorie_goal = updatedGoal;

                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    connect.Open();

                    string updateData = "UPDATE users SET calorie_goal = @goal WHERE id = @id ";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentUser.ID);
                        cmd.Parameters.AddWithValue("@goal", updatedGoal);

                        cmd.ExecuteNonQuery();

                        settings_deficitGoal.Text = "";

                        MessageBox.Show("Information updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connect.Close();
                }
                displayCurrentSettings();
            }       
        }
    }
}
