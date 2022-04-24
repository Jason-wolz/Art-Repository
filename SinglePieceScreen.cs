using System;
using System.Drawing;
using System.Windows.Forms;


namespace Capstone_Project
{
    public partial class SinglePieceScreen : Form
    {
        public SinglePieceScreen(Artwork artwork)
        {
            InitializeComponent();
            if (artwork != null)
            {
                titleText.Text = artwork.title;
                mediumText.Text = artwork.medium;
                dimensionsText.Text = artwork.length + " x " + artwork.width;
                dateText.Text = artwork.date.ToString();
                notesText.Text = artwork.notes;
                framedCheckBox.Checked = artwork.isFramed;
                if (artwork.saleDetails != "" && artwork.saleDetails != null)
                {
                    soldCheckBox.Checked = true;
                    soldCheckBox.Text = artwork.saleDetails;
                }
                if (artwork.editionDetails != "" && artwork.editionDetails != null)
                {
                    editionCheckBox.Checked = true;
                    editionCheckBox.Text = artwork.editionDetails;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            titleText.Enabled = false;
            mediumText.Enabled = false;
            dimensionsText.Enabled = false;
            dateText.Enabled = false;
            soldCheckBox.Enabled = false;
            soldText.Enabled = false;
            editionCheckBox.Enabled = false;
            notesText.Enabled = false;
            framedCheckBox.Enabled = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            titleText.Enabled = true;
            mediumText.Enabled = true;
            dimensionsText.Enabled = true;
            dateText.Enabled = true;
            soldCheckBox.Enabled = true;
            editionCheckBox.Enabled = true;
            notesText.Enabled = true;
            framedCheckBox.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (Program.fromCollection)
            {
                var f = new CollectionScreen();
                this.Hide();
                f.Show();
            }
            else
            {
                var f = new ExhibitionScreen();
                this.Hide();
                f.Show();
            }
        }

        private void SoldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (soldCheckBox.Checked)
            {
                soldText.Enabled = true;
            }
            else
            {
                soldText.Enabled = false;
            }
        }

        private void EditionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (editionCheckBox.Checked)
            {
                editionText.Enabled = true;
            }
            else
            {
                editionText.Enabled = false;
            }
        }

        private void SinglePieceScreen_Load(object sender, EventArgs e)
        {//populate form w/ data
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            exhibitionHistory.DataSource = DataSetClass.ConnectToData("Simple Exhibition", 1);
            //exhibitionHistory.Columns.Remove("ExhibitionID");
            //exhibitionHistory.Columns.Remove("Address");
            //exhibitionHistory.Columns.Remove("City");
            //exhibitionHistory.Columns.Remove("ZipCode");
            //exhibitionHistory.Columns.Remove("Country");
            //exhibitionHistory.Columns.Remove("ApplicationFee");
            //exhibitionHistory.Columns.Remove("Juror");
            //use this format to add photos.To-Do:: get database working to add just as many pictureBoxes as needed
            Bitmap image = new Bitmap("C:\\Users\\jason\\source\\repos\\Jason-wolz\\Capstone-Project\\Photos\\03-15-21_10-02-54 PM.png");
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
