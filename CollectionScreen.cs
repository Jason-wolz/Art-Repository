using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class CollectionScreen : Form//have datagridview for list of art, and single picturebox for photo
    {
        List<Table> list = new List<Table>();
        public CollectionScreen()
        {//To-Do:: fill out form with info from this list
            InitializeComponent();
            list = DataSetClass.ConnectToData("All Artwork");
            artDataGrid.DataSource = list.Cast<Artwork>().ToList();
            artDataGrid.Columns["artworkID"].Visible = false;
            Program.rowID = 0;
            SetPhoto(Program.rowID);
        }

        private void SetPhoto(int id)
        {
            var photos = DataSetClass.ConnectToData("Photos", id + 1);
            if (photos.Count > 0)
            {
                errorText.Text = "";
                var specificPhotos = photos.Cast<Photos>().ToList();
                var image = new Bitmap(specificPhotos[0].url);
                samplePicture.Image = image;
            }
            else
            {
                errorText.Text = "The system has no photos of this piece.";
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var f = new MainScreen();
            this.Hide();
            f.Show();
        }

        private void singlePieceButton_Click(object sender, EventArgs e)
        {
            Program.fromCollection = true;
            var f = new SinglePieceScreen((Artwork)list[Program.rowID]);//To-Do:: pull artwork from list to send
            this.Hide();
            f.Show();
        }

        private void artDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.rowID = e.RowIndex;
            SetPhoto(Program.rowID);
        }
    }
}
