using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Implementations.Add
{
    public class AddColumn : IAddColumn
    {
        public string ColumnName { get; private set; }

        public string TableName { get; private set; }

        public Column ColumnInformation { get; private set; }

        public AddColumn(string columnName, Func<Column, Column> func)
        {
            ColumnInformation = func(new Column());
            ColumnName = columnName;
        }

        public void In(string tableName)
        {
            TableName = tableName;
        }
    }
}
