using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeUrok_DB_Controller
{
    public partial class Menu : Form
    {
        Color closeBtnColor;
        bool isDraging = false;
        Point startPoint = new Point(0, 0);
        public DatabaseConnector connector;
        public ConnectForm connectForm;
        SearchForm searchForm = new SearchForm();
        AddForm addForm = new AddForm();
        PrintAllDB printAllDB = new PrintAllDB();
        public static bool isMinimise;
        public string nowBirtdays = "";

        public Menu()
        {
            InitializeComponent();

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            closeBtnColor = closeBtn.BackColor;
            label3.Text = this.Text;
            connector.Connect();
            if (connector.Connect().State != ConnectionState.Open)
            {
                MessageBox.Show("Connect is not success");
                label2.Text = "Подключение не установлено!";
            }
            else
                label2.Text = "Подключение установлено!";

            CheckBirthdays();
            if (nowBirtdays != "")
            {
                nowBirtdays = nowBirtdays.Remove(nowBirtdays.Length - 2);
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = nowBirtdays;
                notifyIcon1.ShowBalloonTip(5000);
            }
            if (DateTime.Now.Day >= 1 && DateTime.Now.Day < 10 && DateTime.Now.Month == 9 && Properties.Settings.Default.Updates != DateTime.Now.Year.ToString())
                CheckTheFirstOfSeptember();
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

            printAllDB.connector = connector;
            printAllDB.Show();
            printAllDB.dgv.DataSource = connector.SqlRequest("select * from Clients");
            printAllDB.ShowThis();


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


        void CheckBirthdays() // check and print birthdays for 3 days
        {
            string msgAboutNow = "Дни рождения сегодня:\n";
            string msgAboutTomorrow = "Дни рождения завтра:\n";
            string msgAboutPostomorrow = "Дни рождения послезавтра:\n";
            string nowDate = DateTime.Now.Day.ToString("00") + "." + DateTime.Now.Month.ToString("00"); // current date
            string tomorrowDate = (DateTime.Now.Day + 1).ToString("00") + "." + DateTime.Now.Month.ToString("00"); // tomorrow date
            string posttomorrowDate = (DateTime.Now.Day + 2).ToString("00") + "." + DateTime.Now.Month.ToString("00"); // posttomorrow date
            DataTable data = connector.SqlRequest("SELECT * FROM Clients");
            for (int i = 0; i < data.Rows.Count; i++) // check all client's birthdays
            {
                DataRow currentRow = data.Rows[i];
                string[] birthdaySplited = currentRow[2].ToString().Split('.');
                if (birthdaySplited.Length < 3) continue;
                string birthdayDate = birthdaySplited[2] + "." + birthdaySplited[1]; // date to necessary format
                if (birthdayDate == nowDate) // set birthdays today
                {
                    msgAboutNow += currentRow[1] + " – " + (Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(birthdaySplited[0])).ToString() + " лет\n";
                    nowBirtdays += currentRow[1] + ", ";

                }
                else if (birthdayDate == tomorrowDate) // set birthdays tomorrow
                    msgAboutTomorrow += currentRow[1] + " – " + (Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(birthdaySplited[0])).ToString() + " лет\n";
                else if (birthdayDate == posttomorrowDate) // set birthdays posttomorrow
                    msgAboutPostomorrow += currentRow[1] + " – " + (Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(birthdaySplited[0])).ToString() + " лет\n";
            }
            birthdaysNowText.Text = msgAboutNow + "\n";
            birthdaysNowText.Text += msgAboutTomorrow + "\n";
            birthdaysNowText.Text += msgAboutPostomorrow + "\n";
        }

        void CheckTheFirstOfSeptember()
        {
            MessageBox.Show("Обновление классов");
            DataTable dt = connector.SqlRequest("SELECT * FROM Clients");
            foreach (DataRow row in dt.Rows)
            {
                row[3] = Convert.ToInt32(row[3]) + 1;
                connector.UpdateDatabaseFromDataGridView(dt);
            }
            NeUrok_DB_Controller.Properties.Settings.Default.Updates = DateTime.Now.Year.ToString();
            Properties.Settings.Default.Save();
            Console.WriteLine(Properties.Settings.Default.Updates);
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            connectForm.Show();
            connectForm.WindowState = FormWindowState.Normal;
        }
    }
}
