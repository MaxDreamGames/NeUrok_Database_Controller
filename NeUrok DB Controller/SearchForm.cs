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
        public DatabaseConnector connector;

        public DataGridView dgv;
        DataTable dt = new DataTable();
        public bool isMinimise;

        public SearchForm()
        {
            InitializeComponent();
            dgv = dataGridView1;
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetColoredCells(false);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dataGridView1.DataSource = null;

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
            this.Hide();
            dataGridView1.DataSource = null;

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

        private void SetColoredCells(bool isChanging = true)
        {
            string[] lines = ReadFile.Read().Split(';');
            List<string> newStr = new List<string>();
            if (ReadFile.Read() == "") return;
            foreach (string line in lines)
            {
                // Debug.WriteLine(line);
                bool isDeleted = false;
                string[] keyValue = line.Split(',');
                string[] ids = keyValue[0].Split(':');
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == ids[0].ToString())
                    {
                        dataGridView1.Rows[i].Cells[Convert.ToInt32(ids[1])].Style.BackColor = Colors.colorMatching[keyValue[1]];
                        newStr.Add(ids[0] + ":" + ids[1] + "," + keyValue[1]);
                        break;
                    }
                    else
                    {
                        isDeleted = true;
                    }
                }
                if (isDeleted)
                {

                }
            }
            if (isChanging)
            {
                string ns = "";
                foreach (var item in newStr)
                    ns += item + ";";
                ReadFile.ReWrite(ns);
            }
        }

        void SetColor(Color color, Colors.Color previousColor = Colors.Color.NONE)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                cell.Style.BackColor = color;
                string address = dataGridView1[0, cell.RowIndex].Value.ToString() + ":" + cell.ColumnIndex;
                string coloredCell = ReadFile.FindByAddress(address);
                if (color == Color.White && coloredCell != null)
                {
                    Console.WriteLine(coloredCell);
                    ReadFile.RemoveLineFromFile(address + "," + coloredCell.Split(',')[1] + ";");
                }
                else if (color != Color.White)
                    ReadFile.Write(address + "," + Colors.currentColor + ";");
            }
        }


    }
}
