using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Capstone_Project
{
    public partial class SinglePieceScreen : Form
    {
        public SinglePieceScreen(Artwork artwork)
        {
            InitializeComponent();//For Future:: make screen about 50% bigger on each side, able to adapt to window size if able
            var photos = DataSetClass.ConnectToData("Photos", Program.rowID + 1);
            if (photos.Count > 0)
            {
                var specificPhotos = photos.Cast<Photos>().ToList();
                var image = new Bitmap(specificPhotos[0].url);
                samplePicture.Image = image;
                if (specificPhotos.Count > 1)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is SplitContainer container)
                        {
                            for(int i = 1; i < photos.Count; i++)//picture boxes = number of photos for this art - 1, 37 units apart
                            {
                                var pic = new Bitmap(specificPhotos[i].url);
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Image = pic;
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                pictureBox.Size = new Size(100, 100);
                                pictureBox.Location = new Point((39 * i) - 19, 39);
                                container.Panel2.Controls.Add(pictureBox);
                            }
                        }
                    }
                }
            }
            
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
                    soldText.Text = artwork.saleDetails;
                }
                if (artwork.editionDetails != "" && artwork.editionDetails != null)
                {
                    editionCheckBox.Checked = true;
                    editionText.Text = artwork.editionDetails;
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
            var list = DataSetClass.ConnectToData("Simple Exhibition", 1);
            exhibitionHistory.DataSource = list.Cast<Exhibition>().ToList();
            exhibitionHistory.Columns.Remove("Exhibitionid");
            exhibitionHistory.Columns.Remove("Address");
            exhibitionHistory.Columns.Remove("City");
            exhibitionHistory.Columns.Remove("ZipCode");
            exhibitionHistory.Columns.Remove("Country");
            exhibitionHistory.Columns.Remove("ApplicationFee");
            exhibitionHistory.Columns.Remove("Juror");
        }
    }
}
