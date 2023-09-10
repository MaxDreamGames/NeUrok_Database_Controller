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
    public partial class ConnectForm : Form
    {
        DatabaseConnector connector = new DatabaseConnector();
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connector.SetDatabaseString(comboBox2.Text);
            connector.SetServerString(comboBox1.Text);
            connector.Connect();
            if (connector.Connect().State == ConnectionState.Open)
            {
                Menu menu = new Menu();
                menu.connector = connector;
                comboBox2.Items.Add(comboBox2.Text) ;
                comboBox1.Items.Add(comboBox1.Text) ;
                menu.Show();
                //Close();
            }
            else
                MessageBox.Show("Not connect", "Attantion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "DESKTOP-KCR3D41\\SQLEXPRESS";
            comboBox2.Text = "NeUrokDatabase";
        }
    }
}
