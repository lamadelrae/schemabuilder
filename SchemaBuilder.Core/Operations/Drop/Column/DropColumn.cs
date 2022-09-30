using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Drop.Column;
using SchemaBuilder.Core.Shared;

namespace SchemaBuilder.Core.Operations.Drop.Column
{
    public class DropColumn : IDropColumnContract, IDropColumnDataStore, IValidation
    {
        public string ColumnName { get; private set; }

        public string TableName { get; private set; } = string.Empty;

        public DropColumn(string columnName)
        {
            ColumnName = columnName;
        }

        public void In(string tableName)
        {
            TableName = tableName;
        }

        public void IsValid()
        {
            bool isValid = new Validator<DropColumn>(x => !string.IsNullOrEmpty(x.ColumnName) && !string.IsNullOrEmpty(x.TableName))
                .Validate(this);

            ValidationException.ThrowIfFalse(isValid, "AddTable");
        }
    }
}
