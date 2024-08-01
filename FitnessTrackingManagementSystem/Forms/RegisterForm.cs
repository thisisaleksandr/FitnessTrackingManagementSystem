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
using System.Runtime.Remoting.Messaging;

namespace FitnessTrackingManagementSystem
{
    public partial class RegisterForm : Form
    {
        // make connection to the database
        SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString);
        public RegisterForm()
        {
            InitializeComponent();
        }

        // check connection
        public bool checkConnection()
        {
            return (connect.State == ConnectionState.Closed) ? true : false;
        }

        // click on sign in button
        private void register_signInBtn_Click(object sender, EventArgs e)
        {
            SignInForm loginForm = new SignInForm();
            loginForm.Show();

            this.Hide();
        }

        // ckick on exit button
        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation Message",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        // click on "Show password" will show or hide the password
        private void register_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPassword.Checked ? '\0' : '*';
            register_confirmPass.PasswordChar = register_showPassword.Checked ? '\0' : '*';
        }

        // click on "register" button
        private void register_btn_Click(object sender, EventArgs e)
        {
            if (register_username.Text == "" || register_password.Text == "" ||
                register_confirmPass.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            { 
                if(checkConnection()) 
                {
                        try
                        {
                            connect.Open();

                            string selectUsername = "SELECT * FROM users WHERE username = @usern";
                            
                            using (SqlCommand checkUser = new SqlCommand(selectUsername, connect))
                            {
                                checkUser.Parameters.AddWithValue("@usern", register_username.Text.Trim());

                                SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                                DataTable table = new DataTable();
                                adapter.Fill(table);
                                
                                // check if the username value is already exists in the database
                                if (table.Rows.Count != 0)
                                {
                                    string tempUsern = register_username.Text;
                                    MessageBox.Show(tempUsern + " is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                // check if the length of the password is more then 5
                                else if (register_password.Text.Length < 6)
                                {
                                    MessageBox.Show("Invalid password, at least 6 characters are needed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                // check if the passwords are maatched
                                else if (register_password.Text != register_confirmPass.Text)
                                {
                                    MessageBox.Show("Passwords don't match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    // query to insert user register information to the database
                                    string insertData = "INSERT INTO users (username, password, date_create) VALUES(@usern, @pass, @date)";

                                    using (SqlCommand insertUser = new SqlCommand(insertData, connect))
                                    {
                                        insertUser.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                                        insertUser.Parameters.AddWithValue("@pass", register_password.Text.Trim());
                                        DateTime today = DateTime.Today;
                                        insertUser.Parameters.AddWithValue("@date", today);

                                        insertUser.ExecuteNonQuery();

                                        MessageBox.Show("Registered successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        SignInForm loginForm = new SignInForm();
                                        loginForm.Show();

                                        this.Hide();
                                    }
                                }
                            }
                        }catch (Exception ex)
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
}