using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    // Подключение к БД
    class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = LAPTOP-RDF104A1\ADCLG1; Initial Catalog = AUDIT; Integrated Security = true");

        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
