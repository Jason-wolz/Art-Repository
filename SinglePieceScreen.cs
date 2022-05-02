using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Capstone_Project
{
    public partial class SinglePieceScreen : Form
    {
        bool isEditing = false;
        readonly bool isNew;
        readonly int id;
        int pID;
        List<Exhibition> list = new List<Exhibition>();//add way to add/delete photos
        public SinglePieceScreen(Artwork artwork)
        {
            InitializeComponent();//For Future:: make screen about 50% bigger on each side, able to adapt to window size if able
            id = artwork.artworkID;
            if (id > 0)
            {                
                titleText.Text = artwork.title;
                mediumText.Text = artwork.medium;
                lengthText.Text = artwork.length;
                widthText.Text = artwork.width;
                dateText.Value = artwork.createDate;
                notesText.Text = artwork.notes;
                framedCheckBox.Checked = artwork.isFramed;
                if (artwork.saleDetails != "" && artwork.saleDetails != null)
                {
                    soldCheckBox.Checked = true;
                    soldText.Text = artwork.saleDetails;
                    soldText.Enabled = false;
                }
                if (artwork.editionDetails != "" && artwork.editionDetails != null)
                {
                    editionCheckBox.Checked = true;
                    editionText.Text = artwork.editionDetails;
                    editionText.Enabled = false;
                }
                isNew = false;
                RefreshPictures();
            }
            else
            {
                isNew = true;
                SaveEditButton_Click(this, new EventArgs());
            }            
            var temp = DataSetClass.ConnectToData(Program.simpleExhib, artwork.artworkID);
            list = temp.Cast<Exhibition>().ToList();
            exhibitionHistory.DataSource = list;
            exhibitionHistory.Columns["Exhibitionid"].Visible = false;
            exhibitionHistory.Columns["Address"].Visible = false;
            exhibitionHistory.Columns["City"].Visible = false;
            exhibitionHistory.Columns["ZipCode"].Visible = false;
            exhibitionHistory.Columns["Country"].Visible = false;
            exhibitionHistory.Columns["ApplicationFee"].Visible = false;
            exhibitionHistory.Columns["Juror"].Visible = false;
        }
        private void RefreshPictures()
        {
            var photos = DataSetClass.ConnectToData(Program.photos, id);
            if (photos.Count > 0)
            {
                var specificPhotos = photos.Cast<Photos>().ToList();
                var image = new Bitmap(specificPhotos[0].url);
                samplePicture.Image = image;
                samplePicture.ImageLocation = specificPhotos[0].url;
                pID = specificPhotos[0].photoID;
                if (specificPhotos.Count > 1)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is SplitContainer container)
                        {
                            foreach(Control co in container.Panel2.Controls)
                            {
                                container.Panel2.Controls.Remove(co);
                            }                        
                            for (int i = 1; i < photos.Count; i++)//picture boxes = number of photos for this art - 1
                            {
                                var pic = new Bitmap(specificPhotos[i].url);
                                PictureBox pictureBox = new PictureBox
                                {
                                    Name = "Box" + specificPhotos[i].photoID.ToString(),
                                    Image = pic,
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Size = new Size(100, 100),
                                    Location = new Point((120 * i) - 100, 39),
                                    ImageLocation = specificPhotos[i].url
                                };
                                pictureBox.Click += PictureBox_Click;
                                container.Panel2.Controls.Add(pictureBox);
                            }
                        }
                    }
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (deletePhotoText.Text == "Delete which photo?")
            {
                DialogResult message = MessageBox.Show("Are you sure you wish to delete this photo?", "Confirm Delete?", MessageBoxButtons.YesNo);
                if (message == DialogResult.Yes)
                {
                    try
                    {
                        PictureBox p = (PictureBox)sender;
                        string path;
                        if (p.Name == samplePicture.Name)
                        {
                            path = samplePicture.ImageLocation;
                            DataSetClass.DeleteRecord(Program.photos, pID);
                        }
                        else
                        {
                            path = "";
                            int picID = int.Parse(p.Name[3..]);
                            DataSetClass.DeleteRecord(Program.photos, picID);
                        }
                        //isEditing = false;
                        //BackButton_Click(this, new EventArgs());
                        RefreshPictures();
                        File.Delete(path);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //
                }
            }            
        }

        private void SaveEditButton_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                saveEditButton.Text = "Save";
                titleText.Enabled = true;
                mediumText.Enabled = true;
                lengthText.Enabled = true;
                widthText.Enabled = true;
                dateText.Enabled = true;
                soldCheckBox.Enabled = true;
                editionCheckBox.Enabled = true;
                notesText.Enabled = true;
                framedCheckBox.Enabled = true;
                isEditing = !isEditing;
                if (soldCheckBox.Checked)
                {
                    soldText.Enabled = true;
                }
                if (editionCheckBox.Checked)
                {
                    editionText.Enabled = true;
                }
                if (!isNew)
                {
                    deleteButton.Visible = true;
                    addPhotoButton.Visible = true;
                    deletePhotoButton.Visible = true;
                }
            }
            else
            {
                saveEditButton.Text = "Edit";
                titleText.Enabled = false;
                mediumText.Enabled = false;
                lengthText.Enabled = false;
                widthText.Enabled = false;
                dateText.Enabled = false;
                soldCheckBox.Enabled = false;
                soldText.Enabled = false;
                editionCheckBox.Enabled = false;
                editionText.Enabled = false;
                notesText.Enabled = false;
                framedCheckBox.Enabled = false;
                deleteButton.Visible = false;
                addPhotoButton.Visible = false;
                deletePhotoButton.Visible = false;
                deletePhotoText.Text = "";
                isEditing = !isEditing;
                Artwork art = new Artwork
                {
                    artworkID = id,
                    title = titleText.Text,
                    medium = mediumText.Text,
                    length = lengthText.Text,
                    width = widthText.Text,
                    createDate = dateText.Value,
                    saleDetails = soldText.Text,
                    editionDetails = editionText.Text,
                    isFramed = framedCheckBox.Checked,
                    notes = notesText.Text
                };
                DataSetClass.UpdateTable(isNew, art);
                if (isNew)
                {
                    var f = new CollectionScreen();
                    this.Hide();
                    f.Show();
                }
            }
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {//to-do:: maybe reset values?
            if (isEditing)
            {
                saveEditButton.Text = "Edit";
                titleText.Enabled = false;
                mediumText.Enabled = false;
                lengthText.Enabled = false;
                widthText.Enabled = false;
                dateText.Enabled = false;
                soldCheckBox.Enabled = false;
                soldText.Enabled = false;
                editionCheckBox.Enabled = false;
                editionText.Enabled = false;
                notesText.Enabled = false;
                framedCheckBox.Enabled = false;
                deleteButton.Visible = false;
                addPhotoButton.Visible = false;
                deletePhotoButton.Visible = false;
                deletePhotoText.Text = "";
                isEditing = !isEditing;
            }
            else
            {
                if (Program.fromCollection)
                {
                    var f = new CollectionScreen();
                    this.Hide();
                    f.Show();
                }
                else
                {
                    var temp = DataSetClass.ConnectToData(Program.allExhib);
                    list = temp.Cast<Exhibition>().ToList();
                    var f = new ExhibitionScreen(list[Program.rowID]);
                    this.Hide();
                    f.Show();
                }
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure you wish to delete this record?","Confirm Delete?", MessageBoxButtons.YesNo);
            if (message == DialogResult.Yes)
            {
                DataSetClass.DeleteRecord(Program.simpleArt, id);
                var f = new CollectionScreen();
                this.Hide();
                f.Show();
            }
        }

        private void SinglePieceScreen_Load(object sender, EventArgs e)
        {
            if (Program.nightMode)
            {
                BackColor = Program.nightColor;
                ForeColor = Color.White;
                backButton.ForeColor = Control.DefaultForeColor;
                saveEditButton.ForeColor = Control.DefaultForeColor;
                deleteButton.ForeColor = Control.DefaultForeColor;
                exhibitionHistory.ForeColor = Control.DefaultForeColor;
            }
            else
            {
                BackColor = Program.dayColor;
            }
            if (Program.fontSize == 0)
            {
                Font = new Font("Segoe UI", 9);
                backButton.Font = Font;
            }
            else if (Program.fontSize == 1)
            {
                Font = new Font("Segoe UI", 12);
                backButton.Font = Font;
            }
            else
            {
                Font = new Font("Segoe UI", 14);
                backButton.Font = Font;
            }
        }

        private void addPhotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFile = new OpenFileDialog();
            saveFile.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFile.Title = "Save an Image File";
            string filePath = "C:\\Users\\jason\\source\\repos\\Jason-wolz\\Capstone-Project\\Photos\\";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                filePath += saveFile.SafeFileName;
                try
                {
                    Image image = Image.FromFile(saveFile.FileName);
                    image.Save(filePath);
                    Photos pic = new Photos
                    {
                        artworkID = id,
                        url = filePath
                    };
                    DataSetClass.UpdateTable(!isNew, pic);
                    RefreshPictures();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deletePhotoButton_Click(object sender, EventArgs e)
        {
            deletePhotoText.Text = "Delete which photo?";
        }
    }
}
