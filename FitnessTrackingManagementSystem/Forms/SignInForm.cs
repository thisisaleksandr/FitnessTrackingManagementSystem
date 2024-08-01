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
    using Classes;
    public partial class SignInForm : Form
    {
        // make connection to the database
        SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString);
        public SignInForm()
        {
            InitializeComponent();
        }

        // click on sign up button
        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();

            this.Hide();
        }
        public bool checkConnection()
        {
            return (connect.State == ConnectionState.Closed) ? true : false;
        }

        // click on the exit button
        private void SignInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No){
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        // click on "Show password" will show or hide the password
        private void login_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPassword.Checked ? '\0' : '*';
        }

        // click on login button
        private void login_btn_Click(object sender, EventArgs e)
        {
            // to check if there is connection to database
            if (checkConnection())
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                    {
                        // open session to SQL server
                        connect.Open();

                        // SQL query to retrieve data
                        string selectData = "SELECT * FROM users WHERE username = @usern AND password = @pass";

                        // create a new command to execute
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            // add user entries to the query
                            cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@pass", login_password.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                User currentUser = null;

                                SqlDataReader reader = cmd.ExecuteReader();
                                if (reader.Read())
                                {
                                    int currentUserId = reader.GetInt32(reader.GetOrdinal("id"));
                                    string currentUsername = reader.GetString(reader.GetOrdinal("username"));
                                    int bmrCalories = reader.GetInt32(reader.GetOrdinal("bmr_calories"));
                                    int calorieGoal = reader.GetInt32(reader.GetOrdinal("calorie_goal"));

                                    // create a user class for the current session based on the retrieved data
                                    currentUser = new User(currentUserId, currentUsername, bmrCalories, calorieGoal);
                                }
                                reader.Close();

                                // create a new main form and pass there user class
                                MainForm mainForm = new MainForm(currentUser);
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect username/password!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection to Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
    }
}