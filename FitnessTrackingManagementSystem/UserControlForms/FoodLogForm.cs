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
    public partial class FoodLogForm : UserControl
    {
        private int getID = 0; // get IT to update the table
        public FoodLogForm()
        {
            InitializeComponent();

            displayFoodDataList();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayFoodDataList();
        }

        public void displayFoodDataList()
        {
            FoodData fData = new FoodData();
            List<FoodData> listData = fData.foodDataList();

            dataGridView1.DataSource = listData;

        }

        private void foodLog_addBtn_Click(object sender, EventArgs e)
        {
            if (foodLog_foodType.Text == "" || foodLog_calorie.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    // open connection to sql
                    connect.Open();

                    string insertData = "INSERT INTO food_log (meal_name, calories, date_insert) " +
                        "VALUES(@meal, @cal, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@meal", foodLog_foodType.Text);
                        cmd.Parameters.AddWithValue("@cal", Int32.Parse(foodLog_calorie.Text.Trim()));
                        cmd.Parameters.AddWithValue("@date", foodLog_date.Value); //was .Text

                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Added successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connect.Close();

                }
            }
            displayFoodDataList();
        }

        private void clearFields()
        {
            foodLog_foodType.Text = "";
            foodLog_calorie.Text = "";
        }

        private void foodLog_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void foodLog_updateBtn_Click(object sender, EventArgs e)
        {
            if (foodLog_foodType.Text == "" || foodLog_calorie.Text == "")
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

                        string updateData = "UPDATE food_log SET meal_name = @meal, " +
                            "calories = @cal, date_insert = @date WHERE id = @id ";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);

                            cmd.Parameters.AddWithValue("@meal", foodLog_foodType.Text);
                            cmd.Parameters.AddWithValue("@cal", Int32.Parse(foodLog_calorie.Text.Trim()));
                            cmd.Parameters.AddWithValue("@date", foodLog_date.Text);

                            cmd.ExecuteNonQuery();
                            clearFields();

                            MessageBox.Show("Updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connect.Close();

                    }
                }
            }
            displayFoodDataList();
        }

        // filling textboxes when we click on rows
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);

                foodLog_foodType.Text = row.Cells[1].Value.ToString();
                foodLog_calorie.Text = row.Cells[2].Value.ToString();

                foodLog_date.Value = Convert.ToDateTime(row.Cells[3].Value.ToString()); //mb w/o ToString()
                //foodLog_date.Text = row.Cells[3].Value.ToString();
            }
        }

        private void foodLog_deleteBtn_Click(object sender, EventArgs e)
        {
            if (foodLog_foodType.Text == "" || foodLog_calorie.Text == "")
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

                        string updateData = "DELETE FROM food_log WHERE id = @id";

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
            displayFoodDataList();
        }
    }
}
