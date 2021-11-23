using SchemaBuilder.Core.Interfaces.Drop;

namespace SchemaBuilder.Core.Implementations.Drop
{
    public class DropColumn : IDropColumn
    {
        public string? ColumnName { get; private set; }

        public string? TableName { get; private set; }

        public DropColumn(string columnName)
        {
            ColumnName = columnName;
        }

        public void In(string tableName)
        {
            TableName = tableName;
        }
    }
}
