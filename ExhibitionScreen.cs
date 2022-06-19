using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class ExhibitionScreen : Form//check required fields
    {
        readonly bool isNew;
        readonly int exhibID;
        bool isEditing = false;
        readonly List<Artwork> list = new List<Artwork>();
        public ExhibitionScreen(Exhibition exhibition)
        {
            InitializeComponent();
            if (exhibition.exhibitionId > 0)
            {
                exhibID = exhibition.exhibitionId;
                nameText.Text = exhibition.name;
                addressText.Text = exhibition.address;
                cityText.Text = exhibition.city;
                stateText.Text = exhibition.state;
                zipText.Text = exhibition.zipCode;
                countryText.Text = exhibition.country;
                startTime.Value = exhibition.startDate;
                endTime.Value = exhibition.endDate;
                if (exhibition.juror != "" && exhibition.juror != null)
                {
                    juriedCheckBox.Checked = true;
                    juriedText.Text = exhibition.juror;
                    juriedText.Enabled = false;
                }
                if (exhibition.applicationFee > 0)
                {
                    feeCheckBox.Checked = true;
                    feeText.Text = exhibition.applicationFee.ToString();
                    feeText.Enabled = false;
                }
                isNew = false;
            }
            else
            {
                isNew = true;
                SaveEditButton_Click(this, new EventArgs());
            }
            var temp = DataSetClass.ConnectToData(Program.simpleArt, exhibition.exhibitionId);
            list = temp.Cast<Artwork>().ToList();
            artView.DataSource = list;
            artView.Columns["artworkID"].Visible = false;
            artView.Columns["Title"].HeaderText = "Title";
            artView.Columns["medium"].HeaderText = "Medium";
            artView.Columns["length"].HeaderText = "Length";
            artView.Columns["width"].HeaderText = "Width";
            artView.Columns["createDate"].HeaderText = "Creation Date";
            artView.Columns["isFramed"].HeaderText = "Framed";
            artView.Columns["editionDetails"].HeaderText = "Edition Details";
            artView.Columns["saleDetails"].HeaderText = "Sale Details";
            artView.Columns["notes"].HeaderText = "Notes";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                saveEditButton.Text = "Edit";
                nameText.Enabled = false;
                addressText.Enabled = false;
                cityText.Enabled = false;
                stateText.Enabled = false;
                zipText.Enabled = false;
                countryText.Enabled = false;
                feeCheckBox.Enabled = false;
                startTime.Enabled = false;
                endTime.Enabled = false;
                juriedCheckBox.Enabled = false;
                deleteButton.Visible = false;
                isEditing = !isEditing;
            }
            else
            {
                var f = new CalendarScreen();
                this.Hide();
                f.Show();
            }            
        }

        private void SinglePieceButton_Click(object sender, EventArgs e)
        {
            Program.fromCollection = false;
            var f = new SinglePieceScreen(list[Program.rowId]);
            Program.rowId = exhibID;
            this.Hide();
            f.Show();
        }

        private void SaveEditButton_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                saveEditButton.Text = "Save";
                nameText.Enabled = true;
                addressText.Enabled = true;
                cityText.Enabled = true;
                stateText.Enabled = true;
                zipText.Enabled = true;
                countryText.Enabled = true;
                feeCheckBox.Enabled = true;
                startTime.Enabled = true;
                endTime.Enabled = true;
                juriedCheckBox.Enabled = true;
                if (juriedCheckBox.Checked)
                {
                    juriedText.Enabled = true;
                }
                if (feeCheckBox.Checked)
                {
                    feeText.Enabled = true;
                }
                if (!isNew)
                {
                    deleteButton.Visible = true;
                }
            }
            else if (IsValid())
            {
                saveEditButton.Text = "Edit";
                nameText.Enabled = false;
                addressText.Enabled = false;
                cityText.Enabled = false;
                stateText.Enabled = false;
                zipText.Enabled = false;
                countryText.Enabled = false;
                feeCheckBox.Enabled = false;
                feeText.Enabled = false;
                startTime.Enabled = false;
                endTime.Enabled = false;
                juriedCheckBox.Enabled = false;
                juriedText.Enabled = false;
                deleteButton.Visible = false;
                Exhibition exhib = new Exhibition
                {
                    exhibitionId = exhibID,
                    name = nameText.Text,
                    address = addressText.Text,
                    city = cityText.Text,
                    state = stateText.Text,
                    zipCode = zipText.Text,
                    country = countryText.Text,
                    startDate = startTime.Value,
                    endDate = endTime.Value,
                    juror = juriedText.Text
                };
                if (int.TryParse(feeText.Text,out int temp))
                {
                    exhib.applicationFee = temp;
                }
                else
                {
                    exhib.applicationFee = 0;
                }
                try
                {
                    DataSetClass.UpdateTable(isNew, exhib); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (isNew)
                {
                    var f = new CalendarScreen();
                    this.Hide();
                    f.Show();
                }
            }
            isEditing = !isEditing;
        }

        private void FeeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (feeCheckBox.Checked)
            {
                feeText.Enabled = true;
            }
            else
            {
                feeText.Enabled = false;
            }
        }

        private void JuriedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (juriedCheckBox.Checked)
            {
                juriedText.Enabled = true;
            }
            else 
            { 
                juriedText.Enabled = false; 
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure you wish to delete this record?", "Confirm Delete?", MessageBoxButtons.YesNo);
            if (message == DialogResult.Yes)
            {
                try
                {
                    DataSetClass.DeleteRecord(Program.simpleExhib, exhibID);
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message); 
                }
                var f = new CalendarScreen();
                this.Hide();
                f.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.rowId = e.RowIndex;
            singlePieceButton.Enabled = true;
        }

        private void artView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SinglePieceButton_Click(this, new EventArgs());
        }

        private void ExhibitionScreen_Load(object sender, EventArgs e)
        {
            if (Program.nightMode)
            {
                BackColor = Program.nightColor;
                ForeColor = System.Drawing.Color.White;
                deleteButton.ForeColor = Control.DefaultForeColor;
                backButton.ForeColor = Control.DefaultForeColor;
                saveEditButton.ForeColor = Control.DefaultForeColor;
                singlePieceButton.ForeColor = Control.DefaultForeColor;
                artView.ForeColor = Control.DefaultForeColor;
            }
            else
            {
                BackColor = Program.dayColor;
            }
            if (Program.fontSize == 0)
            {
                Font = new System.Drawing.Font("Segoe UI", 9);
            }
            else if (Program.fontSize == 1)
            {
                Font = new System.Drawing.Font("Segoe UI", 12);
            }
            else
            {
                Font = new System.Drawing.Font("Segoe UI", 14);
            }
        }

        private bool IsValid()
        {
            if (nameText.Text.Length > 45)
            {
                errorText.Text = "Name exceeds character limit of 45";
                return false;
            }
            if (addressText.Text.Length > 45)
            {
                errorText.Text = "Address exceeds character limit of 45";
                return false;
            }
            if (cityText.Text.Length > 45)
            {
                errorText.Text = "City exceeds character limit of 45";
                return false;
            }
            if (stateText.Text.Length > 45)
            {
                errorText.Text = "State exceeds character limit of 45";
                return false;
            }
            if (zipText.Text.Length > 10)
            {
                errorText.Text = "Zip Code exceeds character limit of 10";
                return false;
            }
            if (countryText.Text.Length > 45)
            {
                errorText.Text = "Country exceeds character limit of 45";
                return false;
            }
            if (juriedText.Text.Length > 45)
            {
                errorText.Text = "Juried exceeds character limit of 45";
                return false;
            }
            if (int.TryParse(feeText.Text, out _))
            {
                errorText.Text = "App Fee not in correct format, please enter a number";
                return false;
            }
            if (startTime.Value > endTime.Value)
            {
                errorText.Text = "Start Date must be before End Date";
                return false;
            }            
            return true;            
        }
    }
}
