
namespace Capstone_Project
{
    partial class ExhibitionScreen
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
            this.singlePieceButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.TextBox();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.juriedCheckBox = new System.Windows.Forms.CheckBox();
            this.juriedText = new System.Windows.Forms.TextBox();
            this.feeCheckBox = new System.Windows.Forms.CheckBox();
            this.feeText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.artView = new System.Windows.Forms.DataGridView();
            this.saveEditButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cityText = new System.Windows.Forms.TextBox();
            this.stateText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.zipText = new System.Windows.Forms.TextBox();
            this.countryText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.errorText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.artView)).BeginInit();
            this.SuspendLayout();
            // 
            // singlePieceButton
            // 
            this.singlePieceButton.Enabled = false;
            this.singlePieceButton.Location = new System.Drawing.Point(583, 220);
            this.singlePieceButton.Name = "singlePieceButton";
            this.singlePieceButton.Size = new System.Drawing.Size(92, 23);
            this.singlePieceButton.TabIndex = 1;
            this.singlePieceButton.Text = "To This Piece";
            this.singlePieceButton.UseVisualStyleBackColor = true;
            this.singlePieceButton.Click += new System.EventHandler(this.SinglePieceButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(462, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address";
            // 
            // nameText
            // 
            this.nameText.Enabled = false;
            this.nameText.Location = new System.Drawing.Point(82, 46);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(192, 23);
            this.nameText.TabIndex = 7;
            // 
            // addressText
            // 
            this.addressText.Enabled = false;
            this.addressText.Location = new System.Drawing.Point(82, 83);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(192, 23);
            this.addressText.TabIndex = 8;
            // 
            // startTime
            // 
            this.startTime.Enabled = false;
            this.startTime.Location = new System.Drawing.Point(423, 46);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(200, 23);
            this.startTime.TabIndex = 9;
            // 
            // endTime
            // 
            this.endTime.Enabled = false;
            this.endTime.Location = new System.Drawing.Point(423, 83);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(200, 23);
            this.endTime.TabIndex = 10;
            // 
            // juriedCheckBox
            // 
            this.juriedCheckBox.AutoSize = true;
            this.juriedCheckBox.Enabled = false;
            this.juriedCheckBox.Location = new System.Drawing.Point(352, 124);
            this.juriedCheckBox.Name = "juriedCheckBox";
            this.juriedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.juriedCheckBox.TabIndex = 11;
            this.juriedCheckBox.UseVisualStyleBackColor = true;
            this.juriedCheckBox.CheckedChanged += new System.EventHandler(this.JuriedCheckBox_CheckedChanged);
            // 
            // juriedText
            // 
            this.juriedText.Enabled = false;
            this.juriedText.Location = new System.Drawing.Point(423, 120);
            this.juriedText.Name = "juriedText";
            this.juriedText.Size = new System.Drawing.Size(200, 23);
            this.juriedText.TabIndex = 12;
            // 
            // feeCheckBox
            // 
            this.feeCheckBox.AutoSize = true;
            this.feeCheckBox.Enabled = false;
            this.feeCheckBox.Location = new System.Drawing.Point(352, 162);
            this.feeCheckBox.Name = "feeCheckBox";
            this.feeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.feeCheckBox.TabIndex = 13;
            this.feeCheckBox.UseVisualStyleBackColor = true;
            this.feeCheckBox.CheckedChanged += new System.EventHandler(this.FeeCheckBox_CheckedChanged);
            // 
            // feeText
            // 
            this.feeText.Enabled = false;
            this.feeText.Location = new System.Drawing.Point(423, 158);
            this.feeText.Name = "feeText";
            this.feeText.Size = new System.Drawing.Size(100, 23);
            this.feeText.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Art in this Exhibition";
            // 
            // artView
            // 
            this.artView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.artView.Location = new System.Drawing.Point(11, 268);
            this.artView.Name = "artView";
            this.artView.RowHeadersVisible = false;
            this.artView.RowTemplate.Height = 25;
            this.artView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.artView.Size = new System.Drawing.Size(675, 129);
            this.artView.TabIndex = 18;
            this.artView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.artView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.artView_CellDoubleClick);
            // 
            // saveEditButton
            // 
            this.saveEditButton.Location = new System.Drawing.Point(548, 12);
            this.saveEditButton.Name = "saveEditButton";
            this.saveEditButton.Size = new System.Drawing.Size(75, 23);
            this.saveEditButton.TabIndex = 20;
            this.saveEditButton.Text = "Edit";
            this.saveEditButton.UseVisualStyleBackColor = true;
            this.saveEditButton.Click += new System.EventHandler(this.SaveEditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 21;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "City";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "State";
            // 
            // cityText
            // 
            this.cityText.Enabled = false;
            this.cityText.Location = new System.Drawing.Point(82, 120);
            this.cityText.Name = "cityText";
            this.cityText.Size = new System.Drawing.Size(100, 23);
            this.cityText.TabIndex = 25;
            // 
            // stateText
            // 
            this.stateText.Enabled = false;
            this.stateText.Location = new System.Drawing.Point(82, 158);
            this.stateText.Name = "stateText";
            this.stateText.Size = new System.Drawing.Size(100, 23);
            this.stateText.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Zip Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Country";
            // 
            // zipText
            // 
            this.zipText.Enabled = false;
            this.zipText.Location = new System.Drawing.Point(82, 196);
            this.zipText.Name = "zipText";
            this.zipText.Size = new System.Drawing.Size(100, 23);
            this.zipText.TabIndex = 29;
            // 
            // countryText
            // 
            this.countryText.Enabled = false;
            this.countryText.Location = new System.Drawing.Point(423, 199);
            this.countryText.Name = "countryText";
            this.countryText.Size = new System.Drawing.Size(100, 23);
            this.countryText.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Juried";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(367, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "App Fee";
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.Location = new System.Drawing.Point(102, 16);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(0, 15);
            this.errorText.TabIndex = 33;
            // 
            // ExhibitionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 422);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.countryText);
            this.Controls.Add(this.zipText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.stateText);
            this.Controls.Add(this.cityText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.singlePieceButton);
            this.Controls.Add(this.saveEditButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.juriedText);
            this.Controls.Add(this.juriedCheckBox);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.artView);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.feeText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.feeCheckBox);
            this.Name = "ExhibitionScreen";
            this.Text = "ExhibitionScreen";
            this.Load += new System.EventHandler(this.ExhibitionScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.artView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button singlePieceButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.CheckBox juriedCheckBox;
        private System.Windows.Forms.TextBox juriedText;
        private System.Windows.Forms.CheckBox feeCheckBox;
        private System.Windows.Forms.TextBox feeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView artView;
        private System.Windows.Forms.Button saveEditButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.TextBox stateText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox zipText;
        private System.Windows.Forms.TextBox countryText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label errorText;
    }
}