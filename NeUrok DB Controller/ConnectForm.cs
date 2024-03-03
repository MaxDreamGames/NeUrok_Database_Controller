using System;
using System.Data;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class ConnectForm : Form
    {
        DatabaseConnector connector = new DatabaseConnector();
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connector.Connect();
            if (connector.Connect().State == ConnectionState.Open)
            {
                Menu menu = new Menu();
                menu.connector = connector;
                menu.Show();
                //  Hide();
            }
            else
                MessageBox.Show("Not connect", "Attantion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
