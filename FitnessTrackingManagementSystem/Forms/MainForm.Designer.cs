namespace FitnessTrackingManagementSystem
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.main_logoutBtn = new System.Windows.Forms.Button();
            this.main_settingsBtn = new System.Windows.Forms.Button();
            this.main_calCalcBtn = new System.Windows.Forms.Button();
            this.main_weightBtn = new System.Windows.Forms.Button();
            this.main_foodLogBtn = new System.Windows.Forms.Button();
            this.main_fitnessLogBtn = new System.Windows.Forms.Button();
            this.main_dashboardBtn = new System.Windows.Forms.Button();
            this.main_welcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dashboard1 = new FitnessTrackingManagementSystem.Dashboard();
            this.calorieCalculator1 = new FitnessTrackingManagementSystem.CalorieCalculator();
            this.currentWeightForm1 = new FitnessTrackingManagementSystem.CurrentWeightForm();
            this.foodLogForm1 = new FitnessTrackingManagementSystem.FoodLogForm();
            this.fitnessLog1 = new FitnessTrackingManagementSystem.FitnessLogForm();
            this.settingsForm1 = new FitnessTrackingManagementSystem.SettingsForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.main_logoutBtn);
            this.panel1.Controls.Add(this.main_settingsBtn);
            this.panel1.Controls.Add(this.main_calCalcBtn);
            this.panel1.Controls.Add(this.main_weightBtn);
            this.panel1.Controls.Add(this.main_foodLogBtn);
            this.panel1.Controls.Add(this.main_fitnessLogBtn);
            this.panel1.Controls.Add(this.main_dashboardBtn);
            this.panel1.Controls.Add(this.main_welcome);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 744);
            this.panel1.TabIndex = 0;
            // 
            // main_logoutBtn
            // 
            this.main_logoutBtn.BackColor = System.Drawing.Color.Indigo;
            this.main_logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main_logoutBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_logoutBtn.ForeColor = System.Drawing.Color.White;
            this.main_logoutBtn.Location = new System.Drawing.Point(12, 663);
            this.main_logoutBtn.Name = "main_logoutBtn";
            this.main_logoutBtn.Size = new System.Drawing.Size(220, 49);
            this.main_logoutBtn.TabIndex = 9;
            this.main_logoutBtn.Text = "Log out";
            this.main_logoutBtn.UseVisualStyleBackColor = false;
            this.main_logoutBtn.Click += new System.EventHandler(this.main_logoutBtn_Click);
            // 
            // main_settingsBtn
            // 
            this.main_settingsBtn.BackColor = System.Drawing.Color.Indigo;
            this.main_settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main_settingsBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_settingsBtn.ForeColor = System.Drawing.Color.White;
            this.main_settingsBtn.Location = new System.Drawing.Point(12, 601);
            this.main_settingsBtn.Name = "main_settingsBtn";
            this.main_settingsBtn.Size = new System.Drawing.Size(220, 49);
            this.main_settingsBtn.TabIndex = 7;
            this.main_settingsBtn.Text = "Settings";
            this.main_settingsBtn.UseVisualStyleBackColor = false;
            this.main_settingsBtn.Click += new System.EventHandler(this.main_settingsBtn_Click);
            // 
            // main_calCalcBtn
            // 
            this.main_calCalcBtn.BackColor = System.Drawing.Color.Indigo;
            this.main_calCalcBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main_calCalcBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_calCalcBtn.ForeColor = System.Drawing.Color.White;
            this.main_calCalcBtn.Location = new System.Drawing.Point(12, 539);
            this.main_calCalcBtn.Name = "main_calCalcBtn";
            this.main_calCalcBtn.Size = new System.Drawing.Size(220, 49);
            this.main_calCalcBtn.TabIndex = 6;
            this.main_calCalcBtn.Text = "Calorie Calculator";
            this.main_calCalcBtn.UseVisualStyleBackColor = false;
            this.main_calCalcBtn.Click += new System.EventHandler(this.main_calCalcBtn_Click);
            // 
            // main_weightBtn
            // 
            this.main_weightBtn.BackColor = System.Drawing.Color.Indigo;
            this.main_weightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main_weightBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_weightBtn.ForeColor = System.Drawing.Color.White;
            this.main_weightBtn.Location = new System.Drawing.Point(12, 479);
            this.main_weightBtn.Name = "main_weightBtn";
            this.main_weightBtn.Size = new System.Drawing.Size(220, 49);
            this.main_weightBtn.TabIndex = 5;
            this.main_weightBtn.Text = "Current Weight";
            this.main_weightBtn.UseVisualStyleBackColor = false;
            this.main_weightBtn.Click += new System.EventHandler(this.main_weightBtn_Click);
            // 
            // main_foodLogBtn
            // 
            this.main_foodLogBtn.BackColor = System.Drawing.Color.Indigo;
            this.main_foodLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main_foodLogBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_foodLogBtn.ForeColor = System.Drawing.Color.White;
            this.main_foodLogBtn.Location = new System.Drawing.Point(12, 417);
            this.main_foodLogBtn.Name = "main_foodLogBtn";
            this.main_foodLogBtn.Size = new System.Drawing.Size(220, 49);
            this.main_foodLogBtn.TabIndex = 4;
            this.main_foodLogBtn.Text = "Food Log";
            this.main_foodLogBtn.UseVisualStyleBackColor = false;
            this.main_foodLogBtn.Click += new System.EventHandler(this.main_foodLogBtn_Click);
            // 
            // main_fitnessLogBtn
            // 
            this.main_fitnessLogBtn.BackColor = System.Drawing.Color.Indigo;
            this.main_fitnessLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main_fitnessLogBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_fitnessLogBtn.ForeColor = System.Drawing.Color.White;
            this.main_fitnessLogBtn.Location = new System.Drawing.Point(12, 355);
            this.main_fitnessLogBtn.Name = "main_fitnessLogBtn";
            this.main_fitnessLogBtn.Size = new System.Drawing.Size(220, 49);
            this.main_fitnessLogBtn.TabIndex = 3;
            this.main_fitnessLogBtn.Text = "Fitness Log";
            this.main_fitnessLogBtn.UseVisualStyleBackColor = false;
            this.main_fitnessLogBtn.Click += new System.EventHandler(this.main_fitnessLogBtn_Click);
            // 
            // main_dashboardBtn
            // 
            this.main_dashboardBtn.BackColor = System.Drawing.Color.Indigo;
            this.main_dashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main_dashboardBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_dashboardBtn.ForeColor = System.Drawing.Color.White;
            this.main_dashboardBtn.Location = new System.Drawing.Point(12, 293);
            this.main_dashboardBtn.Name = "main_dashboardBtn";
            this.main_dashboardBtn.Size = new System.Drawing.Size(220, 49);
            this.main_dashboardBtn.TabIndex = 2;
            this.main_dashboardBtn.Text = "Dashboard";
            this.main_dashboardBtn.UseVisualStyleBackColor = false;
            this.main_dashboardBtn.Click += new System.EventHandler(this.main_dashboardBtn_Click);
            // 
            // main_welcome
            // 
            this.main_welcome.AutoSize = true;
            this.main_welcome.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_welcome.ForeColor = System.Drawing.Color.White;
            this.main_welcome.Location = new System.Drawing.Point(61, 208);
            this.main_welcome.Name = "main_welcome";
            this.main_welcome.Size = new System.Drawing.Size(118, 29);
            this.main_welcome.TabIndex = 1;
            this.main_welcome.Text = "Welcome!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FitnessTrackingManagementSystem.Properties.Resources.main_icon;
            this.pictureBox1.Location = new System.Drawing.Point(49, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dashboard1);
            this.panel2.Controls.Add(this.calorieCalculator1);
            this.panel2.Controls.Add(this.currentWeightForm1);
            this.panel2.Controls.Add(this.foodLogForm1);
            this.panel2.Controls.Add(this.fitnessLog1);
            this.panel2.Controls.Add(this.settingsForm1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 744);
            this.panel2.TabIndex = 1;
            // 
            // dashboard1
            // 
            this.dashboard1.Location = new System.Drawing.Point(0, 0);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(928, 744);
            this.dashboard1.TabIndex = 4;
            // 
            // calorieCalculator1
            // 
            this.calorieCalculator1.Location = new System.Drawing.Point(0, 0);
            this.calorieCalculator1.Name = "calorieCalculator1";
            this.calorieCalculator1.Size = new System.Drawing.Size(928, 744);
            this.calorieCalculator1.TabIndex = 3;
            // 
            // currentWeightForm1
            // 
            this.currentWeightForm1.Location = new System.Drawing.Point(0, 0);
            this.currentWeightForm1.Name = "currentWeightForm1";
            this.currentWeightForm1.Size = new System.Drawing.Size(928, 744);
            this.currentWeightForm1.TabIndex = 2;
            // 
            // foodLogForm1
            // 
            this.foodLogForm1.Location = new System.Drawing.Point(0, 0);
            this.foodLogForm1.Name = "foodLogForm1";
            this.foodLogForm1.Size = new System.Drawing.Size(928, 744);
            this.foodLogForm1.TabIndex = 1;
            // 
            // fitnessLog1
            // 
            this.fitnessLog1.Location = new System.Drawing.Point(0, 0);
            this.fitnessLog1.Name = "fitnessLog1";
            this.fitnessLog1.Size = new System.Drawing.Size(928, 744);
            this.fitnessLog1.TabIndex = 0;
            // 
            // settingsForm1
            // 
            this.settingsForm1.Location = new System.Drawing.Point(0, 0);
            this.settingsForm1.Name = "settingsForm1";
            this.settingsForm1.Size = new System.Drawing.Size(928, 744);
            this.settingsForm1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fitness Tracking Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button main_dashboardBtn;
        private System.Windows.Forms.Label main_welcome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button main_fitnessLogBtn;
        private System.Windows.Forms.Button main_logoutBtn;
        private System.Windows.Forms.Button main_settingsBtn;
        private System.Windows.Forms.Button main_calCalcBtn;
        private System.Windows.Forms.Button main_weightBtn;
        private System.Windows.Forms.Button main_foodLogBtn;
        private System.Windows.Forms.Panel panel2;
        private FitnessLogForm fitnessLog1;
        private FoodLogForm foodLogForm1;
        private CurrentWeightForm currentWeightForm1;
        private CalorieCalculator calorieCalculator1;
        private Dashboard dashboard1;
        private SettingsForm settingsForm1;
    }
}