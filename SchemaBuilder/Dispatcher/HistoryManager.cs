using Dapper;
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

        private bool TableExists()
        {
            string sql = @"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SchemaBuilderHistory'";

            return _connection.QueryFirstOrDefault<bool>(sql);
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

            _connection.Execute(sql);
        }

        public void InsertHistory(History history)
        {
            string sql = "INSERT INTO SchemaBuilderHistory VALUES (@Id, @ScriptId, @Script, @DateCreated)";

            _connection.Execute(sql, history);
        }

        public IEnumerable<History> GetHistory()
        {
            string sql = "SELECT * FROM SchemaBuilderHistory";

            return _connection.Query<History>(sql);
        }
    }
}
