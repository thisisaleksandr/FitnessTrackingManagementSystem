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
        public SignInForm()
        {
            InitializeComponent();
        }
        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();

            this.Hide();
        }

        private void SignInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No){
                e.Cancel = true;
                //Application.Exit();
            }
        }

        private void login_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPassword.Checked ? '\0' : '*';
        }

        // login button handler
        private void login_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
            {
                // open session to SQL server
                connect.Open();

                // SQL command in the string. To retrieve data if user's username and password matched
                string selectData = "SELECT * FROM users WHERE username = @usern AND password = @pass";

                // create a new command to execute: selectData - command, connect - reference to a SQlConnection object
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    // add value to the end of the SqlParameterCollection
                    cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", login_password.Text.Trim());

                    // bridge between datatable and the database
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable(); 

                    // execute the command, fetch the results and fill the table with retrieved data
                    adapter.Fill(table);

                    // check if such username and password exist in database
                    if(table.Rows.Count > 0)
                    {
                        MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        User currentUser = null;

                        // create user class for the current session
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int currentUserId = reader.GetInt32(reader.GetOrdinal("id"));
                            string currentUsername = reader.GetString(reader.GetOrdinal("username"));
                            currentUser = new User(currentUserId, currentUsername);
                        }
                        reader.Close();

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
    }
}
