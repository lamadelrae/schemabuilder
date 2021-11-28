using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Drop;
using SchemaBuilder.Core.Interfaces.Drop;
using SchemaBuilder.Core.Interfaces.Validations.Base;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Drop
{
    public class DropColumn : IDropColumnConrtact, IDropColumnDataHolder, IValidation
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
