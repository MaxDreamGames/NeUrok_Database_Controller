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
    public partial class SearchForm : Form
    {
        public DatabaseConnector connector;

        public DataGridView dgv;
        DataTable dt = new DataTable();

        public SearchForm()
        {
            InitializeComponent();
            dgv = dataGridView1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dataGridView1.DataSource = null;

        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            Dictionary<string, string> searchData = new Dictionary<string, string>() {
                { "[ФИО ученика]", FIOComboBox.Text},
                {"[Дата рождения]", yearText.Text + "." + monthText.Text + "." + dayText.Text },
                {"[Класс]", classText.Text },
                {"[Направления]", coursesText.Text },
                {"[ФИО родителя]", FIO2Text.Text },
                {"[Телефон родителя]", telText.Text },
                {"[Дополнительный телефон]", dopTelText.Text },
                {"[Месяцы]", mouText.Text },
                {"[Время]", timeText.Text },

            };
            string req = "SELECT * FROM Clients WHERE [ID]!=0";
            foreach (var item in searchData)
            {
                if (item.Key == "[Дата рождения]")
                {
                    if (yearText.Text != "") req += $" AND ({item.Key} LIKE '%{yearText.Text}%')";
                    if (monthText.Text != "") req += $" AND ({item.Key} LIKE '%{monthText.Text}%')";
                    if (dayText.Text != "") req += $" AND ({item.Key} LIKE '%{dayText.Text}%')";
                    continue;
                }
                if (item.Value != "" && item.Value != "..")
                    req += $" AND ({item.Key} LIKE '%{item.Value}%')";
            }
            dataGridView1.DataSource = connector.SqlRequest(req);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            connector.UpdateDatabaseFromDataGridView((DataTable)dataGridView1.DataSource);
            Search();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            connector.SqlRequest("DELETE FROM Clients WHERE [ID]='" + textBox1.Text + "'");
            AddForm.id--;
        }
    }
}
