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

namespace FitnessTrackingManagementSystem
{
    public partial class FitnessLogForm : UserControl
    {
        private int getID = 0; // get fitness log ID to update the table
        private User _currentUser;

        public FitnessLogForm()
        {
            InitializeComponent();
            
        }
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

        public void displayFitnessDataList()
        {
            FitnessData fData = new FitnessData(_currentUser);
            List<FitnessData> listData = fData.fitnessDataList();

            dataGridView1.DataSource = listData;
        }

        private void fitnessLog_addBtn_Click(object sender, EventArgs e)
        {
            // CHECK
            if(fitnessLog_activity.SelectedIndex == -1 || fitnessLog_calorie.Text == "" ||
                fitnessLog_duration.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    // open connection to sql
                    connect.Open();

                    string insertData = "INSERT INTO fitness_log (user_id, activity, duration, calories, date_insert) " +
                        "VALUES(@user_id, @act, @dur, @cal, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                        cmd.Parameters.AddWithValue("@act", fitnessLog_activity.SelectedItem);
                        cmd.Parameters.AddWithValue("@dur", Int32.Parse(fitnessLog_duration.Text.Trim()));
                        cmd.Parameters.AddWithValue("@cal", Int32.Parse(fitnessLog_calorie.Text.Trim()));
                        cmd.Parameters.AddWithValue("@date", fitnessLog_date.Value); //was .Text
                    
                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Added successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connect.Close();

                }
            }
            displayFitnessDataList(); // update table
        }

        // filling textboxes when we click on rows
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
                // fitnessLog_date.Text = row.Cells[4].Value.ToString();

            }
        }

        private void fitnessLog_updateBtn_Click(object sender, EventArgs e)
        {
            if (fitnessLog_activity.SelectedIndex == -1 || fitnessLog_calorie.Text == "" ||
                fitnessLog_duration.Text == "")
            {
                MessageBox.Show("Please select item from the table", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                    {
                        // open connection to sql
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

        public void clearFields()
        {
            fitnessLog_activity.SelectedIndex = -1;
            fitnessLog_duration.Text = "";
            fitnessLog_calorie.Text = "";
        }

        private void fitnessLog_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

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
