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
    public partial class CurrentWeightForm : UserControl
    {
        // getID to store the ID of the weight entry after clicking on one of the cell
        private int getID = 0;
        private User _currentUser;

        public CurrentWeightForm()
        {
            InitializeComponent();
        }

        // to work with the current user in this class
        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            InitializeWeightLog();
        }

        private void InitializeWeightLog()
        {
            displayWeightDataList();
        }

        // refreshes data in the table
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayWeightDataList();
        }

        // function that will populate the table with values from the database
        public void displayWeightDataList()
        {
            // create instance of the WeightData to store the values from the database
            WeightData wData = new WeightData(_currentUser);

            // get last 12 entries
            List<WeightData> listData = wData.GetLastEntries();

            // show data in the table 
            dataGridView1.DataSource = listData;

        }

        // click on add button
        private void currWeight_addBtn_Click(object sender, EventArgs e)
        {
            /* validations */
            if (currWeight_weight.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(currWeight_weight.Text, out int value) == false)
            {
                MessageBox.Show("The weight value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (currWeight_date.Value > DateTime.Now)
            {
                MessageBox.Show("The date value should be in the past", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // add new value to the database
            else
            {
                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    // open connection to sql
                    connect.Open();

                    string insertData = "INSERT INTO weight_log (user_id, weight_value, date_insert) " +
                        "VALUES(@user_id, @weight, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                        cmd.Parameters.AddWithValue("@weight", Convert.ToDouble(currWeight_weight.Text));
                        cmd.Parameters.AddWithValue("@date", DateTime.Parse(currWeight_date.Text));

                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Added successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connect.Close();
                }
            }
            displayWeightDataList();
        }

        // function that clears the textbox
        private void clearFields()
        {
            currWeight_weight.Text = "";
        }

        // click on Clear button
        private void currWeight_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        // click on update button
        private void currWeight_updateBtn_Click(object sender, EventArgs e)
        {
            // form validations
            if (currWeight_weight.Text == "")
            {
                MessageBox.Show("Please select item from the table", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(currWeight_weight.Text, out int value) == false)
            {
                MessageBox.Show("The weight value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (currWeight_date.Value > DateTime.Now)
            {
                MessageBox.Show("The date value should be in the past", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // update the database depending on ID
            else
            {
                if (MessageBox.Show("Are you sure you want to update ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                    {
                        // open connection to sql
                        connect.Open();

                        string updateData = "UPDATE weight_log SET weight_value = @weight, " +
                            "date_insert = @date WHERE id = @id ";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);

                            cmd.Parameters.AddWithValue("@weight", double.Parse(currWeight_weight.Text.Trim()));
                            cmd.Parameters.AddWithValue("@date", currWeight_date.Value); //was .Text

                            cmd.ExecuteNonQuery();
                            clearFields();

                            MessageBox.Show("Updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connect.Close();
                    }
                }
            }
            displayWeightDataList();
        }

        // click on the cell in the table to get the ID and add values to the textboxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);

                currWeight_weight.Text = row.Cells[1].Value.ToString();
                currWeight_date.Text = row.Cells[2].Value.ToString();
            }
        }

        // click on delete button
        private void currWeight_deleteBtn_Click(object sender, EventArgs e)
        {
            if (currWeight_weight.Text == "")
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

                        string updateData = "DELETE FROM weight_log WHERE id = @id";

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
            displayWeightDataList();
        }
    }
}
