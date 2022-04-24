using System;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class CollectionScreen : Form//have datagridview for list of art, and single picturebox for photo
    {
        public CollectionScreen()
        {//To-Do:: fill out form with info from this list
            InitializeComponent();
            artDataGrid.DataSource = DataSetClass.ConnectToData("All Artwork");
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
            var f = new SinglePieceScreen(new Artwork());//To-Do:: pull artwork from list to send
            this.Hide();
            f.Show();
        }

        private void artDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.rowID = e.RowIndex;

        }

        private void CollectionScreen_Load(object sender, EventArgs e)
        {
        }
    }
}
