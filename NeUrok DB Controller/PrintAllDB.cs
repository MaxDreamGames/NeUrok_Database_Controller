using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class PrintAllDB : Form
    {
        bool isDraging = false;
        Point startPoint = new Point(0, 0);
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
            label3.Text = this.Text;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.ContextMenuStrip = contextMenuStrip2;
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
        private void форматироваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connector.Format((DataTable)dataGridView1.DataSource);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                connector.UpdateDatabaseFromDataGridView((DataTable)dataGridView1.DataSource);
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
            DataTable colorsTable = connector.SqlRequest($"SELECT * FROM colors;");
            foreach (DataRow row in colorsTable.Rows)
            {
                dataGridView1[Convert.ToInt32(row[2]), Convert.ToInt32(row[1]) - 1].Style.BackColor = Color.FromName(row[3].ToString());
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