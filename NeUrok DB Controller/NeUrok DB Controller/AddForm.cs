using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class AddForm : Form
    {
        public DatabaseConnector connector;
        public static int id = 1;
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            connector.SqlRequest("INSERT INTO [dbo].[Clients]([ID], [ФИО ученика],[Дата рождения],[Класс],[Направления],[ФИО родителя],[Телефон родителя],[Дополнительный телефон],[Месяцы],[Время],[Комментарии])VALUES('"+
                IdText.Text + "', '" + FIOComboBox.Text + "', '" + yearText.Text + "." + monthText.Text + "." + dayText.Text + "', " + classText.Text + ", '" + coursesText.Text + "', '" + FIO2Text.Text + "', '" + telText.Text + "', '" + dopTelText.Text + "', '" + mouText.Text + "', '" + timeText.Text + "', '" + commentsText.Text + "')");
            dataGridView1.DataSource = connector.SqlRequest("select * from Clients where [ФИО ученика]='" + FIOComboBox.Text + "'");

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clear();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
