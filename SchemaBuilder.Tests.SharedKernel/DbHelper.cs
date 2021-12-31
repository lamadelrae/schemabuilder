using Dapper;
using System.Data.SqlClient;

namespace SchemaBuilder.Tests.SharedKernel
{
    public static class DbHelper
    {
        public static bool DoesTableExist(this SqlConnection connection, string tableName)
        {
            string sql = "SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableName";

            return connection.QueryFirstOrDefault<bool>(sql, new { tableName });
        }

        public static bool DoesColumnExistInTable(this SqlConnection connection, string tableName, string columnName)
        {
            string sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = @tableName AND column_name = @columnName";

            return connection.QueryFirstOrDefault<bool>(sql, new { tableName, columnName });
        }

        public static void WipeDb(this SqlConnection connection)
        {
            string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
            connection.Query<string>(sql).ToList().ForEach(table => connection.Execute($"DROP TABLE {table}"));
        }
    }
}