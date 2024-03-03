using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class PrintAllDB : Form
    {
        public DatabaseConnector connector;
        public DataGridView dgv;
        DataTable dt = new DataTable();
        public bool isMinimise;
        public Menu menu;


        public PrintAllDB()
        {
            InitializeComponent();
            dgv = dataGridView1;
        }



        private void PrintAllDB_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void ShowThis()
        {
            Colors.SetColors();
            SetColoredCells();
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetColoredCells();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dataGridView1.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connector.UpdateDatabaseFromDataGridView((DataTable)dataGridView1.DataSource);
            dataGridView1.DataSource = connector.SqlRequest("SELECT * FROM Clients");
            SetColoredCells();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = connector.SqlRequest("SELECT * FROM Clients");
            SetColoredCells();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DeleteRow(connector, textBox1);
            dataGridView1.DataSource = connector.SqlRequest("SELECT * FROM Clients");
            SetColoredCells();
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

        private void green_Click(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.GREEN;
            SetColor(Color.Green);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void red_Click(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.RED;
            SetColor(Color.Red);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void orange_Click(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.ORANGE;
            SetColor(Color.Orange);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.BLUE;
            SetColor(Color.Blue);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void pink_Click(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.PINK;
            SetColor(Color.Pink);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void lightblue_Click(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.currentColor = Colors.Color.LIGHTBLUE;
            SetColor(Color.LightBlue);
            Colors.currentColor = Colors.Color.NONE;
        }
        private void white_Click(object sender, EventArgs e)
        {
            if (Colors.currentColor != Colors.Color.NONE) return;
            Colors.Color currentColor = Colors.currentColor;
            Colors.currentColor = Colors.Color.WHITE;
            SetColor(Color.White, currentColor);
            Colors.currentColor = Colors.Color.NONE;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static void DeleteRow(DatabaseConnector connector, TextBox textBox)
        {
            connector.SqlRequest("DELETE FROM Clients WHERE `ID`='" + textBox.Text + "'");
            AddForm.id--;
            for (int i = Convert.ToInt32(textBox.Text); i <= connector.SqlRequest("SELECT * FROM Clients").Rows.Count; i++)
                connector.SqlRequest("UPDATE Clients SET `ID`='" + i + "' WHERE `ID`='" + (i + 1) + "'");

        }

        private void SetColoredCells()
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
                        isDeleted = true;
                }
            }
            string ns = "";
            foreach (var item in newStr)
                ns += item + ";";
            ReadFile.ReWrite(ns);
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