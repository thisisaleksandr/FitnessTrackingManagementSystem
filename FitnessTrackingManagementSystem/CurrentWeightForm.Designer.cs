namespace FitnessTrackingManagementSystem
{
    partial class CurrentWeightForm
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
            this.currWeight_deleteBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.currWeight_updateBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.currWeight_weight = new System.Windows.Forms.TextBox();
            this.currWeight_date = new System.Windows.Forms.DateTimePicker();
            this.currWeight_clearBtn = new System.Windows.Forms.Button();
            this.currWeight_addBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.currWeight_deleteBtn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.currWeight_updateBtn);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(339, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 707);
            this.panel2.TabIndex = 5;
            // 
            // currWeight_deleteBtn
            // 
            this.currWeight_deleteBtn.BackColor = System.Drawing.Color.Indigo;
            this.currWeight_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currWeight_deleteBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currWeight_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.currWeight_deleteBtn.Location = new System.Drawing.Point(300, 632);
            this.currWeight_deleteBtn.Name = "currWeight_deleteBtn";
            this.currWeight_deleteBtn.Size = new System.Drawing.Size(251, 61);
            this.currWeight_deleteBtn.TabIndex = 12;
            this.currWeight_deleteBtn.Text = "Delete";
            this.currWeight_deleteBtn.UseVisualStyleBackColor = false;
            this.currWeight_deleteBtn.Click += new System.EventHandler(this.currWeight_deleteBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Last weight entries:";
            // 
            // currWeight_updateBtn
            // 
            this.currWeight_updateBtn.BackColor = System.Drawing.Color.Indigo;
            this.currWeight_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currWeight_updateBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currWeight_updateBtn.ForeColor = System.Drawing.Color.White;
            this.currWeight_updateBtn.Location = new System.Drawing.Point(18, 632);
            this.currWeight_updateBtn.Name = "currWeight_updateBtn";
            this.currWeight_updateBtn.Size = new System.Drawing.Size(251, 62);
            this.currWeight_updateBtn.TabIndex = 11;
            this.currWeight_updateBtn.Text = "Update";
            this.currWeight_updateBtn.UseVisualStyleBackColor = false;
            this.currWeight_updateBtn.Click += new System.EventHandler(this.currWeight_updateBtn_Click);
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
            this.panel1.Controls.Add(this.currWeight_weight);
            this.panel1.Controls.Add(this.currWeight_date);
            this.panel1.Controls.Add(this.currWeight_clearBtn);
            this.panel1.Controls.Add(this.currWeight_addBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 707);
            this.panel1.TabIndex = 4;
            // 
            // currWeight_weight
            // 
            this.currWeight_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currWeight_weight.Location = new System.Drawing.Point(23, 48);
            this.currWeight_weight.Name = "currWeight_weight";
            this.currWeight_weight.Size = new System.Drawing.Size(251, 35);
            this.currWeight_weight.TabIndex = 12;
            // 
            // currWeight_date
            // 
            this.currWeight_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currWeight_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.currWeight_date.Location = new System.Drawing.Point(23, 127);
            this.currWeight_date.Name = "currWeight_date";
            this.currWeight_date.Size = new System.Drawing.Size(251, 35);
            this.currWeight_date.TabIndex = 11;
            // 
            // currWeight_clearBtn
            // 
            this.currWeight_clearBtn.BackColor = System.Drawing.Color.Indigo;
            this.currWeight_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currWeight_clearBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currWeight_clearBtn.ForeColor = System.Drawing.Color.White;
            this.currWeight_clearBtn.Location = new System.Drawing.Point(23, 631);
            this.currWeight_clearBtn.Name = "currWeight_clearBtn";
            this.currWeight_clearBtn.Size = new System.Drawing.Size(251, 62);
            this.currWeight_clearBtn.TabIndex = 10;
            this.currWeight_clearBtn.Text = "Clear";
            this.currWeight_clearBtn.UseVisualStyleBackColor = false;
            this.currWeight_clearBtn.Click += new System.EventHandler(this.currWeight_clearBtn_Click);
            // 
            // currWeight_addBtn
            // 
            this.currWeight_addBtn.BackColor = System.Drawing.Color.Indigo;
            this.currWeight_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currWeight_addBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currWeight_addBtn.ForeColor = System.Drawing.Color.White;
            this.currWeight_addBtn.Location = new System.Drawing.Point(23, 548);
            this.currWeight_addBtn.Name = "currWeight_addBtn";
            this.currWeight_addBtn.Size = new System.Drawing.Size(251, 61);
            this.currWeight_addBtn.TabIndex = 9;
            this.currWeight_addBtn.Text = "Add";
            this.currWeight_addBtn.UseVisualStyleBackColor = false;
            this.currWeight_addBtn.Click += new System.EventHandler(this.currWeight_addBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current weight:";
            // 
            // CurrentWeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CurrentWeightForm";
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
        private System.Windows.Forms.Button currWeight_deleteBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button currWeight_updateBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox currWeight_weight;
        private System.Windows.Forms.DateTimePicker currWeight_date;
        private System.Windows.Forms.Button currWeight_clearBtn;
        private System.Windows.Forms.Button currWeight_addBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}
