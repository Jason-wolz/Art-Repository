using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class CollectionScreen : Form
    {
        readonly List<Table> list = new List<Table>();
        public CollectionScreen()//to-do:: make a way to search for art by name, year, dimensions, or medium
        {
            InitializeComponent();
            list = DataSetClass.ConnectToData(Program.allArt);
            artDataGrid.DataSource = list.Cast<Artwork>().ToList();
            artDataGrid.Columns["artworkID"].Visible = false;
            Program.rowID = 0;
            SetPhoto(Program.rowID);
        }

        private void SetPhoto(int id)
        {
            var photos = DataSetClass.ConnectToData(Program.photos, id + 1);
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
            var f = new SinglePieceScreen((Artwork)list[Program.rowID]);
            this.Hide();
            f.Show();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Program.fromCollection = true;
            var f = new SinglePieceScreen(new Artwork());
            this.Hide();
            f.Show();
        }

        private void artDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.rowID = e.RowIndex;
            SetPhoto(Program.rowID);
        }

        private void artDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            singlePieceButton_Click(this, new EventArgs());
        }

        private void CollectionScreen_Load(object sender, EventArgs e)
        {
            if (Program.nightMode)
            {
                BackColor = Program.nightColor;
                ForeColor = Color.White;
                newButton.ForeColor = Control.DefaultForeColor;
                backButton.ForeColor = Control.DefaultForeColor;
                singlePieceButton.ForeColor = Control.DefaultForeColor;
                artDataGrid.ForeColor = Control.DefaultForeColor;
            }
            else
            {
                BackColor = Program.dayColor;
            }
            if (Program.fontSize == 0)
            {
                Font = new Font("Segoe UI", 9);
            }
            else if (Program.fontSize == 1)
            {
                Font = new Font("Segoe UI", 12);
            }
            else
            {
                Font = new Font("Segoe UI", 14);
            }
        }
    }
}
