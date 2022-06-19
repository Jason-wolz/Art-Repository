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
        public CollectionScreen()
        {
            InitializeComponent();
            list = DataSetClass.ConnectToData(Program.allArt);
            List<Artwork> arts = list.Cast<Artwork>().ToList();
            artDataGrid.DataSource = arts;
            artDataGrid.Columns["artworkID"].Visible = false;
            artDataGrid.Columns["Title"].HeaderText = "Title";
            artDataGrid.Columns["medium"].HeaderText = "Medium";
            artDataGrid.Columns["Length"].HeaderText = "Length";
            artDataGrid.Columns["Width"].HeaderText = "Width";
            artDataGrid.Columns["createDate"].HeaderText = "Creation Date";
            artDataGrid.Columns["isFramed"].HeaderText = "Framed";
            artDataGrid.Columns["editionDetails"].HeaderText = "Edition Details";
            artDataGrid.Columns["saleDetails"].HeaderText = "Sale Details";
            artDataGrid.Columns["notes"].HeaderText = "Notes";
            if (arts.Count > 0)
            {
                Program.rowId = arts[0].artworkID;
                SetPhoto(Program.rowId);
            }
            else
            {
                singlePieceButton.Enabled = false;
            }
        }

        private void SetPhoto(int id)
        {
            var photos = DataSetClass.ConnectToData(Program.photos, id);
            if (photos.Count > 0)
            {
                errorText.Text = "";
                var specificPhotos = photos.Cast<Photos>().ToList();    
                var image = new Bitmap(specificPhotos[0].url);
                samplePicture.Image = image;
            }
            else
            {
                samplePicture.Image = null;
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
            var temp = list.Cast<Artwork>().ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].artworkID == Program.rowId)
                {
                    var f = new SinglePieceScreen(temp[i]);
                    this.Hide();
                    f.Show();
                }
            }
            
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
            var f = (DataGridView)sender;            
            Program.rowId = int.Parse(f.Rows[e.RowIndex].Cells[0].Value.ToString());
            SetPhoto(Program.rowId);
        }

        private void artDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            singlePieceButton_Click(this, EventArgs.Empty);
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Artwork> searchList = new List<Artwork>();
            if (DateTime.TryParse(searchText.Text + "-01-01", out DateTime date))
            {
                searchList.AddRange(DataSetClass.Search(date));

            }
            searchList.AddRange(DataSetClass.Search(Program.medium, searchText.Text));
            searchList.AddRange(DataSetClass.Search(Program.name, searchText.Text));
            List<int> dis = new List<int>();
            List<int> del = new List<int>();
            for (int i = 0; i < searchList.Count(); i++)
            {
                if (!dis.Contains(searchList[i].artworkID))
                {
                    dis.Add(searchList[i].artworkID);
                }
                else
                {
                    del.Add(i);
                }
            }
            foreach (int i in del)
            {
                searchList.RemoveAt(i);
            }
            artDataGrid.DataSource = searchList;
        }
    }
}
