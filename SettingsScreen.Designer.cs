
namespace Capstone_Project
{
    partial class SettingsScreen
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
            this.backButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.nightCheck = new System.Windows.Forms.CheckBox();
            this.smallCheck = new System.Windows.Forms.RadioButton();
            this.largeCheck = new System.Windows.Forms.RadioButton();
            this.mediumCheck = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(182, 256);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(182, 185);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(75, 23);
            this.reportsButton.TabIndex = 1;
            this.reportsButton.Text = "Reports";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // nightCheck
            // 
            this.nightCheck.AutoSize = true;
            this.nightCheck.Location = new System.Drawing.Point(174, 52);
            this.nightCheck.Name = "nightCheck";
            this.nightCheck.Size = new System.Drawing.Size(90, 19);
            this.nightCheck.TabIndex = 2;
            this.nightCheck.Text = "Night Mode";
            this.nightCheck.UseVisualStyleBackColor = true;
            this.nightCheck.CheckedChanged += new System.EventHandler(this.nightCheck_CheckedChanged);
            // 
            // smallCheck
            // 
            this.smallCheck.AutoSize = true;
            this.smallCheck.Location = new System.Drawing.Point(41, 22);
            this.smallCheck.Name = "smallCheck";
            this.smallCheck.Size = new System.Drawing.Size(54, 19);
            this.smallCheck.TabIndex = 3;
            this.smallCheck.TabStop = true;
            this.smallCheck.Text = "Small";
            this.smallCheck.UseVisualStyleBackColor = true;
            this.smallCheck.CheckedChanged += new System.EventHandler(this.smallCheck_CheckedChanged);
            // 
            // largeCheck
            // 
            this.largeCheck.AutoSize = true;
            this.largeCheck.Location = new System.Drawing.Point(41, 71);
            this.largeCheck.Name = "largeCheck";
            this.largeCheck.Size = new System.Drawing.Size(54, 19);
            this.largeCheck.TabIndex = 4;
            this.largeCheck.TabStop = true;
            this.largeCheck.Text = "Large";
            this.largeCheck.UseVisualStyleBackColor = true;
            this.largeCheck.CheckedChanged += new System.EventHandler(this.largeCheck_CheckedChanged);
            // 
            // mediumCheck
            // 
            this.mediumCheck.AutoSize = true;
            this.mediumCheck.Location = new System.Drawing.Point(41, 46);
            this.mediumCheck.Name = "mediumCheck";
            this.mediumCheck.Size = new System.Drawing.Size(70, 19);
            this.mediumCheck.TabIndex = 5;
            this.mediumCheck.TabStop = true;
            this.mediumCheck.Text = "Medium";
            this.mediumCheck.UseVisualStyleBackColor = true;
            this.mediumCheck.CheckedChanged += new System.EventHandler(this.mediumCheck_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mediumCheck);
            this.groupBox1.Controls.Add(this.smallCheck);
            this.groupBox1.Controls.Add(this.largeCheck);
            this.groupBox1.Location = new System.Drawing.Point(124, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Size";
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 373);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nightCheck);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.backButton);
            this.Name = "SettingsScreen";
            this.Text = "SettingsScreen";
            this.Load += new System.EventHandler(this.SettingsScreen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.CheckBox nightCheck;
        private System.Windows.Forms.RadioButton smallCheck;
        private System.Windows.Forms.RadioButton largeCheck;
        private System.Windows.Forms.RadioButton mediumCheck;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}