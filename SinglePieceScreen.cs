using MySql.Data.MySqlClient;
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
        bool isEditing;
        readonly bool isNew;
        public int id;
        int pID;
        public bool newExhib;
        public int exhibID;
        List<Exhibition> list = new List<Exhibition>();
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
                if (!string.IsNullOrEmpty(artwork.saleDetails))
                {
                    soldCheckBox.Checked = true;
                    soldText.Text = artwork.saleDetails;
                    soldText.Enabled = false;
                }
                if (!string.IsNullOrEmpty(artwork.editionDetails))
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
                SaveEditButton_Click(this, EventArgs.Empty);
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
            exhibitionHistory.Columns["Name"].HeaderText = "Name";
            exhibitionHistory.Columns["State"].HeaderText = "State";
            exhibitionHistory.Columns["startDate"].HeaderText = "Start Date";
            exhibitionHistory.Columns["endDate"].HeaderText = "End Date";
            if (list.Count > 0)
            {
                deleteExhibButton.Visible = true;
            }
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
                            for (int i = 1; i < photos.Count; i++)
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
            else
            {
                samplePicture.Image = null;
            }
        }

        private bool IsValid()// check for empty fields
        {
            if (titleText.Text.Length > 45)
            {
                errorLabel.Text = "Title exceeds character limit of 45.";
                return false;
            }
            else if(titleText.Text.Length == 0)
            {
                errorLabel.Text = "Title is a required field. Please enter a title.";
                return false;
            }
            if (mediumText.Text.Length > 45)
            {
                errorLabel.Text = "Medium exceeds character limit of 45.";
                return false;
            }
            else if (mediumText.Text.Length == 0)
            {
                errorLabel.Text = "Medium is a required field. Please enter a medium.";
            }
            if (lengthText.Text.Length > 10)
            {
                errorLabel.Text = "Length exceeds character limit of 10.";
                return false;
            }
            else if (lengthText.Text.Length == 0)
            {
                errorLabel.Text = "Length is a required field. Please enter a length.";
            }
            if (widthText.Text.Length > 10)
            {
                errorLabel.Text = "Width exceeds character limit of 10.";
                return false;
            }
            else if (widthText.Text.Length == 0)
            {
                errorLabel.Text = "Width is a required field. Please enter a width.";
            }
            if (soldText.Text.Length > 100)
            {
                errorLabel.Text = "Sold exceeds character limit of 100.";
                return false;
            }
            if (editionText.Text.Length > 45)
            {
                errorLabel.Text = "Edition exceeds character limit of 45.";
                return false;
            }
            if (notesText.Text.Length > 200)
            {
                errorLabel.Text = "Notes exceed character limit of 200.";
                return false;
            }
            return true;
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
                            int picId = int.Parse(p.Name[3..]);
                            DataSetClass.DeleteRecord(Program.photos, picId);
                        }
                        //p.Image.Dispose();
                        RefreshPictures();
                        //isEditing = false;
                        BackButton_Click(this, EventArgs.Empty);
                        File.Delete(path);
                    }
                    catch(IOException ex)
                    {
                        //ignore
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                    
                    
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
            else if (IsValid())
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
                try
                {
                    DataSetClass.UpdateTable(isNew, art);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (isNew)
                {
                    var f = new CollectionScreen();
                    this.Hide();
                    f.Show();
                }
            }            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
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
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].exhibitionId == Program.rowId)
                        {
                            var f = new ExhibitionScreen(list[i]);
                            this.Hide();
                            f.Show();
                        }
                    }
                }
            }
        }

        private void SoldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            soldText.Enabled = soldCheckBox.Checked;
        }

        private void EditionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            editionText.Enabled = editionCheckBox.Checked;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure you wish to delete this record?","Confirm Delete?", MessageBoxButtons.YesNo);
            if (message != DialogResult.Yes) return;
            try
            {
                DataSetClass.DeleteRecord(Program.simpleArt, id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            var f = new CollectionScreen();
            this.Hide();
            f.Show();
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
            exhibitionHistory.Width = (exhibitionHistory.Columns[0].Width+ 1) * 4;
        }

        private void addPhotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFile = new OpenFileDialog
            {
                Filter = "JPeg Image|*.jpg|Tiff Image|*.tif",
                Title = "Save an Image File"
            };
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "Capstone\\Photos\\";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                filePath += saveFile.SafeFileName;
                try
                {
                    SavePhoto(filePath, saveFile.FileName);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deletePhotoButton_Click(object sender, EventArgs e)
        {
            deletePhotoText.Text = "Delete which photo?";
        }

        public void newExhibButton_Click(object sender, EventArgs e)
        {
            if (!newExhib)
            
            {
                List<int> ints = new List<int>();
                foreach (Exhibition ex in list)
                {
                    ints.Add(ex.exhibitionId);
                }
                var temp = DataSetClass.ConnectToData(Program.allExhib);
                list = temp.Cast<Exhibition>().ToList();
                int i = 0;
                while (i < list.Count)
                {
                    if (ints.Contains(list[i].exhibitionId))
                    {
                        list.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
                exhibitionHistory.DataSource = list;
                exhibID = 0;
                exhibText.Text = "All Exhibitions";
                newExhibButton.Text = "Confirm";
                deleteExhibButton.Visible = false;
                newExhib = !newExhib;
            }
            else
            {
                var inter = new Interface
                {
                    exhibitionId = exhibID,
                    artworkId = id
                };
                try
                {
                    DataSetClass.UpdateTable(true, inter);
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                var temp = DataSetClass.ConnectToData(Program.simpleExhib, id);
                list = temp.Cast<Exhibition>().ToList();
                exhibitionHistory.DataSource = list;
                exhibText.Text = "Exhibition History";
                newExhibButton.Text = "Add to Exhibition";
                deleteExhibButton.Visible = true;
                newExhib = !newExhib;
            }
        }

        private void exhibitionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            exhibID = list[e.RowIndex].exhibitionId;
        }

        private void deleteExhibButton_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure you wish to delete this record?", "Confirm Delete?", MessageBoxButtons.YesNo);
            if (message == DialogResult.Yes)
            {
                try
                {
                    DataSetClass.DeleteRecord(Program.inter, exhibID);

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            var temp = DataSetClass.ConnectToData(Program.simpleExhib, id);
            list = temp.Cast<Exhibition>().ToList();
            exhibitionHistory.DataSource = list;
        }

        public void SavePhoto(string path, string name)
        {
            if (!File.Exists(path))
            {
                Image image = Image.FromFile(name);
                image.Save(path);
            }
                    
            Photos pic = new Photos
            {
                artworkID = id,
                url = path
            };
            DataSetClass.UpdateTable(!isNew, pic);
            RefreshPictures();
        }
    }
}
