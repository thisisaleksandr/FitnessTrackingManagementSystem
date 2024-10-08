﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FitnessTrackingManagementSystem
{
    using Classes;
    public partial class CalorieCalculator : UserControl
    {
        private User _currentUser;
        // BMR is daily calorie needs
        private int BMR;
        private int _calGoal;
        public CalorieCalculator()
        {
            InitializeComponent();
        }

        // to work with the current user in this class
        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
        }

        // refreshes data
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
        }

        // click on Calculate button
        private void calculator_calculateBtn_Click(object sender, EventArgs e)
        {
            /* different validations */

            if (calculator_sex.SelectedIndex == -1 || calculator_heightFeet.Text == "" ||
                calculator_age.Text == "" || calculator_activityLvl.SelectedIndex == -1 ||
                calculator_weight.Text == "" || calculator_weightGoal.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(calculator_heightFeet.Text, out int hvalue) == false)
            {
                MessageBox.Show("The height feet value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(calculator_heightInches.Text, out hvalue) == false)
            {
                MessageBox.Show("The height inch value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(calculator_age.Text, out int agevalue) == false)
            {
                MessageBox.Show("The age value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(calculator_weight.Text, out int wvalue) == false)
            {
                MessageBox.Show("The weight value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // get user inputs //

                // sum feet and inches
                double height = int.Parse(calculator_heightFeet.Text) * 12 + int.Parse(calculator_heightInches.Text);
           
                bool sex = calculator_sex.SelectedIndex == 0 ? true : false;

                // calculate daily calorie needs using method "CalculateBMR()"
                BMR = _currentUser.CalculateBMR(int.Parse(calculator_age.Text),
                    float.Parse(calculator_weight.Text), height, sex);

                // show calculated bmr to user
                calculator_bmr.Text = BMR.ToString() + " kcal/day";

                // show the calorie goal depending on the desired goal
                switch (calculator_weightGoal.SelectedIndex)
                {
                    case 0:
                        calculator_recomGoal.Text = "0 kcal/day";
                        _calGoal = 0;
                        break;
                    case 1:
                        // validations to check if the goal is not less then the minimum calorie needs value
                        if (calculator_sex.SelectedIndex == 1 && BMR - 500 < 1200 && BMR > 1200)
                        {
                            calculator_recomGoal.Text = String.Format("{0} kcal/day", BMR - 1200);
                            _calGoal = BMR - 1200;
                        }
                        else if (calculator_sex.SelectedIndex == 0 && BMR - 500 < 1500 && BMR > 1500)
                        {
                            calculator_recomGoal.Text = String.Format("{0} kcal/day", BMR - 1500);
                            _calGoal = BMR - 1500;
                        }
                        else
                        {
                            calculator_recomGoal.Text = "500 kcal/day";
                            _calGoal = 500;
                        }
                        break;
                    case 2:
                        // validations to check if the goal is not less then the minimum calorie needs value
                        if (calculator_sex.SelectedIndex == 1 && BMR - 800 < 1200 && BMR > 1200)
                        {
                            calculator_recomGoal.Text = String.Format("{0} kcal/day", BMR - 1200);
                            _calGoal = BMR - 1200;
                        }
                        else if (calculator_sex.SelectedIndex == 0 && BMR - 800 < 1500 && BMR > 1500)
                        {
                            calculator_recomGoal.Text = String.Format("{0} kcal/day", BMR - 1500);
                            _calGoal = BMR - 1500;
                        }
                        else
                        {
                            calculator_recomGoal.Text = "800 kcal/day";
                            _calGoal = 800;
                        }
                        break;
                }
            }
        }

        // function that clears all textboxes
        public void clearFields()
        {
            calculator_sex.SelectedIndex = -1;
            calculator_heightFeet.Text = "";
            calculator_age.Text = "";
            calculator_activityLvl.SelectedIndex = -1;
            calculator_weight.Text = "";
            calculator_weightGoal.SelectedIndex = -1;
        }

        // click on Clear button
        private void calculator_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        // click on Set As New button
        private void calculator_setAsNewBtn_Click(object sender, EventArgs e)
        {
            // set new values in the user classes
            _currentUser.Bmr_calories = BMR;
            _currentUser.Calorie_goal = _calGoal;

            // update them in the database
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                // open connection to sql
                connect.Open();

                string updateData = "UPDATE users SET bmr_calories = @bmr, calorie_goal = @cal_goal WHERE id = @id ";

                using (SqlCommand cmd = new SqlCommand(updateData, connect))
                {
                    cmd.Parameters.AddWithValue("@id", _currentUser.ID);
                    cmd.Parameters.AddWithValue("@bmr", BMR);
                    cmd.Parameters.AddWithValue("@cal_goal", _calGoal);

                    cmd.ExecuteNonQuery();
                    clearFields();

                    MessageBox.Show("Information updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connect.Close();
            }
        }
    }
}
