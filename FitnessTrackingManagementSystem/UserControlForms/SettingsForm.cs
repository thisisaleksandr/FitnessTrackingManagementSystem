﻿using FitnessTrackingManagementSystem.Classes;
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

        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            InitializeSettingsLog();
        }

        private void InitializeSettingsLog()
        {
            displayCurrentSettings();
        }

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
        }

        private void settings_updateCaloricNeedsBtn_Click(object sender, EventArgs e)
        {
            updatedNeeds = int.Parse(settings_dailyCaloricNeeds.Text);
            _currentUser.Bmr_calories = updatedNeeds;

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                // open connection to sql
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

        private void settings_updateGoalBtn_Click(object sender, EventArgs e)
        {
            updatedGoal = int.Parse(settings_deficitGoal.Text);
            _currentUser.Calorie_goal = updatedGoal;

            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                // open connection to sql
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
