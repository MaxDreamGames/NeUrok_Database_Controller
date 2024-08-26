using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class AddForm : Form
    {
        bool isDraging = false;
        Point startPoint = new Point(0, 0);
        public DatabaseConnector connector;
        public static int id = 1;
        public bool isMinimise;


        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            label12.Text = this.Text;
            IdText.Text = (connector.SqlRequest("SELECT * FROM Clients").Rows.Count + 1).ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (IdText.Text == "" || FIOComboBox.Text == "" || FIO2Text.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.connector.SqlRequest("INSERT INTO Clients(`ID`, `FIO student`,`Birthday`,`Class`,`Courses`,`FIO parent`,`Telephone`,`Add. telephone`,`Months`,`Time`,`Comments`)VALUES('" +
                IdText.Text + "', '" + FIOComboBox.Text + "', '" + yearText.Text + "." + monthText.Text + "." + dayText.Text + "', " + classText.Text + ", '" + coursesText.Text + "', '" + FIO2Text.Text + "', '" + telText.Text + "', '" + dopTelText.Text + "', '" + mouText.Text + "', '" + timeText.Text + "', '" + commentsText.Text + "')");
            dataGridView1.DataSource = this.connector.SqlRequest("select * from Clients where `FIO student`='" + FIOComboBox.Text + "'");

            IdText.Text = (connector.SqlRequest("SELECT * FROM Clients").Rows.Count + 1).ToString();
            //id++;
        }

        private void Clear()
        {
            dataGridView1.DataSource = null;
            FIOComboBox.Text = null;
            dayText.Text = null;
            monthText.Text = null;
            yearText.Text = null;
            classText.Text = null;

            coursesText.Text = null;
            telText.Text = null;
            dopTelText.Text = null;
            mouText.Text = null;
            FIO2Text.Text = null;
            timeText.Text = null;
            commentsText.Text = null;
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

            Clear();
            Hide();
        }
    }
}
