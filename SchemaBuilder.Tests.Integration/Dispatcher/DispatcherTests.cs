using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Tests.SharedKernel;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace SchemaBuilder.Tests.Integration.Dispatcher
{
    public class DispatcherTests
    {
        private readonly SqlConnection _connection = Connection.Get();

        [Fact]
        public void ShouldRunAll()
        {
            _connection.WipeDb();
            ShouldCreateTable();
            ShouldCreateColumn();
            ShouldRenameColumns();
            ShouldDropColumns();
            ShouldDropTables();
        }

        private void ShouldCreateTable()
        {
            SchemaBuilder.UseSchemaBuilder(
                _connection,
                new List<Script>()
                {
                    new ScriptMockForIntegration.CreateTables()
                });

            bool tablesExist = _connection.DoesTableExist("Customer") && _connection.DoesTableExist("Company");

            Assert.True(tablesExist);
        }

        private void ShouldCreateColumn()
        {
            SchemaBuilder.UseSchemaBuilder(
                _connection,
                new List<Script>()
                {
                    new ScriptMockForIntegration.CreateColumns()
                });

            bool columnsExist = _connection.DoesColumnExistInTable("Customer", "FatherName") && _connection.DoesColumnExistInTable("Company", "OwnerName");

            Assert.True(columnsExist);
        }

        private void ShouldRenameColumns()
        {
            SchemaBuilder.UseSchemaBuilder(
                _connection,
                new List<Script>()
                {
                    new ScriptMockForIntegration.RenameColumns()
                });

            bool columnsExist = _connection.DoesColumnExistInTable("Customer", "Father") && _connection.DoesColumnExistInTable("Company", "Owner");

            Assert.True(columnsExist);
        }

        private void ShouldDropColumns()
        {
            SchemaBuilder.UseSchemaBuilder(
                _connection,
                new List<Script>()
                {
                    new ScriptMockForIntegration.DropColumns()
                });

            bool columnsExist = _connection.DoesColumnExistInTable("Customer", "Father") && _connection.DoesColumnExistInTable("Company", "Owner");

            Assert.False(columnsExist);
        }

        private void ShouldDropTables()
        {
            SchemaBuilder.UseSchemaBuilder(
                _connection,
                new List<Script>()
                {
                    new ScriptMockForIntegration.DropTables()
                });

            bool tablesExist = _connection.DoesTableExist("Customer") && _connection.DoesTableExist("Company");

            Assert.False(tablesExist);
        }
    }
}
