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
    public partial class FoodLogForm : UserControl
    {
        // getID to store the ID of the food entry
        // after clicking on one of the cell in the table
        private int getID = 0;
        private User _currentUser;
        public FoodLogForm()
        {
            InitializeComponent();            
        }

        // to work with the current user in this class
        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            InitializeFoodLog();
        }

        private void InitializeFoodLog()
        {
            displayFoodDataList();
        }

        // refreshes data
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayFoodDataList();
        }

        // function that will populate the table with values from the database
        public void displayFoodDataList()
        {
            FoodData fData = new FoodData(_currentUser);
            List<FoodData> listData = fData.GetLastEntries();

            dataGridView1.DataSource = listData;

        }

        // click on Add button
        private void foodLog_addBtn_Click(object sender, EventArgs e)
        {
            // validations
            if (foodLog_foodType.Text == "" || foodLog_calorie.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(foodLog_calorie.Text, out int value2) == false)
            {
                MessageBox.Show("The calorie value should be in the format of an integer", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (foodLog_date.Value > DateTime.Now)
            {
                MessageBox.Show("The date value should be in the past", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // add food entry to the database
            else
            {
                using (SqlConnection connect = new SqlConnection(sqlConnectionString.connectionString))
                {
                    connect.Open();

                    string insertData = "INSERT INTO food_log (user_id, meal_name, calories, date_insert) " +
                        "VALUES(@user_id, @meal, @cal, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@user_id", _currentUser.ID);
                        cmd.Parameters.AddWithValue("@meal", foodLog_foodType.Text);
                        cmd.Parameters.AddWithValue("@cal", Int32.Parse(foodLog_calorie.Text.Trim()));
                        cmd.Parameters.AddWithValue("@date", foodLog_date.Value);

                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Added successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connect.Close();
                }
            }
            displayFoodDataList();
        }

        // function that clears the textbox
        private void clearFields()
        {
            foodLog_foodType.Text = "";
            foodLog_calorie.Text = "";
        }

        // click on clear button
        private void foodLog_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        // click on update button
        private void foodLog_updateBtn_Click(object sender, EventArgs e)
        {
            if (foodLog_foodType.Text == "" || foodLog_calorie.Text == "")
            {
                MessageBox.Show("Please select item from the table", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (foodLog_date.Value > DateTime.Now)
            {
                MessageBox.Show("The date value should be in the past", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // update database
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

        // get id and fill textboxes when we click on one of the cells
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);

                foodLog_foodType.Text = row.Cells[1].Value.ToString();
                foodLog_calorie.Text = row.Cells[2].Value.ToString();

                foodLog_date.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
            }
        }

        // click on delete button
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
