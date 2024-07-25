using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTrackingManagementSystem
{
    using Classes;
    public partial class MainForm : Form
    {
        private User _currentUser;
        public MainForm(User currentUser)
        {
            InitializeComponent();

            _currentUser = currentUser;

            // pass the user class to all control forms
            dashboard1.SetCurrentUser(currentUser);
            fitnessLog1.SetCurrentUser(currentUser);
            foodLogForm1.SetCurrentUser(currentUser);
            currentWeightForm1.SetCurrentUser(currentUser);
            calorieCalculator1.SetCurrentUser(currentUser);
            settingsForm1.SetCurrentUser(currentUser);

            WelcomeUserChange();
        }
        
        // show "welcome" and then user's name in main menu
        private void WelcomeUserChange()
        {
            main_welcome.Text = String.Format("Welcome,\n{0}!", _currentUser.Username);
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void main_logoutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SignInForm form1 = new SignInForm();
                form1.Show();
                this.Hide();
            }
        }

        private void hideAllForms()
        {
            dashboard1.Visible = false;
            fitnessLog1.Visible = false;
            foodLogForm1.Visible = false;
            settingsForm1.Visible = false;
            calorieCalculator1.Visible = false;
            currentWeightForm1.Visible = false;
        }

        private void main_dashboardBtn_Click(object sender, EventArgs e)
        {
            hideAllForms();
            dashboard1.Visible = true;

            Dashboard dForm = dashboard1 as Dashboard;

            if(dForm != null)
            {
                dForm.refreshData();
            }
        }

        private void main_fitnessLogBtn_Click(object sender, EventArgs e)
        {
            hideAllForms();
            fitnessLog1.Visible = true;

            FitnessLogForm fitForm = fitnessLog1 as FitnessLogForm;

            if (fitForm != null)
            {
                fitForm.refreshData();
            }
        }

        private void main_foodLogBtn_Click(object sender, EventArgs e)
        {
            hideAllForms();
            foodLogForm1.Visible = true;

            FoodLogForm foodForm = foodLogForm1 as FoodLogForm;

            if (foodForm != null)
            {
                foodForm.refreshData();
            }
        }

        private void main_weightBtn_Click(object sender, EventArgs e)
        {
            hideAllForms();
            currentWeightForm1.Visible = true;

            CurrentWeightForm wForm = currentWeightForm1 as CurrentWeightForm;

            if (wForm != null)
            {
                wForm.refreshData();
            }
        }

        private void main_calCalcBtn_Click(object sender, EventArgs e)
        {
            hideAllForms();
            calorieCalculator1.Visible = true;

            CalorieCalculator calcForm = calorieCalculator1 as CalorieCalculator;

            if (calcForm != null)
            {
                calcForm.refreshData();
            }
        }

        private void main_settingsBtn_Click(object sender, EventArgs e)
        {
            hideAllForms();
            settingsForm1.Visible = true;

            SettingsForm setForm = settingsForm1 as SettingsForm;

            if (setForm != null)
            {
                setForm.refreshData();
            }
        }
    }
}