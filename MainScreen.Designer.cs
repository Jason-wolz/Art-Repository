
namespace Capstone_Project
{
    partial class MainScreen
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
            this.piecesButton = new System.Windows.Forms.Button();
            this.calendarButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // piecesButton
            // 
            this.piecesButton.Location = new System.Drawing.Point(-8, 40);
            this.piecesButton.Name = "piecesButton";
            this.piecesButton.Size = new System.Drawing.Size(297, 29);
            this.piecesButton.TabIndex = 1;
            this.piecesButton.Text = "Pieces";
            this.piecesButton.UseVisualStyleBackColor = true;
            this.piecesButton.Click += new System.EventHandler(this.piecesButton_Click);
            // 
            // calendarButton
            // 
            this.calendarButton.Location = new System.Drawing.Point(-8, 108);
            this.calendarButton.Name = "calendarButton";
            this.calendarButton.Size = new System.Drawing.Size(297, 29);
            this.calendarButton.TabIndex = 2;
            this.calendarButton.Text = "Calendar";
            this.calendarButton.UseVisualStyleBackColor = true;
            this.calendarButton.Click += new System.EventHandler(this.calendarButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(-8, 185);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(297, 29);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 279);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.calendarButton);
            this.Controls.Add(this.piecesButton);
            this.Name = "MainScreen";
            this.Text = "Home Screen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button piecesButton;
        private System.Windows.Forms.Button calendarButton;
        private System.Windows.Forms.Button settingsButton;
    }
}