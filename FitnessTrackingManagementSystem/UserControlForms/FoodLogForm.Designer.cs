namespace FitnessTrackingManagementSystem
{
    partial class FoodLogForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.foodLog_deleteBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.foodLog_updateBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.foodLog_foodType = new System.Windows.Forms.TextBox();
            this.foodLog_date = new System.Windows.Forms.DateTimePicker();
            this.foodLog_clearBtn = new System.Windows.Forms.Button();
            this.foodLog_addBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.foodLog_calorie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.foodLog_deleteBtn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.foodLog_updateBtn);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(339, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 707);
            this.panel2.TabIndex = 3;
            // 
            // foodLog_deleteBtn
            // 
            this.foodLog_deleteBtn.BackColor = System.Drawing.Color.Indigo;
            this.foodLog_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodLog_deleteBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodLog_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.foodLog_deleteBtn.Location = new System.Drawing.Point(300, 632);
            this.foodLog_deleteBtn.Name = "foodLog_deleteBtn";
            this.foodLog_deleteBtn.Size = new System.Drawing.Size(251, 61);
            this.foodLog_deleteBtn.TabIndex = 12;
            this.foodLog_deleteBtn.Text = "Delete";
            this.foodLog_deleteBtn.UseVisualStyleBackColor = false;
            this.foodLog_deleteBtn.Click += new System.EventHandler(this.foodLog_deleteBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Last food entries:";
            // 
            // foodLog_updateBtn
            // 
            this.foodLog_updateBtn.BackColor = System.Drawing.Color.Indigo;
            this.foodLog_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodLog_updateBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodLog_updateBtn.ForeColor = System.Drawing.Color.White;
            this.foodLog_updateBtn.Location = new System.Drawing.Point(18, 632);
            this.foodLog_updateBtn.Name = "foodLog_updateBtn";
            this.foodLog_updateBtn.Size = new System.Drawing.Size(251, 62);
            this.foodLog_updateBtn.TabIndex = 11;
            this.foodLog_updateBtn.Text = "Update";
            this.foodLog_updateBtn.UseVisualStyleBackColor = false;
            this.foodLog_updateBtn.Click += new System.EventHandler(this.foodLog_updateBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(18, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(533, 557);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.foodLog_foodType);
            this.panel1.Controls.Add(this.foodLog_date);
            this.panel1.Controls.Add(this.foodLog_clearBtn);
            this.panel1.Controls.Add(this.foodLog_addBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.foodLog_calorie);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 707);
            this.panel1.TabIndex = 2;
            // 
            // foodLog_foodType
            // 
            this.foodLog_foodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodLog_foodType.Location = new System.Drawing.Point(23, 48);
            this.foodLog_foodType.Name = "foodLog_foodType";
            this.foodLog_foodType.Size = new System.Drawing.Size(251, 35);
            this.foodLog_foodType.TabIndex = 12;
            // 
            // foodLog_date
            // 
            this.foodLog_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodLog_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.foodLog_date.Location = new System.Drawing.Point(23, 279);
            this.foodLog_date.Name = "foodLog_date";
            this.foodLog_date.Size = new System.Drawing.Size(251, 35);
            this.foodLog_date.TabIndex = 11;
            // 
            // foodLog_clearBtn
            // 
            this.foodLog_clearBtn.BackColor = System.Drawing.Color.Indigo;
            this.foodLog_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodLog_clearBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodLog_clearBtn.ForeColor = System.Drawing.Color.White;
            this.foodLog_clearBtn.Location = new System.Drawing.Point(23, 631);
            this.foodLog_clearBtn.Name = "foodLog_clearBtn";
            this.foodLog_clearBtn.Size = new System.Drawing.Size(251, 62);
            this.foodLog_clearBtn.TabIndex = 10;
            this.foodLog_clearBtn.Text = "Clear";
            this.foodLog_clearBtn.UseVisualStyleBackColor = false;
            this.foodLog_clearBtn.Click += new System.EventHandler(this.foodLog_clearBtn_Click);
            // 
            // foodLog_addBtn
            // 
            this.foodLog_addBtn.BackColor = System.Drawing.Color.Indigo;
            this.foodLog_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodLog_addBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodLog_addBtn.ForeColor = System.Drawing.Color.White;
            this.foodLog_addBtn.Location = new System.Drawing.Point(23, 548);
            this.foodLog_addBtn.Name = "foodLog_addBtn";
            this.foodLog_addBtn.Size = new System.Drawing.Size(251, 61);
            this.foodLog_addBtn.TabIndex = 9;
            this.foodLog_addBtn.Text = "Add";
            this.foodLog_addBtn.UseVisualStyleBackColor = false;
            this.foodLog_addBtn.Click += new System.EventHandler(this.foodLog_addBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date:";
            // 
            // foodLog_calorie
            // 
            this.foodLog_calorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodLog_calorie.Location = new System.Drawing.Point(23, 164);
            this.foodLog_calorie.Name = "foodLog_calorie";
            this.foodLog_calorie.Size = new System.Drawing.Size(251, 35);
            this.foodLog_calorie.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Calories consumed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Food type:";
            // 
            // FoodLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FoodLogForm";
            this.Size = new System.Drawing.Size(928, 744);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button foodLog_deleteBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button foodLog_updateBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker foodLog_date;
        private System.Windows.Forms.Button foodLog_clearBtn;
        private System.Windows.Forms.Button foodLog_addBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox foodLog_calorie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox foodLog_foodType;
    }
}
