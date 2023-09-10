using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net;

namespace NeUrok_DB_Controller
{
    public class DatabaseConnector
    {
        string server;
        string database;
        public SqlConnection Connect()
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.IntegratedSecurity = true;
            sqlConnection.ConnectionString = builder.ToString();
            sqlConnection.Open();
            return sqlConnection;
        }

        public DataTable SqlRequest(string request)
        {
     SqlConnection sqlConnection1 = Connect();
            SqlCommand cmd = new SqlCommand(request, sqlConnection1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
               sqlConnection1.Close();
                return dt;

        }

        public void SetServerString(string server) { this.server = server; }
        public void SetDatabaseString(string database) { this.database = database; }

        public void UpdateDatabaseFromDataGridView(DataTable dt)
        {
            string updateQuery = "UPDATE Clients SET [ФИО ученика]=@Name, [Дата рождения]=@BirthDate, [Класс]=@Class, [Направления]=@Direction, [ФИО родителя]=@ParentName, [Телефон родителя]=@ParentPhone, [Дополнительный телефон]=@AdditionalPhone, [Месяцы]=@Months, [Время]=@Time, [Комментарии]=@Comments WHERE ID=@Id";

            using (Connect())
            {
                SqlCommand command = new SqlCommand(updateQuery, Connect());
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "ФИО ученика");
                command.Parameters.Add("@BirthDate", SqlDbType.NVarChar, 10, "Дата рождения");
                command.Parameters.Add("@Class", SqlDbType.Int, 0, "Класс");
                command.Parameters.Add("@Direction", SqlDbType.NVarChar, -1, "Направления");
                command.Parameters.Add("@ParentName", SqlDbType.NVarChar, -1, "ФИО родителя");
                command.Parameters.Add("@ParentPhone", SqlDbType.VarChar, 50, "Телефон родителя");
                command.Parameters.Add("@AdditionalPhone", SqlDbType.VarChar, 50, "Дополнительный телефон");
                command.Parameters.Add("@Months", SqlDbType.NVarChar, 100, "Месяцы");
                command.Parameters.Add("@Time", SqlDbType.NVarChar, 100, "Время");
                command.Parameters.Add("@Comments", SqlDbType.NVarChar, -1, "Комментарии");
                command.Parameters.Add("@Id", SqlDbType.Int, 0, "ID");

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command;

                adapter.Update(dt);
                Connect().Close();

            }
        }
       

        
    }
}
