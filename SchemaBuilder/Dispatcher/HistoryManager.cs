using SchemaBuilder.Models;
using System.Data.SqlClient;

namespace SchemaBuilder.Dispatcher
{
    public class HistoryManager
    {
        private readonly SqlConnection _connection;

        public HistoryManager(SqlConnection connection)
        {
            _connection = connection;

            if (!TableExists())
                CreateTable();
        }

        public void InsertHistory(History history)
        {
            string sql = "INSERT INTO SchemaBuilderHistory VALUES (@id, @scriptId, @script, @dateCreated)";

            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@id", history.Id));
            cmd.Parameters.Add(new SqlParameter("@scriptId", history.ScriptId));
            cmd.Parameters.Add(new SqlParameter("@script", history.Script));
            cmd.Parameters.Add(new SqlParameter("@dateCreated", history.DateCreated));
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public IEnumerable<History> GetHistory()
        {
            string sql = "SELECT * FROM SchemaBuilderHistory";

            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                yield return new History((Guid)reader[0], (int)reader[1], (string)reader[2], (DateTime)reader[3]);

            _connection.Close();
        }

        private bool TableExists()
        {
            _connection.Open();

            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = @"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SchemaBuilderHistory'";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                return (bool)reader[0];

            return false;
        }

        private void CreateTable()
        {
            string sql = @"CREATE TABLE SchemaBuilderHistory
                           (
                           	    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                                ScriptId INT,
                           	    Script VARCHAR(MAX),
                           	    DateCreated DATETIME DEFAULT GETDATE()
                           )";

            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
