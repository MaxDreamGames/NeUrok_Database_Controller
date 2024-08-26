using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace NeUrok_DB_Controller
{
    public partial class ConnectForm : Form
    {
        Color closeBtnColor;
        bool isDraging = false;
        Point startPoint = new Point(0, 0);
        DatabaseConnector connector = new DatabaseConnector();
        Menu menu = new Menu();
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            label3.Text = this.Text;
            closeBtnColor = closeBtn.BackColor;
            SetAutoRunValue(true, Assembly.GetExecutingAssembly().Location);
            Connect();
            menu.Hide();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.Red;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackColor = closeBtnColor;
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

        private void ConnectForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon2.Visible = true;
            }
            else if (WindowState == FormWindowState.Normal)
                notifyIcon2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void notifyIcon2_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon2.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        void Connect()
        {
            connector.Connect();
            if (connector.Connect().State == ConnectionState.Open)
            {
                menu.connector = connector;
                menu.connectForm = this;
                menu.Show();
                WindowState = FormWindowState.Minimized;
            }
            else
                MessageBox.Show("Not connect", "Attantion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        bool SetAutoRunValue(bool autoRun, string path)
        {
            const string name = "NeUrok DB Controller";
            string exePath = path;
            RegistryKey reg;

            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

            try
            {
                if (autoRun)
                    reg.SetValue(name, exePath);
                else
                    reg.DeleteValue(name);

                reg.Flush();
                reg.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
