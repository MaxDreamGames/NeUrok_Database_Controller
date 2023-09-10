using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeUrok_DB_Controller;

namespace NeUrok_DB_Controller
{
    public partial class PrintAllDB : Form
    {
        public DatabaseConnector connector;
        public DataGridView dgv;
        DataTable dt = new DataTable();

        public PrintAllDB()
        {
            InitializeComponent();
            dgv = dataGridView1;
        }


        private void PrintAllDB_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            dataGridView1.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connector.UpdateDatabaseFromDataGridView((DataTable)dataGridView1.DataSource);
            dgv.DataSource = connector.SqlRequest("select * from Clients");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv.DataSource = null;
            dgv.DataSource = connector.SqlRequest("select * from Clients");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            connector.SqlRequest("DELETE FROM Clients WHERE [ID]='" + textBox1.Text + "'");
            AddForm.id--;
        }
   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}