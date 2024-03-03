using System;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class AddForm : Form
    {
        public DatabaseConnector connector;
        public static int id = 1;
        public bool isMinimise;


        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            IdText.Text = (connector.SqlRequest("SELECT * FROM Clients").Rows.Count + 1).ToString();
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
