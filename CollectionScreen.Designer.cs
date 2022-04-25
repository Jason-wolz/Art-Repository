
namespace Capstone_Project
{
    partial class CollectionScreen
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
            this.singlePieceButton = new System.Windows.Forms.Button();
            this.artDataGrid = new System.Windows.Forms.DataGridView();
            this.samplePicture = new System.Windows.Forms.PictureBox();
            this.errorText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.artDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(407, 322);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // singlePieceButton
            // 
            this.singlePieceButton.Location = new System.Drawing.Point(504, 322);
            this.singlePieceButton.Name = "singlePieceButton";
            this.singlePieceButton.Size = new System.Drawing.Size(75, 23);
            this.singlePieceButton.TabIndex = 1;
            this.singlePieceButton.Text = "This Piece";
            this.singlePieceButton.UseVisualStyleBackColor = true;
            this.singlePieceButton.Click += new System.EventHandler(this.singlePieceButton_Click);
            // 
            // artDataGrid
            // 
            this.artDataGrid.AllowUserToAddRows = false;
            this.artDataGrid.AllowUserToDeleteRows = false;
            this.artDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.artDataGrid.Location = new System.Drawing.Point(155, 34);
            this.artDataGrid.Name = "artDataGrid";
            this.artDataGrid.ReadOnly = true;
            this.artDataGrid.RowHeadersVisible = false;
            this.artDataGrid.RowTemplate.Height = 25;
            this.artDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.artDataGrid.Size = new System.Drawing.Size(424, 237);
            this.artDataGrid.TabIndex = 2;
            this.artDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.artDataGrid_CellContentClick);
            // 
            // samplePicture
            // 
            this.samplePicture.Location = new System.Drawing.Point(12, 34);
            this.samplePicture.Name = "samplePicture";
            this.samplePicture.Size = new System.Drawing.Size(137, 237);
            this.samplePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.samplePicture.TabIndex = 3;
            this.samplePicture.TabStop = false;
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.Location = new System.Drawing.Point(12, 303);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(0, 15);
            this.errorText.TabIndex = 4;
            // 
            // CollectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 374);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.samplePicture);
            this.Controls.Add(this.artDataGrid);
            this.Controls.Add(this.singlePieceButton);
            this.Controls.Add(this.backButton);
            this.Name = "CollectionScreen";
            this.Text = "CollectionScreen";
            ((System.ComponentModel.ISupportInitialize)(this.artDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button singlePieceButton;
        private System.Windows.Forms.DataGridView artDataGrid;
        private System.Windows.Forms.PictureBox samplePicture;
        private System.Windows.Forms.Label errorText;
    }
}