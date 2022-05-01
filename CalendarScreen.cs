using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class CalendarScreen : Form
    {
        readonly List<Exhibition> list = new List<Exhibition>();
        public CalendarScreen()
        {
            InitializeComponent();
            var temp = DataSetClass.ConnectToData(Program.allExhib);
            list = temp.Cast<Exhibition>().ToList();
            exhibitionView.DataSource = list;
            exhibitionView.Columns["exhibitionId"].Visible = false;
            GetRange(list);
            Program.rowID = 0;
        }

        private void GetRange(List<Exhibition> exhibitions)
        {
            exhibitionCalendar.RemoveAllBoldedDates();
            foreach (Exhibition e in exhibitions)
            {
                for (DateTime i = e.startDate; i <= e.endDate; i = i.AddDays(1))
                {
                    exhibitionCalendar.AddBoldedDate(i);
                }
            }
            exhibitionCalendar.UpdateBoldedDates();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var f = new MainScreen();
            this.Hide();
            f.Show();
        }

        private void exhibitionButton_Click(object sender, EventArgs e)
        {
            var f = new ExhibitionScreen(list[Program.rowID]);
            this.Hide();
            f.Show();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var f = new ExhibitionScreen(new Exhibition());
            this.Hide();
            f.Show();
        }

        private void exhibitionView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.rowID = e.RowIndex;
            List<Exhibition> temp = new List<Exhibition>
            {
                list[Program.rowID]
            };
            GetRange(temp);
        }

        private void exhibitionView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            exhibitionButton_Click(this, new EventArgs());
        }

        private void CalendarScreen_Load(object sender, EventArgs e)
        {
            if (Program.nightMode)
            {
                BackColor = Program.nightColor;
                ForeColor = Color.White;
                newButton.ForeColor = Control.DefaultForeColor;
                exhibitionButton.ForeColor = Control.DefaultForeColor;
                backButton.ForeColor = Control.DefaultForeColor;
                exhibitionView.ForeColor = Control.DefaultForeColor;
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
