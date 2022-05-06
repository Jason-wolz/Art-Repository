
namespace Capstone_Project
{
    partial class ReportsScreen
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
            this.lastYearView = new System.Windows.Forms.DataGridView();
            this.lastYearButton = new System.Windows.Forms.Button();
            this.artButton = new System.Windows.Forms.Button();
            this.allArtButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.errorText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lastYearView)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(528, 390);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // lastYearView
            // 
            this.lastYearView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lastYearView.Location = new System.Drawing.Point(13, 26);
            this.lastYearView.Name = "lastYearView";
            this.lastYearView.RowHeadersVisible = false;
            this.lastYearView.RowTemplate.Height = 25;
            this.lastYearView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lastYearView.Size = new System.Drawing.Size(572, 319);
            this.lastYearView.TabIndex = 1;
            this.lastYearView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lastYearView_CellClick);
            this.lastYearView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lastYearView_CellDoubleClick);
            // 
            // lastYearButton
            // 
            this.lastYearButton.Location = new System.Drawing.Point(13, 373);
            this.lastYearButton.Name = "lastYearButton";
            this.lastYearButton.Size = new System.Drawing.Size(124, 40);
            this.lastYearButton.TabIndex = 2;
            this.lastYearButton.Text = "All work done in the last year";
            this.lastYearButton.UseVisualStyleBackColor = true;
            this.lastYearButton.Click += new System.EventHandler(this.lastYearButton_Click);
            // 
            // artButton
            // 
            this.artButton.Location = new System.Drawing.Point(419, 373);
            this.artButton.Name = "artButton";
            this.artButton.Size = new System.Drawing.Size(88, 40);
            this.artButton.TabIndex = 3;
            this.artButton.Text = "Go to this piece";
            this.artButton.UseVisualStyleBackColor = true;
            this.artButton.Visible = false;
            this.artButton.Click += new System.EventHandler(this.artButton_Click);
            // 
            // allArtButton
            // 
            this.allArtButton.Location = new System.Drawing.Point(155, 373);
            this.allArtButton.Name = "allArtButton";
            this.allArtButton.Size = new System.Drawing.Size(74, 40);
            this.allArtButton.TabIndex = 4;
            this.allArtButton.Text = "All work";
            this.allArtButton.UseVisualStyleBackColor = true;
            this.allArtButton.Click += new System.EventHandler(this.allArtButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(248, 373);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(153, 40);
            this.downloadButton.TabIndex = 5;
            this.downloadButton.Text = "Download all information on this artwork";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Visible = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.Location = new System.Drawing.Point(13, 426);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(0, 15);
            this.errorText.TabIndex = 6;
            // 
            // ReportsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(615, 450);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.allArtButton);
            this.Controls.Add(this.artButton);
            this.Controls.Add(this.lastYearButton);
            this.Controls.Add(this.lastYearView);
            this.Controls.Add(this.backButton);
            this.Name = "ReportsScreen";
            this.Text = "ReportsScreen";
            this.Load += new System.EventHandler(this.ReportsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lastYearView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridView lastYearView;
        private System.Windows.Forms.Button lastYearButton;
        private System.Windows.Forms.Button artButton;
        private System.Windows.Forms.Button allArtButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label errorText;
    }
}