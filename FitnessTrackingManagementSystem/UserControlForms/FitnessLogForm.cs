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
using System.Diagnostics.Eventing.Reader;

namespace FitnessTrackingManagementSystem
{
    public partial class FitnessLogForm : UserControl
    {
        // getID to store the ID of the fitness entry
        // after clicking on one of the cell in the table
        private int getID = 0;
        private User _currentUser;

        public FitnessLogForm()
        {
            InitializeComponent(); 
        }

        // to work with the current user in this class
        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            InitializeFitnessLog();
        }

        private void InitializeFitnessLog()
        {
            displayFitnessDataList();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayFitnessDataList();
        }

        // function that will populate the table with values from the database
        public void displayFitnessDataList()
        {
            FitnessData fData = new FitnessData(_currentUser);
            List<FitnessData> listData = fData.GetLastEntries();

            dataGridView1.DataSource = listData;
        }

        // click on Add button
        private void fitnessLog_addBtn_Click(object sender, EventArgs e)
        {
            /* validations */
            if(fitnessLog_activity.SelectedIndex == -1 || fitnessLog_calorie.Text == "" ||
                fitnessLog_duration.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(int.TryParse(fitnessLog_calorie.Text, out int value) == false)
            {
                MessageBox.Show("The calorie value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(fitnessLog_duration.Text, out int value2) == false)
            {
                MessageBox.Show("The duration value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(fitnessLog_date.Value > DateTime.Now){
                MessageBox.Show("The date value should be in the past", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // add new values to the database
            else
            {
                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    connect.Open();

                    string insertData = "INSERT INTO fitness_log (user_id, activity, duration, calories, date_insert) " +
                        "VALUES(@user_id, @act, @dur, @cal, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                        cmd.Parameters.AddWithValue("@act", fitnessLog_activity.SelectedItem);
                        cmd.Parameters.AddWithValue("@dur", Int32.Parse(fitnessLog_duration.Text.Trim()));
                        cmd.Parameters.AddWithValue("@cal", Int32.Parse(fitnessLog_calorie.Text.Trim()));
                        cmd.Parameters.AddWithValue("@date", fitnessLog_date.Value);
                    
                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Added successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connect.Close();
                }
            }
            displayFitnessDataList(); // update table
        }

        // get ID and fill textboxes when click on one of the cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);

                fitnessLog_activity.SelectedItem = row.Cells[1].Value.ToString();
                fitnessLog_duration.Text = row.Cells[2].Value.ToString();
                fitnessLog_calorie.Text = row.Cells[3].Value.ToString();
                fitnessLog_date.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
            }
        }

        // click on update button
        private void fitnessLog_updateBtn_Click(object sender, EventArgs e)
        {
            /* validations */
            if (fitnessLog_activity.SelectedIndex == -1 || fitnessLog_calorie.Text == "" ||
                fitnessLog_duration.Text == "")
            {
                MessageBox.Show("Please select item from the table", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(fitnessLog_calorie.Text, out int value) == false)
            {
                MessageBox.Show("The calorie value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(fitnessLog_duration.Text, out int value2) == false)
            {
                MessageBox.Show("The duration value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (fitnessLog_date.Value > DateTime.Now)
            {
                MessageBox.Show("The date value should be in the past", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // updates the database depending on ID
            else
            {
                if (MessageBox.Show("Are you sure you want to update ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                    {

                        connect.Open();

                        string updateData = "UPDATE fitness_log SET activity = @act, duration = @dur, " +
                            "calories = @cal, date_insert = @date WHERE id = @id ";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.Parameters.AddWithValue("@act", fitnessLog_activity.SelectedItem);
                            cmd.Parameters.AddWithValue("@dur", Int32.Parse(fitnessLog_duration.Text.Trim()));
                            cmd.Parameters.AddWithValue("@cal", Int32.Parse(fitnessLog_calorie.Text.Trim()));
                            cmd.Parameters.AddWithValue("@date", fitnessLog_date.Text);

                            cmd.ExecuteNonQuery();
                            clearFields();

                            MessageBox.Show("Updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connect.Close();
                    }
                }        
            }
            displayFitnessDataList();
        }

        // function that clears the textbox
        public void clearFields()
        {
            fitnessLog_activity.SelectedIndex = -1;
            fitnessLog_duration.Text = "";
            fitnessLog_calorie.Text = "";
        }

        // click on Clear button
        private void fitnessLog_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        // click on Delete button
        private void fitnessLog_deleteBtn_Click(object sender, EventArgs e)
        {
            if (fitnessLog_activity.SelectedIndex == -1 || fitnessLog_calorie.Text == "" ||
                fitnessLog_duration.Text == "")
            {
                MessageBox.Show("Please select item from the table", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                    {
                        // open connection to sql
                        connect.Open();

                        string updateData = "DELETE FROM fitness_log WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);

                            cmd.ExecuteNonQuery();
                            clearFields();

                            MessageBox.Show("Deleted successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connect.Close();
                    }
                }
            }
            displayFitnessDataList();
        }        
    }
}
