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
        private int getID = 0;
        public CurrentWeightForm()
        {
            InitializeComponent();

            displayWeightDataList();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayWeightDataList();
        }

        public void displayWeightDataList()
        {
            WeightData wData = new WeightData();
            List<WeightData> listData = wData.weightDataList();

            dataGridView1.DataSource = listData;

        }

        private void currWeight_addBtn_Click(object sender, EventArgs e)
        {
            if (currWeight_weight.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    // open connection to sql
                    connect.Open();

                    string insertData = "INSERT INTO weight_log (weight_value, date_insert) " +
                        "VALUES(@weight, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@weight", double.Parse(currWeight_weight.Text.Trim()));
                        cmd.Parameters.AddWithValue("@date", currWeight_date.Text);

                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Added successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connect.Close();

                }
            }
            displayWeightDataList();
        }

        private void clearFields()
        {
            currWeight_weight.Text = "";
        }

        private void currWeight_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void currWeight_updateBtn_Click(object sender, EventArgs e)
        {
            if (currWeight_weight.Text == "")
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
