using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class SearchForm : Form
    {
        bool isDraging = false;
        Point startPoint = new Point(0, 0);
        public DatabaseConnector connector;

        public DataGridView dgv;
        DataTable dt = new DataTable();
        public bool isMinimise;

        public SearchForm()
        {
            InitializeComponent();
            dgv = dataGridView1;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            label12.Text = this.Text;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDraging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraging)
            {
                Point p = PointToScreen(e.Location);
                Point delta = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                Location = delta;
                if ((delta.X != 0 || delta.Y != 0) && WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDraging = false;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_SIZEBOX = 0x40000;

                var cp = base.CreateParams;
                cp.Style |= WS_SIZEBOX;

                return cp;
            }
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetColoredCells(false);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
            SetColoredCells(false);
        }

        private void Search()
        {
            Dictionary<string, string> searchData = new Dictionary<string, string>() {
                { "`FIO student`", FIOComboBox.Text},
                {"`Birthday`", yearText.Text + "." + monthText.Text + "." + dayText.Text },
                {"`Class`", classText.Text },
                {"`Courses`", coursesText.Text },
                {"`FIO parent`", FIO2Text.Text },
                {"`Telephone`", telText.Text },
                {"`Add. telephone`", dopTelText.Text },
                {"`Months`", mouText.Text },
                {"`Time`", timeText.Text },
                {"`Comments`", commentsText.Text }
            };
            string req = "";
            foreach (var item in searchData)
            {
                if (item.Key == "`Birthday`")
                {
                    if (yearText.Text != "") req += $" AND ({item.Key} LIKE '{yearText.Text}.%')";
                    if (monthText.Text != "") req += $" AND ({item.Key} LIKE '%.{monthText.Text}.%')";
                    if (dayText.Text != "") req += $" AND ({item.Key} LIKE '%.{dayText.Text}')";
                    continue;
                }
                if (item.Value != "" && item.Value != "..")
                    req += $" AND ({item.Key} LIKE '%{item.Value}%')";
            }
            Console.WriteLine(req);
            dataGridView1.DataSource = connector.SqlRequest("SELECT * FROM Clients WHERE `ID`!=0" + req);
            searchCountLabel.Text = "Найдено: " + (dataGridView1.RowCount - 1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            connector.UpdateDatabaseFromDataGridView((DataTable)dataGridView1.DataSource);
            Search();
            Debug.Print("Update");
            SetColoredCells(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintAllDB.DeleteRow(connector, textBox1);
            Search();
            SetColoredCells(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search();
            SetColoredCells(false);
        }

        private void minMaxButton_Click(object sender, EventArgs e)
        {
            isMinimise = !isMinimise;

            if (isMinimise)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            }
            else
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            searchCountLabel.Text = string.Empty;
            this.Hide();

        }

        private void white_Click_1(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.Color currentColor = Colors.currentColor;
            Colors.currentColor = Colors.Color.WHITE;
            SetColor(Color.White, currentColor);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void green_Click_1(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.GREEN;
            SetColor(Color.Green);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void red_Click_1(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.RED;
            SetColor(Color.Red);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void orange_Click_1(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.ORANGE;
            SetColor(Color.Orange);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void blue_Click_1(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.BLUE;
            SetColor(Color.Blue);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void pink_Click_1(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.PINK;
            SetColor(Color.Pink);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void lightblue_Click_1(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.LIGHTBLUE;
            SetColor(Color.LightBlue);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                connector.UpdateDatabaseFromDataGridView((DataTable)dataGridView1.DataSource);
        }

        private void SetColoredCells(bool isChanging = true)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    DataTable currentRowsInColorsTable = connector.SqlRequest($"SELECT * FROM colors WHERE userID = {row.Cells[0].Value} AND columnID = {cell.ColumnIndex};");
                    if (currentRowsInColorsTable != null && currentRowsInColorsTable.Rows.Count > 0)
                        cell.Style.BackColor = Color.FromName(currentRowsInColorsTable.Rows[0][3].ToString());
                }

            }
        }

        void SetColor(Color color, Colors.Color previousColor = Colors.Color.NONE)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                cell.Style.BackColor = color;
                //      string coloredCell = ReadFile.FindByAddress(address);
                string currentID = dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString();
                if (color == Color.White)
                {
                    if (connector.SqlRequest($"SELECT * FROM colors WHERE userID = {currentID} AND columnID = {cell.ColumnIndex};").Rows.Count > 0)
                    {
                        connector.SqlRequest($"DELETE FROM colors WHERE userID = {currentID} AND columnID = {cell.ColumnIndex};");
                    }

                }
                else
                {
                    if (connector.SqlRequest($"SELECT * FROM colors WHERE userID = {currentID} AND columnID = {cell.ColumnIndex};").Rows.Count == 0)
                    {
                        string req = $"INSERT INTO colors (`ID`,`userID`,`columnID`,`color`) VALUES ({Convert.ToInt32(connector.SqlRequest("SELECT COUNT(ID) FROM colors;").Rows[0][0]) + 1}, {currentID}, {cell.ColumnIndex}, '{color.Name}');";
                        connector.SqlRequest(req);
                        Console.WriteLine(req);
                    }
                    else
                    {
                        connector.SqlRequest($"UPDATE colors SET color = '{color.Name}' WHERE userID = {currentID} AND columnID = {cell.ColumnIndex};");
                    }
                }
            }
        }

    }
}
