using System;
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
        public CalorieCalculator()
        {
            InitializeComponent();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
        }

        private void calculator_calculateBtn_Click(object sender, EventArgs e)
        {
            if (calculator_sex.SelectedIndex == -1 || calculator_heightFeet.Text == "" ||
                calculator_age.Text == "" || calculator_activityLvl.SelectedIndex == -1 ||
                calculator_weight.Text == "" || calculator_weightGoal.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // calculate bmr
                double height = int.Parse(calculator_heightFeet.Text) * 12 + int.Parse(calculator_heightInches.Text);
                bool sex = calculator_sex.SelectedIndex == 0 ? true : false;
                
                var user1 = new User(1, "xyu");

                int BMR = user1.CalculateBMR(int.Parse(calculator_age.Text),
                    float.Parse(calculator_weight.Text), height, sex);

                calculator_bmr.Text = BMR.ToString() + " kcal/day";

                switch (calculator_weightGoal.SelectedIndex)
                {
                    case 0:
                        calculator_recomGoal.Text = "0 kcal/day";
                        break;
                    case 1:
                        calculator_recomGoal.Text = "500 kcal/day";
                        break;
                    case 2:
                        // add if statement to check if it is more than critical value
                        calculator_recomGoal.Text = "800 kcal/day";
                        break;
                }

            }
        }
        public void clearFields()
        {
            calculator_sex.SelectedIndex = -1;
            calculator_heightFeet.Text = "";
            calculator_age.Text = "";
            calculator_activityLvl.SelectedIndex = -1;
            calculator_weight.Text = "";
            calculator_weightGoal.SelectedIndex = -1;
        }

        private void calculator_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
