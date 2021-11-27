using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Models;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Add
{
    public class AddColumn : IAddColumn
    {
        public string ColumnName { get; private set; } = string.Empty;

        public string TableName { get; private set; } = string.Empty;

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

        public void IsValid()
        {
            bool isValid = new Validator<AddColumn>(x => !string.IsNullOrEmpty(x.ColumnName) && !string.IsNullOrEmpty(x.TableName) && x.ColumnName != null)
                .Validate(this);

            ValidationException.ThrowIfFalse(isValid, "AddColumn");
        }
    }
}
