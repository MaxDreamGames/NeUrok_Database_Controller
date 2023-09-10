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
    public partial class Menu : Form
    {

        public DatabaseConnector connector;
        SearchForm searchForm = new SearchForm();
        AddForm addForm = new AddForm();
        public Menu()
        {
            InitializeComponent();
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
                connector.Connect();
                if (connector.Connect().State != ConnectionState.Open)
                {
                    MessageBox.Show("Connect is not success");
                    label2.Text = "Подключение не установлено!";
                }
                else
                {
                    label2.Text = "Подключение установлено!";
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        PrintAllDB printAllDB = new PrintAllDB();

            printAllDB.connector = connector;
            printAllDB.Show();
            printAllDB.dgv.DataSource = connector.SqlRequest("select * from Clients");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchForm.connector = connector;
            searchForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addForm.connector = connector;
            addForm.Show();
        }
    }
}
