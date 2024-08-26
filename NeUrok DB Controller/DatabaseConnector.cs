using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace NeUrok_DB_Controller
{
    public class DatabaseConnector
    {
        string server;
        string database;
        public MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + ";charset=utf8";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
        public MySqlConnection Connect()
        {
            MySqlConnection sqlConnection = GetDBConnection("localhost", 3306, "ne_urok_database", "root", "0122");
            sqlConnection.Open();
            return sqlConnection;
        }

        public DataTable SqlRequest(string request)
        {
            try
            {
                MySqlConnection sqlConnection1 = Connect();
                MySqlCommand cmd = new MySqlCommand(request, sqlConnection1);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlConnection1.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SetServerString(string server) { this.server = server; }
        public void SetDatabaseString(string database) { this.database = database; }

        public void UpdateDatabaseFromDataGridView(DataTable dt)
        {
            string updateQuery = "UPDATE Clients SET `FIO student`=@Name, `Birthday`=@BirthDate, `Class`=@Class, `Courses`=@Direction, `FIO parent`=@ParentName, `Telephone`=@ParentPhone, `Add. telephone`=@AdditionalPhone, `Months`=@Months, `Time`=@Time, `Comments`=@Comments WHERE ID=@Id";

            using (Connect())
            {
                MySqlCommand command = new MySqlCommand(updateQuery, Connect());
                command.Parameters.Add("@Name", MySqlDbType.VarChar, 50, "FIO student");
                command.Parameters.Add("@BirthDate", MySqlDbType.VarChar, 10, "Birthday");
                command.Parameters.Add("@Class", MySqlDbType.Int32, 0, "Class");
                command.Parameters.Add("@Direction", MySqlDbType.VarChar, -1, "Courses");
                command.Parameters.Add("@ParentName", MySqlDbType.VarChar, -1, "FIO parent");
                command.Parameters.Add("@ParentPhone", MySqlDbType.VarChar, 50, "Telephone");
                command.Parameters.Add("@AdditionalPhone", MySqlDbType.VarChar, 50, "Add. telephone");
                command.Parameters.Add("@Months", MySqlDbType.VarChar, 100, "Months");
                command.Parameters.Add("@Time", MySqlDbType.VarChar, 100, "Time");
                command.Parameters.Add("@Comments", MySqlDbType.VarChar, -1, "Comments");
                command.Parameters.Add("@Id", MySqlDbType.Int32, 0, "ID");

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.UpdateCommand = command;

                adapter.Update(dt);
                Connect().Close();

            }
        }

        public void Format(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string date = dt.Rows[i][2].ToString();
                string[] splitedDays = date.Split('.');
                if (splitedDays[1].Length == 1 || splitedDays[2].Length == 1)
                {
                    string newDateString = splitedDays[0];
                    if (splitedDays[1].Length == 1) newDateString += "." + "0" + splitedDays[1];
                    else newDateString += "." + splitedDays[1];
                    if (splitedDays[2].Length == 1) newDateString += "." + "0" + splitedDays[2];
                    else newDateString += "." + splitedDays[2];
                    dt.Rows[i][2] = newDateString;
                    UpdateDatabaseFromDataGridView(dt);
                }
            }
        }

    }
}
