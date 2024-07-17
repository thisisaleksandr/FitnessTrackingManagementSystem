namespace FitnessTrackingManagementSystem
{
    partial class CalorieCalculator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.calculator_weightGoal = new System.Windows.Forms.ComboBox();
            this.settings_weightLossGoal = new System.Windows.Forms.Label();
            this.calculator_clearBtn = new System.Windows.Forms.Button();
            this.calculator_activityLvl = new System.Windows.Forms.ComboBox();
            this.settings_activityLevel = new System.Windows.Forms.Label();
            this.settings_age = new System.Windows.Forms.Label();
            this.calculator_age = new System.Windows.Forms.TextBox();
            this.settings_weight = new System.Windows.Forms.Label();
            this.calculator_weight = new System.Windows.Forms.TextBox();
            this.settings_height = new System.Windows.Forms.Label();
            this.calculator_sex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.calculator_heightFeet = new System.Windows.Forms.TextBox();
            this.calculator_calculateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.calculator_recomGoal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.calculator_bmr = new System.Windows.Forms.Label();
            this.calculator_setAsNewBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calculator_heightInches = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.calculator_heightInches);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.calculator_weightGoal);
            this.panel1.Controls.Add(this.settings_weightLossGoal);
            this.panel1.Controls.Add(this.calculator_clearBtn);
            this.panel1.Controls.Add(this.calculator_activityLvl);
            this.panel1.Controls.Add(this.settings_activityLevel);
            this.panel1.Controls.Add(this.settings_age);
            this.panel1.Controls.Add(this.calculator_age);
            this.panel1.Controls.Add(this.settings_weight);
            this.panel1.Controls.Add(this.calculator_weight);
            this.panel1.Controls.Add(this.settings_height);
            this.panel1.Controls.Add(this.calculator_sex);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.calculator_heightFeet);
            this.panel1.Controls.Add(this.calculator_calculateBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 716);
            this.panel1.TabIndex = 4;
            // 
            // calculator_weightGoal
            // 
            this.calculator_weightGoal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_weightGoal.FormattingEnabled = true;
            this.calculator_weightGoal.Items.AddRange(new object[] {
            "No Weight Loss",
            "Moderate Weight Loss",
            "Very Fast Weight Loss"});
            this.calculator_weightGoal.Location = new System.Drawing.Point(23, 518);
            this.calculator_weightGoal.Name = "calculator_weightGoal";
            this.calculator_weightGoal.Size = new System.Drawing.Size(422, 37);
            this.calculator_weightGoal.TabIndex = 26;
            // 
            // settings_weightLossGoal
            // 
            this.settings_weightLossGoal.AutoSize = true;
            this.settings_weightLossGoal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_weightLossGoal.Location = new System.Drawing.Point(18, 486);
            this.settings_weightLossGoal.Name = "settings_weightLossGoal";
            this.settings_weightLossGoal.Size = new System.Drawing.Size(187, 29);
            this.settings_weightLossGoal.TabIndex = 25;
            this.settings_weightLossGoal.Text = "Weight loss goal";
            // 
            // calculator_clearBtn
            // 
            this.calculator_clearBtn.BackColor = System.Drawing.Color.Indigo;
            this.calculator_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculator_clearBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_clearBtn.ForeColor = System.Drawing.Color.White;
            this.calculator_clearBtn.Location = new System.Drawing.Point(23, 639);
            this.calculator_clearBtn.Name = "calculator_clearBtn";
            this.calculator_clearBtn.Size = new System.Drawing.Size(422, 61);
            this.calculator_clearBtn.TabIndex = 24;
            this.calculator_clearBtn.Text = "Clear";
            this.calculator_clearBtn.UseVisualStyleBackColor = false;
            this.calculator_clearBtn.Click += new System.EventHandler(this.calculator_clearBtn_Click);
            // 
            // calculator_activityLvl
            // 
            this.calculator_activityLvl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_activityLvl.FormattingEnabled = true;
            this.calculator_activityLvl.Items.AddRange(new object[] {
            "No Exercise",
            "Light Exercise",
            "Moderate exercise",
            "Heavy exercise"});
            this.calculator_activityLvl.Location = new System.Drawing.Point(23, 433);
            this.calculator_activityLvl.Name = "calculator_activityLvl";
            this.calculator_activityLvl.Size = new System.Drawing.Size(422, 37);
            this.calculator_activityLvl.TabIndex = 23;
            // 
            // settings_activityLevel
            // 
            this.settings_activityLevel.AutoSize = true;
            this.settings_activityLevel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_activityLevel.Location = new System.Drawing.Point(18, 401);
            this.settings_activityLevel.Name = "settings_activityLevel";
            this.settings_activityLevel.Size = new System.Drawing.Size(144, 29);
            this.settings_activityLevel.TabIndex = 22;
            this.settings_activityLevel.Text = "Activity level";
            // 
            // settings_age
            // 
            this.settings_age.AutoSize = true;
            this.settings_age.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_age.Location = new System.Drawing.Point(18, 317);
            this.settings_age.Name = "settings_age";
            this.settings_age.Size = new System.Drawing.Size(53, 29);
            this.settings_age.TabIndex = 20;
            this.settings_age.Text = "Age";
            // 
            // calculator_age
            // 
            this.calculator_age.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_age.Location = new System.Drawing.Point(23, 349);
            this.calculator_age.Name = "calculator_age";
            this.calculator_age.Size = new System.Drawing.Size(422, 35);
            this.calculator_age.TabIndex = 19;
            // 
            // settings_weight
            // 
            this.settings_weight.AutoSize = true;
            this.settings_weight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_weight.Location = new System.Drawing.Point(18, 238);
            this.settings_weight.Name = "settings_weight";
            this.settings_weight.Size = new System.Drawing.Size(131, 29);
            this.settings_weight.TabIndex = 18;
            this.settings_weight.Text = "Weight (lb)";
            // 
            // calculator_weight
            // 
            this.calculator_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_weight.Location = new System.Drawing.Point(23, 270);
            this.calculator_weight.Name = "calculator_weight";
            this.calculator_weight.Size = new System.Drawing.Size(422, 35);
            this.calculator_weight.TabIndex = 17;
            // 
            // settings_height
            // 
            this.settings_height.AutoSize = true;
            this.settings_height.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_height.Location = new System.Drawing.Point(18, 159);
            this.settings_height.Name = "settings_height";
            this.settings_height.Size = new System.Drawing.Size(89, 29);
            this.settings_height.TabIndex = 16;
            this.settings_height.Text = "Height:";
            // 
            // calculator_sex
            // 
            this.calculator_sex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_sex.FormattingEnabled = true;
            this.calculator_sex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.calculator_sex.Location = new System.Drawing.Point(23, 108);
            this.calculator_sex.Name = "calculator_sex";
            this.calculator_sex.Size = new System.Drawing.Size(422, 37);
            this.calculator_sex.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sex:";
            // 
            // calculator_heightFeet
            // 
            this.calculator_heightFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_heightFeet.Location = new System.Drawing.Point(23, 191);
            this.calculator_heightFeet.Name = "calculator_heightFeet";
            this.calculator_heightFeet.Size = new System.Drawing.Size(139, 35);
            this.calculator_heightFeet.TabIndex = 12;
            // 
            // calculator_calculateBtn
            // 
            this.calculator_calculateBtn.BackColor = System.Drawing.Color.Indigo;
            this.calculator_calculateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculator_calculateBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_calculateBtn.ForeColor = System.Drawing.Color.White;
            this.calculator_calculateBtn.Location = new System.Drawing.Point(23, 572);
            this.calculator_calculateBtn.Name = "calculator_calculateBtn";
            this.calculator_calculateBtn.Size = new System.Drawing.Size(422, 61);
            this.calculator_calculateBtn.TabIndex = 9;
            this.calculator_calculateBtn.Text = "Calculate";
            this.calculator_calculateBtn.UseVisualStyleBackColor = false;
            this.calculator_calculateBtn.Click += new System.EventHandler(this.calculator_calculateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calorie deficit calculator";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.calculator_recomGoal);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.calculator_bmr);
            this.panel2.Controls.Add(this.calculator_setAsNewBtn);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(492, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 716);
            this.panel2.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(387, 29);
            this.label9.TabIndex = 26;
            this.label9.Text = "Recommended Calorie Deficit Goal:";
            // 
            // calculator_recomGoal
            // 
            this.calculator_recomGoal.AutoSize = true;
            this.calculator_recomGoal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_recomGoal.Location = new System.Drawing.Point(25, 214);
            this.calculator_recomGoal.Name = "calculator_recomGoal";
            this.calculator_recomGoal.Size = new System.Drawing.Size(140, 29);
            this.calculator_recomGoal.TabIndex = 25;
            this.calculator_recomGoal.Text = "0 kcal/day";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 29);
            this.label8.TabIndex = 24;
            this.label8.Text = "Daily Caloric Needs:";
            // 
            // calculator_bmr
            // 
            this.calculator_bmr.AutoSize = true;
            this.calculator_bmr.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_bmr.Location = new System.Drawing.Point(25, 116);
            this.calculator_bmr.Name = "calculator_bmr";
            this.calculator_bmr.Size = new System.Drawing.Size(140, 29);
            this.calculator_bmr.TabIndex = 10;
            this.calculator_bmr.Text = "0 kcal/day";
            // 
            // calculator_setAsNewBtn
            // 
            this.calculator_setAsNewBtn.BackColor = System.Drawing.Color.Indigo;
            this.calculator_setAsNewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculator_setAsNewBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_setAsNewBtn.ForeColor = System.Drawing.Color.White;
            this.calculator_setAsNewBtn.Location = new System.Drawing.Point(25, 270);
            this.calculator_setAsNewBtn.Name = "calculator_setAsNewBtn";
            this.calculator_setAsNewBtn.Size = new System.Drawing.Size(387, 61);
            this.calculator_setAsNewBtn.TabIndex = 9;
            this.calculator_setAsNewBtn.Text = "Set this as a new settings";
            this.calculator_setAsNewBtn.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(165, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 29);
            this.label3.TabIndex = 27;
            this.label3.Text = "feet";
            // 
            // calculator_heightInches
            // 
            this.calculator_heightInches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator_heightInches.Location = new System.Drawing.Point(229, 191);
            this.calculator_heightInches.Name = "calculator_heightInches";
            this.calculator_heightInches.Size = new System.Drawing.Size(139, 35);
            this.calculator_heightInches.TabIndex = 28;
            this.calculator_heightInches.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 29);
            this.label4.TabIndex = 29;
            this.label4.Text = "inches";
            // 
            // CalorieCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CalorieCalculator";
            this.Size = new System.Drawing.Size(928, 744);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox calculator_heightFeet;
        private System.Windows.Forms.Button calculator_calculateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label settings_height;
        private System.Windows.Forms.ComboBox calculator_sex;
        private System.Windows.Forms.ComboBox calculator_activityLvl;
        private System.Windows.Forms.Label settings_activityLevel;
        private System.Windows.Forms.Label settings_age;
        private System.Windows.Forms.TextBox calculator_age;
        private System.Windows.Forms.Label settings_weight;
        private System.Windows.Forms.TextBox calculator_weight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label calculator_bmr;
        private System.Windows.Forms.Button calculator_setAsNewBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button calculator_clearBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label calculator_recomGoal;
        private System.Windows.Forms.ComboBox calculator_weightGoal;
        private System.Windows.Forms.Label settings_weightLossGoal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox calculator_heightInches;
        private System.Windows.Forms.Label label3;
    }
}
