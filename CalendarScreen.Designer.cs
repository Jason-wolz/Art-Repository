namespace Capstone_Project
{
    partial class CalendarScreen
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
            this.exhibitionCalendar = new System.Windows.Forms.MonthCalendar();
            this.exhibitionView = new System.Windows.Forms.DataGridView();
            this.exhibitionButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.exhibitionView)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(681, 362);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // exhibitionCalendar
            // 
            this.exhibitionCalendar.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.exhibitionCalendar.Location = new System.Drawing.Point(18, 29);
            this.exhibitionCalendar.Name = "exhibitionCalendar";
            this.exhibitionCalendar.TabIndex = 1;
            // 
            // exhibitionView
            // 
            this.exhibitionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exhibitionView.Location = new System.Drawing.Point(516, 29);
            this.exhibitionView.Name = "exhibitionView";
            this.exhibitionView.RowHeadersVisible = false;
            this.exhibitionView.RowTemplate.Height = 25;
            this.exhibitionView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.exhibitionView.Size = new System.Drawing.Size(240, 309);
            this.exhibitionView.TabIndex = 2;
            this.exhibitionView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.exhibitionView_CellClick);
            this.exhibitionView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.exhibitionView_CellContentDoubleClick);
            // 
            // exhibitionButton
            // 
            this.exhibitionButton.Location = new System.Drawing.Point(557, 354);
            this.exhibitionButton.Name = "exhibitionButton";
            this.exhibitionButton.Size = new System.Drawing.Size(86, 38);
            this.exhibitionButton.TabIndex = 3;
            this.exhibitionButton.Text = "Go to this Exhibition";
            this.exhibitionButton.UseVisualStyleBackColor = true;
            this.exhibitionButton.Click += new System.EventHandler(this.exhibitionButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(421, 354);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 38);
            this.newButton.TabIndex = 4;
            this.newButton.Text = "New Exhibition";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // CalendarScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 406);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.exhibitionButton);
            this.Controls.Add(this.exhibitionView);
            this.Controls.Add(this.exhibitionCalendar);
            this.Controls.Add(this.backButton);
            this.Name = "CalendarScreen";
            this.Text = "CalendarScreen";
            this.Load += new System.EventHandler(this.CalendarScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exhibitionView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.MonthCalendar exhibitionCalendar;
        private System.Windows.Forms.DataGridView exhibitionView;
        private System.Windows.Forms.Button exhibitionButton;
        private System.Windows.Forms.Button newButton;
    }
}